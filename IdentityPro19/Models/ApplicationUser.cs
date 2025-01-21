using Microsoft.AspNetCore.Identity;

namespace IdentityPro19.Models
{
    public class ApplicationUser:IdentityUser
    {
        public Genders Gender { get; set; }    
        public enum Genders{ male, female} 
    }
}
