using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Localization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace Localization.StackOverflow.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<Startup> _stringLocalizer;

        public HomeController(IStringLocalizer<Startup> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {

            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var requestCulture = requestCultureFeature.RequestCulture;

            var provider = requestCultureFeature.Provider.GetType().Name;

            var value = _stringLocalizer["Hello"];

           

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
