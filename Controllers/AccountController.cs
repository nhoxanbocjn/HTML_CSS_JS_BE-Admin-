using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TechWeb.Extension;
using TechWeb.Helpper;
using TechWeb.Models;
using TechWeb.ModelViews;

namespace TechWeb.Controllers
{

    public class AccountController : Controller     
    {
        // Khởi tạo Constructor 
        private readonly DbTechContext _context;
        public INotyfService _notyfService { get; }
        public AccountController(DbTechContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        [HttpGet]
        [AllowAnonymous]
        // Kiểm tra hợp lệ số điện thoại 
        public IActionResult ValidatePhone(string Phone)
        {
            try
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Phone.ToLower() == Phone.ToLower());
                if (khachhang != null)
                    return Json(data: "Số điện thoại : " + Phone + "đã được sử dụng");

                return Json(data: true);

            }
            catch
            {
                return Json(data: true);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        // Kiểm tra hợp lệ email
        public IActionResult ValidateEmail(string Email)
        {
            try
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
                if (khachhang != null)
                    return Json(data: "Email : " + Email + " đã được sử dụng");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        // Hiển thị  Login_resginter cshtml ở View
        public IActionResult Login_Resgiter()
        {
            return View();
        }
        //public IActionResult DangkyTaiKhoan()
        //{
        //	return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]

        //public async Task<IActionResult> Login_Resgiter(Login_RegisterViewModel taikhoan)
        //{
        //    var registreViewModel = taikhoan.RegistreViewModel;
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string salt = Utilities.GetRandomKey();
        //            Customer khachhang = new Customer
        //            {
        //                FullName = registreViewModel.FullName,
        //                Phone = registreViewModel.Phone.Trim().ToLower(),
        //                Email = registreViewModel.Email.Trim().ToLower(),
        //                Password = (registreViewModel.Password + salt.Trim()).ToMD5(),
        //                Active = true,
        //                Salt = salt,
        //                CreateDate = DateTime.Now
        //            };
        //            try
        //            {
        //                _context.Add(khachhang);
        //                await _context.SaveChangesAsync();
        //                //Lưu Session MaKh
        //                HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
        //                var taikhoanID = HttpContext.Session.GetString("CustomerId");

        //                //Identity
        //                var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, khachhang.FullName),
        //            new Claim("CustomerId", khachhang.CustomerId.ToString())
        //        };
        //                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
        //                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //                await HttpContext.SignInAsync(claimsPrincipal);
        //                _notyfService.Success("Đăng ký thành công");
        //                return RedirectToAction("Index", "Home");
        //            }
        //            catch
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            var errors = ModelState.Values.SelectMany(v => v.Errors);
        //            foreach (var error in errors)
        //            {
        //                Console.WriteLine(error.ErrorMessage);
        //            }
        //            return View(taikhoan);

        //        }
        //    }
        //    catch
        //    {
        //        return View(taikhoan);
        //    }
        //}

        //[AllowAnonymous]
        //public IActionResult Login_Resgiter(string returnUrl = null)
        //{
        //    var taikhoanID = HttpContext.Session.GetString("CustomerId");
        //    if (taikhoanID != null)
        //    {
        //        return RedirectToAction("Dashboard", "Accounts");
        //    }
        //    return View();
        //}
        //[HttpPost]
        //[AllowAnonymous]

        //public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl)
        //{
        //	try
        //	{
        //		if (ModelState.IsValid)
        //		{
        //			bool isEmail = Utilities.IsValidEmail(customer.UserName);
        //			if (!isEmail) return View(customer);

        //			var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);

        //			if (khachhang == null) return RedirectToAction("DangkyTaiKhoan");
        //			string pass = (customer.Password + khachhang.Salt.Trim()).ToMD5();
        //			if (khachhang.Password != pass)
        //			{
        //				_notyfService.Success("Thông tin đăng nhập chưa chính xác");
        //				return View(customer);
        //			}
        //			//kiem tra xem account co bi disable hay khong

        //			if (khachhang.Active == false)
        //			{
        //				return RedirectToAction("ThongBao", "Accounts");
        //			}

        //			//Luu Session MaKh
        //			HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
        //			var taikhoanID = HttpContext.Session.GetString("CustomerId");

        //			//Identity
        //			var claims = new List<Claim>
        //			{
        //				new Claim(ClaimTypes.Name, khachhang.FullName),
        //				new Claim("CustomerId", khachhang.CustomerId.ToString())
        //			};
        //			ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
        //			ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //			await HttpContext.SignInAsync(claimsPrincipal);
        //			_notyfService.Success("Đăng nhập thành công");
        //			if (string.IsNullOrEmpty(returnUrl))
        //			{
        //				return RedirectToAction("Dashboard", "Accounts");
        //			}
        //			else
        //			{
        //				return Redirect(returnUrl);
        //			}
        //		}
        //	}
        //	catch
        //	{
        //		return RedirectToAction("DangkyTaiKhoan", "Accounts");
        //	}
        //	return View(customer);
        //}
        // Suawr loi 
        //public async Task<IActionResult> Login_Resgiter(Login_RegisterViewModel customer, string returnUrl)
        //{
        //    try
        //    {
        //        // Check if the ModelState is valid
        //        if (ModelState.IsValid)
        //        {
        //            // Check if the email is in a valid format
        //            bool isEmail = Utilities.IsValidEmail(customer.LoginViewModel.UserName);
        //            if (!isEmail)
        //            {
        //                // Return the view with the invalid model if email format is incorrect
        //                return View(customer);
        //            }

        //            // Retrieve the customer based on the provided email
        //            var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.LoginViewModel.UserName);

        //            // If no customer found with the provided email, redirect to registration page
        //            if (khachhang == null)
        //            {
        //                return RedirectToAction("Login_Resgiter", "Accounts");
        //            }

        //            // Verify the password
        //            string pass = (customer.LoginViewModel.Password + khachhang.Salt.Trim()).ToMD5();
        //            if (khachhang.Password != pass)
        //            {
        //                _notyfService.Success("Thông tin đăng nhập chưa chính xác");
        //                return View(customer);
        //            }

        //            // Check if the account is active
        //            if (!khachhang.Active)
        //            {
        //                return RedirectToAction("ThongBao", "Accounts");
        //            }

        //            // Store CustomerId in session
        //            HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());

        //            // Create claims for Identity
        //            var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, khachhang.FullName),
        //        new Claim("CustomerId", khachhang.CustomerId.ToString())
        //    };
        //            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
        //            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //            await HttpContext.SignInAsync(claimsPrincipal);

        //            _notyfService.Success("Đăng nhập thành công");
        //            // Redirect to the dashboard or returnUrl if present
        //            if (string.IsNullOrEmpty(returnUrl))
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //            else
        //            {
        //                return Redirect(returnUrl);
        //            }
        //        }
        //        else
        //        {
        //            var errors = ModelState.Values.SelectMany(v => v.Errors);
        //            foreach (var error in errors)
        //            {
        //                Console.WriteLine(error.ErrorMessage);
        //            }
        //            return View(customer);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle exceptions
        //        return RedirectToAction("Login_Resgiter", "Accounts");
        //    }

        //    // Return the view with the invalid model if ModelState is not valid
        //    return View(customer);
        //}

        //public async Task<IActionResult>Login_Resgiter(Login_RegisterViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (model.LoginViewModel != null)
        //            {
        //                // This is a login request
        //                var loginModel = model.LoginViewModel;
        //                bool isEmail = Utilities.IsValidEmail(loginModel.UserName);
        //                if (!isEmail)
        //                {
        //                    return View(model);
        //                }

        //                var customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == loginModel.UserName);
        //                if (customer == null)
        //                {
        //                    return RedirectToAction("Login_Resgiter", "Accounts");
        //                }

        //                string pass = (loginModel.Password + customer.Salt.Trim()).ToMD5();
        //                if (customer.Password != pass || !customer.Active)
        //                {
        //                    _notyfService.Success("Thông tin đăng nhập chưa chính xác");
        //                    return View(model);
        //                }

        //                HttpContext.Session.SetString("CustomerId", customer.CustomerId.ToString());

        //                var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, customer.FullName),
        //            new Claim("CustomerId", customer.CustomerId.ToString())
        //        };
        //                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
        //                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //                await HttpContext.SignInAsync(claimsPrincipal);

        //                _notyfService.Success("Đăng nhập thành công");
        //                    return RedirectToAction("Index", "Home");


        //            }
        //            else if (model.RegistreViewModel != null)
        //            {
        //                // This is a registration request
        //                var registerModel = model.RegistreViewModel;
        //                string salt = Utilities.GetRandomKey();
        //                Customer khachhang = new Customer
        //                {
        //                    FullName = registerModel.FullName,
        //                    Phone = registerModel.Phone.Trim().ToLower(),
        //                    Email = registerModel.Email.Trim().ToLower(),
        //                    Password = (registerModel.Password + salt.Trim()).ToMD5(),
        //                    Active = true,
        //                    Salt = salt,
        //                    CreateDate = DateTime.Now
        //                };

        //                try
        //                {
        //                    _context.Add(khachhang);
        //                    await _context.SaveChangesAsync();
        //                    HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());

        //                    var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, khachhang.FullName),
        //                new Claim("CustomerId", khachhang.CustomerId.ToString())
        //            };
        //                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
        //                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //                    await HttpContext.SignInAsync(claimsPrincipal);
        //                    _notyfService.Success("Đăng ký thành công");
        //                    return RedirectToAction("Index", "Home");
        //                }
        //                catch
        //                {
        //                    return RedirectToAction("Index", "Home");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            var errors = ModelState.Values.SelectMany(v => v.Errors);
        //            foreach (var error in errors)
        //            {
        //                Console.WriteLine(error.ErrorMessage);
        //            }
        //            return View(model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle exceptions
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //        foreach (var error in errors)
        //        {
        //            Console.WriteLine(error.ErrorMessage);
        //            return RedirectToAction("Login_Resgiter", "Accounts");
        //        }

        //        return View(model);
        //    }
        //}
            public async Task<IActionResult> Login_Resgiter(Login_RegisterViewModel model)
            {
                try
                {// Kiểm tra modelState.Isvalid xem có hợp lệ không 
                    if (ModelState.IsValid)
                    {       // TÌnh trang đăng nhập 
                        if (model.LoginViewModel != null)
                        {
                            var loginModel = model.LoginViewModel;
                            //Kiểm tra email 
                            bool isEmail = Utilities.IsValidEmail(loginModel.UserName);
                            if (!isEmail)
                            {
                                return View(model);
                            }
                            //Check Email
                            var customer = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == loginModel.UserName);
                            if (customer == null)
                            {
                                return RedirectToAction("Login_Resgiter", "Accounts");
                            }
                            // Kiểm tra Pasword và trạng thái
                            string pass = (loginModel.Password + customer.Salt.Trim()).ToMD5();

						    if (customer.Password != pass || !customer.Active)
                            {
                                _notyfService.Success("Thông tin đăng nhập chưa chính xác");
                                return View(model);
                            }
                        // Tạo Sesstion cho người dùng
                        customer.LastLogin = DateTime.Now;
                        _context.Update(customer);
                        await _context.SaveChangesAsync();
                        HttpContext.Session.SetString("CustomerId", customer.CustomerId.ToString());

                            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, customer.FullName),
                        new Claim("CustomerId", customer.CustomerId.ToString())
                    };
                            // Nhận một số quyền nhất định
                            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimsPrincipal);
                            // Trả về trang tài khoản của tôi
                            _notyfService.Success("Đăng nhập thành công");
                            return RedirectToAction("Index", "MyProfile");
                        }
                        // Tình trạng đăng ký
                        else if (model.RegistreViewModel != null)
                        {

                            var registerModel = model.RegistreViewModel;
                            /*Salt nãy dùng để ví dụ như hai người có cùng mật khẩu nhưng khi hash MD5 thì sẽ không 
                            bao giờ giống nhau do ta chèn thêm những kí từ trong Salt này
                            */
                            string salt = Utilities.GetRandomKey();
                            Customer khachhang = new Customer
                            {
                                FullName = registerModel.FullName,
                                Phone = registerModel.Phone.Trim().ToLower(),
                                Email = registerModel.Email.Trim().ToLower(),
                                Password = (registerModel.Password + salt.Trim()).ToMD5(),
                                Active = true,
                                Salt = salt,
                                CreateDate = DateTime.Now,
                                LastLogin = DateTime.Now
                            };
                            // Thêm  khách hàng vào CSDL
                            try
                            {
                                _context.Add(khachhang);
                                await _context.SaveChangesAsync();
                                HttpContext.Session.SetString("CustomerId", khachhang.CustomerId.ToString());
                            // Tiến hành nhận quyền như đăng nhập
                                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, khachhang.FullName),
                            new Claim("CustomerId", khachhang.CustomerId.ToString())
                        };
                                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                                await HttpContext.SignInAsync(claimsPrincipal);
                                //Trả về trang chủ 
                                _notyfService.Success("Đăng ký thành công");
                                return RedirectToAction("Index", "Home");
                            }
                            catch
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                    else
                    {
                        // ModelState không hợp lệ
                        var errors = ModelState.Values.SelectMany(v => v.Errors);
                        foreach (var error in errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exceptions
                    return RedirectToAction("Login_Resgiter", "Accounts");
                }

                // Default fallback return statement
                return View(model);
                }
        [HttpGet]
        // Đăng xuất
        public IActionResult Logout()
        {
            // Sign the user out
            HttpContext.SignOutAsync();

            // Remove any relevant session data
            HttpContext.Session.Remove("CustomerId");

            // Redirect to the home page or any other desired page
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SomeAdminAction()
        {
            if (!User.IsInRole("Admin"))
            {
                // Nếu người dùng không phải là admin, chuyển hướng hoặc từ chối truy cập
                return RedirectToAction("Index", "Home"); // Ví dụ: Chuyển hướng đến trang từ chối truy cập
            }

            // Nếu là admin, tiếp tục xử lý
            return View();
        }

    }

}




	