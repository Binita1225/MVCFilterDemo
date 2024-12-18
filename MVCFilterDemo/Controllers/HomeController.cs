using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OutputCaching;
using MVCFilterDemo.Models;
using MVCFiltersDemo.Filters;
using System.Diagnostics;

namespace MVCFilterDemo.Controllers
{
    
    [MyLogActionFilter]
    //[MyExceptionFilter] // Handles exceptions globally
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 15, Location = ResponseCacheLocation.Client)] // Cache response for 15 seconds
        public string Index()
        {
            return "This is test";
            
            //for exception testing 
            //throw new Exception("This is test exception");
        }

        [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Client)] // Cache response for 20 seconds
        [ActionName("CurrentTime")]
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("T");
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
