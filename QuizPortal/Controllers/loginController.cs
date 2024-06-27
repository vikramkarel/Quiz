using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using QuizPortal.Data;
using QuizPortal.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuizPortal.Controllers
{

    public class loginController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<loginController> _logger;
        public loginController(ApplicationDbContext db,ILogger<loginController> logger)
        {
            _db = db;
            _logger = logger;

        }
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/"); // Default return URL if not provided

            if (ModelState.IsValid)
            {
                var user = await _db.loginSignUp.FirstOrDefaultAsync(u => u.UserName == UserName && u.Password == Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.User_Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true, // Remember user authentication
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Cookie expiration
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    _logger.LogInformation("User {UserName} logged in at {Time}.", user.UserName, DateTime.UtcNow);
                    if (user.Role == "SuperAdmin")
                    {
                        // Redirect to SuperAdmin dashboard
                        return RedirectToAction("SuperAdminDashboard");
                    }
                    else if (user.Role == "Admin")
                    {
                        // Redirect to Admin dashboard
                        return RedirectToAction("AdminDashboard");
                    }
                    else if (user.Role == "Quizzer")
                    {
                        // Redirect to Employee dashboard
                        return RedirectToAction("QuizzerDashboard");
                    }

                    return LocalRedirect(returnUrl); // Redirect to the returnUrl
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            // If we reach here, something failed. Redisplay the page with errors.
            return login();
        }
        


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoginSignUp obj)
        {
            _db.loginSignUp.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("login");
        }

        public IActionResult SuperAdminDashboard()
        {
            return View();
        }

        public IActionResult QuizzerDashboard()
        {
            return View();
        }

        public IActionResult QuizProfile()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }


        public IActionResult CreateQuiz()
        {
            return View();
        }


    }



}
