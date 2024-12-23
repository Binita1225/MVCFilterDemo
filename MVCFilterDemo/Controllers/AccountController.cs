using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVCFilterDemo.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "test" && password == "password") {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
            };

                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);
                return RedirectToAction("SecurePage", "Home");
            }
            return View();
        }

        public IActionResult Logout() 
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
