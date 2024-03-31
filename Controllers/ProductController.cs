using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using TechWeb.Models;

namespace TechWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbTechContext _context;

        public ProductController(DbTechContext context)
        {
            _context = context;
        }
        // Tạo  view index cho sản phẩm
        public IActionResult Index()
        {   
            return View();
        }
        // Tạo  view chi tiết sản phẩm 
        public IActionResult Details()
        {
            return View();
   
        }
        // Tạo  view Loại sản phẩm điện thoại  
        public IActionResult Phone()
        {
            return View();

        }
        // Tạo  view Loại điện thoại  iphone 

        public IActionResult Iphone()
		{
			return View();

        }       
        // Tạo  view Loại điện thoại  samsung 
        public IActionResult Samsung()
		{
			return View();

		}
	}
}
