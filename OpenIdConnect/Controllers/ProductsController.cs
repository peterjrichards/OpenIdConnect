using OpenIdConnect.Models;
using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace OpenIdConnect.Controllers
{
    public class ProductsController : UmbracoApiController
    {
        [HttpGet()]
        [Route("products/all")]

        public IHttpActionResult GetAll()
        {
            if (!Members.IsLoggedIn() || !Members.IsMemberAuthorized(allowGroups: new[] { "Test" }))
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.Forbidden);
            }

            return Ok(new[]
            {
                new Product { Name = "Oil Filter" },
                new Product { Name = "Brake Cable" },
                new Product { Name = "Air Filter" }
            });
        }
    }

}
