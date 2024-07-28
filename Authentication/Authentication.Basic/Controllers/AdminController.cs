using Microsoft.AspNetCore.Mvc;

namespace Authentication.Basic.Conrollers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}