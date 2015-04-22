using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcHomeWork1.Startup))]
namespace mvcHomeWork1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
