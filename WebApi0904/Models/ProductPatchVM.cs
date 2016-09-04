using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi0904.Models
{
    public class ProductPatchVM
    {
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<decimal> Stock { get; set; }
    }
}