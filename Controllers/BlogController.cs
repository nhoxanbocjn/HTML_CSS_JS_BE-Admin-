using Microsoft.AspNetCore.Mvc;

namespace TechWeb.Controllers
{
    public class BlogController : Controller
    {
		// Tạo  view index cho blog
        public IActionResult Index()
        {
            return View();
        }
        // Tạo  view Details1
        public IActionResult Detail1()
		{
			return View();
		}
        // Tạo  view details
        public IActionResult Detail2()
		{
			return View();
		}
	}
}
