using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;


[assembly: OwinStartup(typeof(WebAPIWithOWIN.App_Start.Startup))]

namespace WebAPIWithOWIN.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var myProvider = new MyAuthrozationServerProvider();

            OAuthAuthorizationServerOptions Options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = myProvider
            };
            app.UseOAuthAuthorizationServer(Options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            
            HttpConfiguration config = new HttpConfiguration();            
            WebApiConfig.Register(config);

            //ConfigureOAuth(app);
            //app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            
        }
    }
}
