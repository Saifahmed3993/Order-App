using OrderApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection; // عشان أستخدم Reflection (PropertyInfo)

namespace OrderApp.CustomValidators
{
    // Custom Validation مخصوص للفاتورة
    public class InvoicePriceValidator : ValidationAttribute
    {
        // رسالة الخطأ الافتراضية
        public string DefaultErrorMessage { get; set; } =
        "InvoicePrice doesn't match with the total cost of the specified products in the order.";

        // Tolerance for floating-point comparison (0.01 for currency)
        private const double EPSILON = 0.01;

        // ASP.NET بينادي على الميثود دي أثناء Model Validation
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // value = قيمة InvoicePrice فقط
            // مثال:
            // InvoicePrice = 160

            if (value != null)
            {
                // نحول object إلى double
                // قبل:
                // value = object
                //
                // بعد:
                // invoicePrice = 160

                double invoicePrice = (double)value;



                // ======================================================
                // دلوقتي محتاج أوصل للـ Products
                // المشكلة:
                // أنا واقف عند InvoicePrice فقط
                // ومش معايا Products
                // ======================================================



                // validationContext.ObjectType
                // بترجع نوع الـ Model الحالي
                //
                // هنا هترجع:
                //
                // Order
                //
                // بعد كده
                //
                // GetProperty(nameof(Order.Products))
                //
                // يعني:
                // هاتلي الـ Property اللي اسمها Products
                //
                // النتيجة:
                // property بيمثل الـ Products Property
                //
                // ولسه مجبتش قيمتها

                PropertyInfo? property =
                    validationContext.ObjectType.GetProperty(nameof(Order.Products));



                // ======================================================
                // دلوقتي هنجيب قيمة Products
                // ======================================================

                // validationContext.ObjectInstance
                // ده الـ Order الحالي

                // property.GetValue(...)
                //
                // معناها:
                //
                // هات قيمة Products من الـ Order الحالي

                List<Product> products =
                    (List<Product>)property.GetValue(validationContext.ObjectInstance)!;

                /*
                   بعد السطر ده

                   products =

                   [
                       Product1,
                       Product2
                   ]
                */



                // ======================================================
                // هنحسب مجموع الفاتورة
                // ======================================================

                double totalPrice = 0;

                foreach (Product product in products)
                {
                    // كل لفة

                    // Price × Quantity

                    totalPrice += product.Price * product.Quantity;
                }

                /*
                    مثال

                    Product1

                    Price =15

                    Quantity =10

                    totalPrice =150


                    Product2

                    Price =2

                    Quantity =5

                    totalPrice =160
                */



                // ======================================================
                // نقارن
                // ======================================================

                if (Math.Abs(invoicePrice - totalPrice) > EPSILON)
                {
                    // لو الفاتورة اللي المستخدم كتبها
                    // مختلفة عن اللي إحنا حسبناه
                    // مع السماح بفرق صغير جداً (EPSILON) للدقة العددية

                    return new ValidationResult(

                        ErrorMessage ?? DefaultErrorMessage,

                        // الخطأ يخص InvoicePrice
                        new[]
                        {
                            validationContext.MemberName!
                        }

                    );
                }

                // لو الاتنين متساويين
                return ValidationResult.Success;
            }

            // لو InvoicePrice = null
            // سيب [Required] هو اللي يطلع الخطأ
            return null;
        }
    }
}