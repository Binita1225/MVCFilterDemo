using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVCFilterDemo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, "TestUser"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(claims, "TestAuth");
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(principal);
            return RedirectToAction("Index", "Secure");
        }

        public IActionResult Logout() 
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
