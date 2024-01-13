using CourseApp.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CourseApp.Controllers
{
    public class BuyCoursesController : Controller
    {
        private readonly DatabaseContext databaseContext;

        private readonly UserManager<ApplicationUser> userManager;       

        public BuyCoursesController(DatabaseContext databaseContext, UserManager<ApplicationUser> userManager)
        {
            this.databaseContext = databaseContext;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult BuyCourses()
        {
            var buycourses = databaseContext.Courses.ToList();
            List<VMCourses> courseList = new List<VMCourses>();

            foreach (var item in buycourses)
            {
                courseList.Add(new VMCourses
                {
                    CourseName = item.CourseName,
                    CoursePrice = item.CoursePrice,
                    Description = item.Description,
                    Id = item.Id
                });
            }
            return View(courseList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Cart(Guid Id)
        {
            var neworder = new Orders()
            {
                CourseId = Id.ToString()
            };
            return View(neworder);
        }

        [Authorize]
        [HttpPost]
        public IActionResult OrderSubmit(Orders orders)
        {
            Orders neworderdata = new Orders(); 
            var coursedetail = databaseContext.Courses.Where(x => x.Id == Guid.Parse(orders.CourseId)).FirstOrDefault();
            if (coursedetail != null)
            {
                neworderdata.CourseName = coursedetail.CourseName;
                neworderdata.CourseId = coursedetail.Id.ToString();
                neworderdata.CourseDescription = coursedetail.Description;
                neworderdata.CoursePrice = coursedetail.CoursePrice;
                neworderdata.CourseBuyerName = orders.CourseBuyerName;
                neworderdata.CourseBuyerEmail = orders.CourseBuyerEmail;
                neworderdata.CustomerId = userManager.GetUserId(HttpContext.User);
                neworderdata.BuyingDate = DateTime.Now;
                neworderdata.Status = "Pending";

                databaseContext.Orders.Add(neworderdata);
            }
            databaseContext.SaveChanges();
            return RedirectToAction("OrderSuccess", new { id = neworderdata.Id });
        }

        [Authorize]
        [HttpGet]
        public IActionResult OrderSuccess(Guid Id)
        {         
            ViewBag.Id = Id;
            return View(Id);
        }

    }
}
