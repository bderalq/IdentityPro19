using System.Data;
using IdentityPro19.Models;
using IdentityPro19.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
// program, controller, appdbcontext to change from identityuser to applicationuser, add more columns to the DB.
namespace IdentityPro19.Controllers
{
    public class AccountController : Controller
    {
        #region InjectedServices
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        #endregion
        #region Users
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.Mobile,
                    Gender = model.Gender
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("RolesList", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(model);
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("RolesList", "Account");
                }
                ModelState.AddModelError("", "Invalid user or password");
                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout(LoginViewModel model)
        {

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region roles 
        public async Task<IActionResult> RolesList()
        {
            return View(roleManager.Roles);
            #endregion
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {

                    Name = model.RoleName
                };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RolesList", "Account");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            EditViewModel view = new EditViewModel { RoleId = role.Id, RoleName = role.Name };

            var names = await userManager.GetUsersInRoleAsync(role.Name);

            var users = names.Select(u => u.UserName).ToList();

            var model = new EditViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Names = users  
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.RoleId);
                role.Name = model.RoleName;
                await roleManager.UpdateAsync(role);
                return RedirectToAction("RolesList");
            };
             return View(model);        
        }
    }
}