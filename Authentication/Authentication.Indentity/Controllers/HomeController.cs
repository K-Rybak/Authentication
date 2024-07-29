using Microsoft.AspNetCore.Mvc;

namespace Authentication.Identity.Conrollers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}