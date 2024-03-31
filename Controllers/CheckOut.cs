using Microsoft.AspNetCore.Mvc;

namespace TechWeb.Controllers
{
    public class CheckOut : Controller
    {		// Tạo view index cho thanh toán
        public IActionResult Index()
        {
            return View();
        }
    }
}
