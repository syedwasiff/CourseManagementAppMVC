namespace CourseApp.Models.Domain
{
    public class Orders
    {
        public Guid Id { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CoursePrice { get; set; }
        public string CustomerId { get; set; }
        public string CourseBuyerName { get; set; }
        public string CourseBuyerEmail { get; set; }
        public DateTime BuyingDate { get; set; }
        public string Status { get; set; }
    }
}
