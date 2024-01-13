using CourseApp.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly DatabaseContext databaseContext;
        private readonly UserManager<ApplicationUser> userManager;        

        public OrderController(DatabaseContext databaseContext, UserManager<ApplicationUser> userManager)
        {
            this.databaseContext = databaseContext;
            this.userManager = userManager;
        }
        private string Userid { get; set; }

        [Authorize]
        [HttpGet]
        public IActionResult Order()
        {            
            var orders = databaseContext.Orders.Where(x => x.CustomerId == userManager.GetUserId(HttpContext.User).ToString()).OrderByDescending(x => x.BuyingDate).ToList();
            return View(orders);
        }

        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult OrdersAdmin()
        {
            var orders = databaseContext.Orders.OrderByDescending(x => x.BuyingDate).ToList();
            return View(orders);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public JsonResult ChangeStatus(string status, Guid Id)
        {
            var fetcheddata = databaseContext.Orders.Find(Id);
            if (fetcheddata != null) {
                fetcheddata.Status = status;
                databaseContext.SaveChanges();
            }
                        
            return Json(new {done="done"});
        }
    }
}
