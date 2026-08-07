using OrderApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderApp.CustomValidators
{
    // Validator مسئول عن التأكد إن الأوردر فيه منتج واحد على الأقل

    public class ProductListValidator : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Order should contain at least one product";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                List<Product> products = (List<Product>)value;

                if (products.Count == 0)
                {
                    return new ValidationResult(DefaultErrorMessage, new string[] { validationContext.MemberName! });
                }
                return ValidationResult.Success;
            }
            return null;
        }


    }
}
