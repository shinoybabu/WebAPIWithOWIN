using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAPIWithOWIN.Startup))]
namespace WebAPIWithOWIN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
