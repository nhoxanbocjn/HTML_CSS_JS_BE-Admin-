using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechWeb.Models;

namespace TechWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DbTechContext _context;

        public HomeController(DbTechContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int totalCustomers = _context.Customers.Count();
            int totalProducts = _context.Products.Count();

            ViewBag.TotalCustomers = totalCustomers;
            ViewBag.TotalProducts = totalProducts;

            return View();
        }
    }
}
