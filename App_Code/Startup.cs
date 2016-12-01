using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GardenSpaceCalculator.Startup))]
namespace GardenSpaceCalculator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
