using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RequestFlow.Infrastructrure
{
    public class RedirectModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.MapRequestHandler += (src, args) =>
            {
                RouteValueDictionary rvd = app.Context.Request.RequestContext.RouteData.Values;

                if (Compare(rvd, "controller", "Home") && Compare(rvd, "action", "Authenticate"))
                {
                    string url = UrlHelper.GenerateUrl("", "Index", "Home", rvd, RouteTable.Routes,
                        app.Context.Request.RequestContext, false);
                }
            };
        }

        private bool Compare(RouteValueDictionary rvd, string key, string value)
        {
            return string.Equals((string) rvd[key], value, StringComparison.OrdinalIgnoreCase);
        }

        public void Dispose()
        { }
    }
}