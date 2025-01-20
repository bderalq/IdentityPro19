using System.ComponentModel.DataAnnotations;

namespace IdentityPro19.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Email Address")]
        [Display(Name = "Email")]
        [EmailAddress]
        [MinLength(5)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
