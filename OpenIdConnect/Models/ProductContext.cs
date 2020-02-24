using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenIdConnect.Models
{
    public class ProductContext
    {
        public IList<Product> Products { get; internal set; }
        public IList<CartItem> ShoppingCartItems { get; internal set; }

        internal void SaveChanges()
        {
            
        }

        internal void Dispose()
        {
          
        }
    }
}