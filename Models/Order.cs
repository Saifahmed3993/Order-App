using OrderApp.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace OrderApp.Models
{
    public class Order
    {
        public int? OrderNumber { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [MinimumDateValidator("2027-01-01")]
        public DateTime OrderDate { get; set; }


        [Required]
        [Range(1, double.MaxValue)]
        [Display(Name = "Invoice Price")]
        [InvoicePriceValidator]
        public double InvoicePrice { get; set; }

        [ProductListValidator]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
