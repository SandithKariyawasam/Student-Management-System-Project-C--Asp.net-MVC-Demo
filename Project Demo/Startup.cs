using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_Demo.Startup))]
namespace Project_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
