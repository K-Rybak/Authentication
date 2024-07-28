using Microsoft.AspNetCore.Mvc;

namespace Authentication.Basic.Conrollers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}