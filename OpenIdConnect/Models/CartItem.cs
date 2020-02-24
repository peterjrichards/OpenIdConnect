using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenIdConnect.Models
{
    public class CartItem
    {
        public string ItemId { get; internal set; }
        public int ProductId { get; internal set; }
        public string CartId { get; internal set; }
        public object Product { get; internal set; }
        public DateTime DateCreated { get; internal set; }
        public int Quantity { get; internal set; }
    }
}