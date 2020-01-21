using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniteOfWork.Web.Startup))]
namespace UniteOfWork.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
