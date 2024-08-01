using Authentication.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Authentication.Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public ActionResult Login(string returnUrl) => View();

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user is null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }

        public ActionResult AccessDenied() => View();

        public ActionResult Registration() => View();

        [HttpPost]
        public async Task<ActionResult> Registration(LoginViewModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, Role.Administrator));
                return Redirect("Login");
            }

            return View(model);
        }
    }
}
