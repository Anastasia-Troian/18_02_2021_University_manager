using _18_02_2021_University_manager.Helpers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_18_02_2021_University_manager.Startup))]
namespace _18_02_2021_University_manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeederDatabase.SeedDate();
        }
    }
}
