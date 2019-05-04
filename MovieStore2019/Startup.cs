using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieStore2019.Startup))]
namespace MovieStore2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
