using System.Globalization;
using Localization.StackOverflow.Filters;
using Localization.StackOverflow.Resources;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Localization;
using Localization.StackOverflow.Helper;
using Microsoft.AspNet.Http;
using System;
using Microsoft.Extensions.WebEncoders;

namespace Localization.StackOverflow.Controllers
{
    //[ServiceFilter(typeof(LanguageCookieActionFilter))]
    public class HomeController : Controller
    {
        public const string CultureCookieName = "_cultureLocalizationStackOverflow";

        private readonly IStringLocalizer<StackOverflowLoc> _stringLocalizer;
        private readonly IHtmlEncoder _encoder;

        public HomeController(IStringLocalizer<StackOverflowLoc> stringLocalizer, IHtmlEncoder encoder)
        {
            _stringLocalizer = stringLocalizer;
            _encoder = encoder;
        }

        public IActionResult Index()
        {

            ViewData["Hello"] = _stringLocalizer["Hello"];
            ViewData["Parameter"] = _stringLocalizer["Parameter"];
            return View();
        }

        [HttpPost]
        public IActionResult SetCulture(string culture)
        {

           HttpContext.Response.Cookies.Append(CultureCookieName, culture, new CookieOptions
            {
                Expires = DateTime.Now.AddYears(1),
                Secure = false,
                
            });
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
