using Microsoft.AspNetCore.Mvc;

namespace TechWeb.Controllers
{
	public class WishlistController : Controller
	{
        // Tạo  view index cho sản phẩm yêu thích 
        public IActionResult Index()
		{
			return View();
		}
	}
}
