using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppLab2Turma2017.Startup))]
namespace WebAppLab2Turma2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
