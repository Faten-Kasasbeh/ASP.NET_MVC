using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_authentication2.Startup))]
namespace MVC_authentication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
