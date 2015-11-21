using System.Web.Http;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Diagnostics;
using Owin;

namespace OwinSslWindowsService
{
    /// <summary>
    /// Owin Startup Class
    /// </summary>
    public class OwinStartup
    {
        /// <summary>
        ///  Configuration Method for Owin
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configuration(IAppBuilder appBuilder)
        {
            //Set the Welcome page to test if Owin is hoosted properly
            appBuilder.UseWelcomePage("/welcome.html");
            appBuilder.UseErrorPage(new ErrorPageOptions() { ShowExceptionDetails = true });

            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "defaultApiRoute",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            //Maps Http routes based on attributes
            config.MapHttpAttributeRoutes();

            //Enable WebApi
            appBuilder.UseWebApi(config);
            appBuilder.UseCors(CorsOptions.AllowAll);
        }
    }
}
