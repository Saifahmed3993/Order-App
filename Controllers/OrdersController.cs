using Microsoft.AspNetCore.Mvc;
using OrderApp.Models;

namespace OrderApp.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet]
        [Route("/order")]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[Route("/order")]
        //public IActionResult Index()
        //{
        //    return Content("View Found");
        //}

        [HttpPost]
        [Route("/order")]
        public IActionResult Index(
            [Bind(nameof(Order.OrderDate),
                  nameof(Order.InvoicePrice),
                  nameof(Order.Products))]
            Order order)
        {
            Console.WriteLine("===== ORDER =====");
            Console.WriteLine(order.OrderDate);
            Console.WriteLine(order.InvoicePrice);
            Console.WriteLine(order.Products.Count);

            foreach (var product in order.Products)
            {
                Console.WriteLine($"{product.ProductCode} - {product.Price} - {product.Quantity}");
            }
            if (!ModelState.IsValid)
            {
                string message = string.Join("\n",
                    ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                return BadRequest(message);
            }

            Random random = new Random();

            int randomOrderNo = random.Next(1, 99999);

            return Json(new
            {
                OrderNumber = randomOrderNo
            });
        }
    }
}