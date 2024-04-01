using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TechWeb.Models;
using TechWeb.Areas.Admin.Models;

namespace TechWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
     
        private readonly DbTechContext _context;
        
        public AccountController(DbTechContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [Route("Adminlogin", Name = "Login")]
      public IActionResult AdminLogin(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("AccountId");
            if (taikhoanID != null) return RedirectToAction("Index", "Home", new { Area = "Admin" });
            ViewBag.ReturnUrl = returnUrl;
            return View();
            }
        [HttpPost]
        [AllowAnonymous]
        [Route("Adminlogin", Name = "Login")]
        public async Task<IActionResult> AdminLogin(LoginViewModel model, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Account ad = _context.Accounts
                                      .Include(p => p.Role)
                                      .SingleOrDefault(p => p.Email.ToLower() == model.UserName.ToLower().Trim());
                    if (ad == null)
                    {
                        ViewBag.Error = "Thông tin đăng nhập chưa chính xác";
                        return View(model);
                    }
                    string pass = (model.Password.Trim());
                    if (ad.Password.Trim() != pass)
                    {
                        ViewBag.Error = "Thông tin đăng nhập chưa chính xác";
                        return View(model);
                    }
                    //đăng nhập thành công

                    //ghi nhận thời gian đăng nhập
                    ad.LastLogin = DateTime.Now;
                    _context.Update(ad);
                    await _context.SaveChangesAsync();


                    var taikhoanID = HttpContext.Session.GetString("AccountId");
                    //identity
                    HttpContext.Session.SetString("AccountId", ad.AccountId.ToString());
                
                    //identity
                    var userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, ad.FullName),
                        new Claim(ClaimTypes.Email, ad.Email),
                        new Claim("AccountId", ad.AccountId.ToString()),
                        new Claim("RoleId", ad.RoleId.ToString()),
                        new Claim(ClaimTypes.Role, ad.Role.RoleName)
                    };
                    var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    await HttpContext.SignInAsync(userPrincipal);
                    ViewBag.AdminName = ad.FullName;



                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
            }
            catch
            {
                return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
            }
            return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
        }
             public IActionResult AdminLogout()
        {
            try
            {
                HttpContext.SignOutAsync();
                HttpContext.Session.Remove("AccountId");
                return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
            }
            catch
            {
                return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
            }
        }

    }
}
