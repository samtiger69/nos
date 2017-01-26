using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nosee.Startup))]
namespace nosee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
