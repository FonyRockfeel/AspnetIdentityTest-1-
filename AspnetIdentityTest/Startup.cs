using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspnetIdentityTest.Startup))]
namespace AspnetIdentityTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
