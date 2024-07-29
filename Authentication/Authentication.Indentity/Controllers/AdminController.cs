using Authentication.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Identity.Conrollers
{
    [Authorize(Policy = nameof(Role.Administrator))]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}