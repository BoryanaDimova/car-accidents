using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarAccidents.Startup))]
namespace CarAccidents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
