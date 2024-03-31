using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechWeb.Models;

namespace TechWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Tạo  view index cho trang chủ 
        public IActionResult Index()
        {
            return View();

        }   
        // Tạo  view Về chúng tôi trong trang chủ 
        public IActionResult About()
        {
            return View();
        }
        // Tạo  view liên hệ trong trang chủ 
        public IActionResult Contact()
        {
            return View();
        }
        // Tạo  view hỗ trợ  trong trang chủ 
        public IActionResult Support()
        {
            return View();
        }
        // Tạo  view hàng mới  trong trang chủ 
        public IActionResult New_Arrivals()
		{
			return View();
		}

        // View khi xảy ra lỗi 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}