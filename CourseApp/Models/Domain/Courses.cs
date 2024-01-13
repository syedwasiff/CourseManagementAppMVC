namespace CourseApp.Models.Domain
{
    public class Courses
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CoursePrice { get; set; }
        public bool IsActive { get; set; }
    }
}
