using Microsoft.AspNetCore.Mvc;

namespace QuizPortal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }


        
    }
}
