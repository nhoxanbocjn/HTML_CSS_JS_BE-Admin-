using Microsoft.AspNetCore.Mvc;

namespace TechWeb.Controllers
{
    public class MyProfile : Controller
    {
        // Tạo  view index cho trang tài khoản của tôi
        public IActionResult Index()
        {
            return View();
        }
        // Tạo  view quản lý thông tin  trong tài khoản của tôi
        public IActionResult Manage()
        {
            return View();
        }
        // Tạo  view chỉnh sửa thông tin  trong tài khoản của tôi
        public IActionResult Edit()
        {
            return View();
        }
        // Tạo  view chi tiết đơn hàng  trong tài khoản của tôi
        public IActionResult Order_Details()
        {
            return View();
        }
        // Tạo  view đơn hàng của tôi  trong tài khoản của tôi
        public IActionResult My_Order()
        {
            return View();
        }
    }
}
