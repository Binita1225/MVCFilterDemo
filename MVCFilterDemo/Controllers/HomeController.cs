using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OutputCaching;
using MVCFilterDemo.Filters;
using MVCFilterDemo.Models;
using MVCFiltersDemo.Filters;
using System.Diagnostics;
using System.Security.Claims;

namespace MVCFilterDemo.Controllers
{
    
    [MyLogActionFilter] //aciton filter (for log requests)
    //[MyExceptionFilter] // Handles exceptions globally
    [MyResourceFilter] //resource filter (cache/validation resources)
    [MyResultFilter] //result filter (modify the response)
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            return "This is test";
           

            //for exception testing 
            //throw new Exception("This is test exception");
        }

        
        [MyAuthorizationFilter]// authorization filter(check if user is logged in)
        public IActionResult SecurePage()
        {
            return View();  // This is the page that requires authentication
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Renders the Login page
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username == "test" && password == "password")
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
            };

                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                Debug.WriteLine("Login success");
                 
                return RedirectToAction("SecurePage", "Home");
            }

            Debug.WriteLine("Login failed");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            Debug.WriteLine("User logged out");
            return RedirectToAction("Login", "Home");
        }
        
        [ResponseCache(Duration = 15, Location = ResponseCacheLocation.Client)] // Cache response for 15 seconds
        [MyExceptionFilter]   // Exception Filter (Handle exceptions)
        

       // [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Client)] // Cache response for 20 seconds
        [ActionName("CurrentTime")]
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("T");
        }

        [ResponseCache(Duration = 10)]  // Output Cache Filter (Cache output for 10 seconds)
        public IActionResult About()
        {
            return Content("Welcome to about page");
        }
        public IActionResult Contact() 
        {
            return Content("Welcome to contact page");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
