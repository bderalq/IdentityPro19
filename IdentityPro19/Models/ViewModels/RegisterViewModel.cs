using System.ComponentModel.DataAnnotations;
using Humanizer;
using static IdentityPro19.Models.ApplicationUser;

namespace IdentityPro19.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter Email Address")]
        [Display(Name = "Email")]
        [EmailAddress]
        [MinLength(5)]
        public string Email { get; set; }   

        [Required(ErrorMessage = "Enter Confirm Email Address")]
        [EmailAddress]
        [Display(Name = "Confirm Email")]
        [Compare("Email",ErrorMessage ="Email not match")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not match")]
        public string ConfirmPassword { get; set; }

        public string? Mobile { get; set; }  

        public Genders Gender{ get; set; }  

    }
}
