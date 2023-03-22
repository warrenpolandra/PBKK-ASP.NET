using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCMenu.Startup))]
namespace MVCMenu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
