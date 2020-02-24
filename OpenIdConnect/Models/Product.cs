using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenIdConnect.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int ProductID { get; internal set; }
    }
}