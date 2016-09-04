using System;

namespace WebApi0904.Models
{
    public class ProductPatchVM
    {
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Stock { get; set; }
    }
}