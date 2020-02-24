using OpenIdConnect.Services;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace OpenIdConnect.Controllers
{
    public class BasketController : SurfaceController
    {
        public ActionResult AddToBasket(int id)
        {
            using(var basket = new ShoppingCartActions())
            {
                basket.AddToCart(id);
                var basketID = basket.GetCartId();
            }
            return CurrentUmbracoPage();
        }
    }
}