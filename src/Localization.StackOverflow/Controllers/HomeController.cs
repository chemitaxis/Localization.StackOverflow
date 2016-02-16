using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localization.StackOverflow.Resources;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Localization;

namespace Localization.StackOverflow.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<Startup> _stringLocalizer;

        public HomeController(IHtmlLocalizer<Startup> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            var value = _stringLocalizer["Hello"].Value;


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
