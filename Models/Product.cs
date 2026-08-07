using System.ComponentModel.DataAnnotations;

namespace OrderApp.Models
{
    public class Product
    {
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Product Code")]
        public int? ProductCode { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        [Display(Name = "Product Price")]

        public double Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


    }
}
