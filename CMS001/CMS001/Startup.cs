using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMS001.Startup))]
namespace CMS001
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
