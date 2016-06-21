using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebToIdentity2.Startup))]
namespace WebToIdentity2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
