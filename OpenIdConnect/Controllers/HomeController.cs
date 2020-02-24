using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace OpenIdConnect.Controllers
{
    public class HomeController : RenderMvcController
    {
        public override ActionResult Index(ContentModel model)
        {
            var httpSession = HttpContext.Session;
            var umbracoSesson = UmbracoContext.HttpContext.Session;
            var homeAccess = Members.MemberHasAccess("/home");
            return View(model);
        }
    }
}