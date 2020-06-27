using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.NET_MVC_CRUD_WITHOUT_ENTITY_FRAMEWORK.Startup))]
namespace ASP.NET_MVC_CRUD_WITHOUT_ENTITY_FRAMEWORK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
