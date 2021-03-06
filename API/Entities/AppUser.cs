using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string DisplayName { get; set;}
        public string? ImageUrl { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
