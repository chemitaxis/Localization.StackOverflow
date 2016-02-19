using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Localization.StackOverflow.Helper;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Localization.StackOverflow.Filters
{

    //CUSTOM COOKIE LOCALIZATION

    public class LanguageCookieActionFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public const string CultureCookieName = "_culture";

        public LanguageCookieActionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("LanguageActionFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string cultureName;
            var request = context.HttpContext.Request;
            var cultureCookie = request.Cookies[CultureCookieName];

            if (cultureCookie.Any())
            {
                cultureName = cultureCookie[0];
            }
            else
            {
                cultureName = request.Headers["Accept-Language"];
                var cultures = CultureHelper.ParserHeaderAcceptedLanguage(cultureName);

                var cultureFirst = cultures?.FirstOrDefault();
                if (cultureFirst != null)
                    cultureName = cultureFirst.Value;

                cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

                context.HttpContext.Response.Cookies.Append(CultureCookieName, cultureName);

            }

            _logger.LogInformation($"Setting the culture from the URL: {cultureName}");


            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);

            base.OnActionExecuting(context);
        }
    }
}
