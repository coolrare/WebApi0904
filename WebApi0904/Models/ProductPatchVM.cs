using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi0904.Models
{
    public class ProductPatchVM : IValidatableObject
    {
        public Nullable<decimal> Price { get; set; }

        [Required]
        public Nullable<decimal> Stock { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}