using Microsoft.AspNet.Mvc;

namespace HelloMars.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Key1Val = Startup.ConfigurationProvider["Key1"];
            ViewBag.InfoMailId = Startup.ConfigurationProvider["AppSetting:MailSettings:AdminMailId"];
            return View();
        }
    }
}
