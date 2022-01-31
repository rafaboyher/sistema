using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaFaculdade.Startup))]
namespace SistemaFaculdade
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
