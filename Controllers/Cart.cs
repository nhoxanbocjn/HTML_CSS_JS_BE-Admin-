using Microsoft.AspNetCore.Mvc;

namespace TechWeb.Controllers
{
    public class Cart : Controller
    {		// Tạo  view index cho Cart
        public IActionResult Index()
        {
            return View();
        }
    }
}
