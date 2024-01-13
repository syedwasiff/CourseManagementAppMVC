using CourseApp.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public CoursesController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult Courses()
        {
            var Courses = databaseContext.Courses.ToList();
            return View(Courses);            
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddCourse()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult SaveCourse(Courses courses)
        {
            var newCourse = new Courses()
            {
                CourseName = courses.CourseName,
                Description = courses.Description,
                CoursePrice = courses.CoursePrice,
                Department = courses.Department,
                CreatedDate = DateTime.Now,
                IsActive = true,
            };
            databaseContext.Courses.Add(newCourse);
            databaseContext.SaveChanges();

            return RedirectToAction("Courses");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult View(Guid Id)
        {
            var course = databaseContext.Courses.Find(Id);
            if (course != null)
            {
                var updateViewmodel = new VMCourses()
                {
                    CourseName = course.CourseName,
                    Description = course.Description,
                    CoursePrice = course.CoursePrice,
                    Department = course.Department,
                    CreatedDate = course.CreatedDate                    
                };
                return View(updateViewmodel);
            }
            return RedirectToAction("Courses");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult UpdateCourse(Courses courses)
        {
            var fetchdata = databaseContext.Courses.Find(courses.Id);
            if (fetchdata != null)
            {
                fetchdata.CourseName = courses.CourseName;
                fetchdata.Description = courses.Description;
                fetchdata.CoursePrice = courses.CoursePrice;
                fetchdata.Department = courses.Department;
                fetchdata.CreatedDate = courses.CreatedDate;
                fetchdata.IsActive = true;                
            }
            databaseContext.SaveChanges();
            return RedirectToAction("Courses");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult DeleteCourse(Courses courses)
        {
            var fetchdata = databaseContext.Courses.Find(courses.Id);
            if (fetchdata != null)
            {
                databaseContext.Courses.Remove(fetchdata);
            }
            databaseContext.SaveChanges();
            return RedirectToAction("Courses");
        }
    }
}
