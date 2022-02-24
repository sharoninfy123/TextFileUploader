using Microsoft.AspNetCore.Mvc;

namespace MyFileUploader.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutView()
        {
            return View();
        }
    }
}
