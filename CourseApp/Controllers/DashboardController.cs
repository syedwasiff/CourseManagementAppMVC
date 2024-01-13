using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public IActionResult Display()
        {
            return View();
        }
    }
}
