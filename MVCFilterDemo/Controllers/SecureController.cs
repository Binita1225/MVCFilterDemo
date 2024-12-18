using Microsoft.AspNetCore.Mvc;

namespace MVCFilterDemo.Controllers
{

    public class SecureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
