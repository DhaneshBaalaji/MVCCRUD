using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RESTAURANTCRUDAUTH.Startup))]
namespace RESTAURANTCRUDAUTH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
