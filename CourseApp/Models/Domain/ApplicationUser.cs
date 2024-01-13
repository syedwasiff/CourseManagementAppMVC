using Microsoft.AspNetCore.Identity;

namespace CourseApp.Models.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
