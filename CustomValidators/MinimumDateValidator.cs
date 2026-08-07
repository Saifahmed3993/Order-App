using System.ComponentModel.DataAnnotations;

namespace OrderApp.CustomValidators
{
    // عملنا Class جديد يرث من ValidationAttribute
    // ليه؟
    // لأننا عايزين نعمل Validation خاص بينا مش موجود في .NET
    // هنستخدمه بالشكل ده:
    // [MinimumDateValidator("2000-01-01")]
    public class MinimumDateValidator : ValidationAttribute
    {
        // رسالة الخطأ الافتراضية
        // {0} مكانها هيتحط التاريخ
        // مثال:
        // Order date should be greater than or equal to 2000-01-01

        public string DefaultErrorMessage { get; set; } = "Order date should be greater than or equal to {0}";

        // أقل تاريخ مسموح بيه
        // هيبقى مثلاً 2000-01-01
        public DateTime MinimumDate { get; set; }

        // Constructor
        // بيتنفذ أول ما ASP.NET يشوف
        // [MinimumDateValidator("2000-01-01")]
        public MinimumDateValidator(string minimumDateString)
        {
            // ليه استقبلنا String؟
            // لأن C# Attributes مينفعش تستقبل DateTime مباشرة
            // لذلك بنستقبله كنص

            // minimumDateString = "2000-01-01"

            // نحوله إلى DateTime ونخزنه
            MinimumDate = Convert.ToDateTime(minimumDateString);

            // بعد السطر ده
            // MinimumDate = 2000-01-01
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                // value نوعها object
                // وإحنا محتاجين DateTime
                // لذلك بنعمل Cast
                DateTime orderDate = (DateTime)value;

                // أصبح
                // orderDate = 1999-05-10

                // Ensure we're comparing in UTC or use Date only (ignore time zone)
                // This prevents timezone-related validation issues
                DateTime orderDateOnly = orderDate.Date;
                DateTime minimumDateOnly = MinimumDate.Date;

                // دلوقتي نقارن
                if (orderDateOnly < minimumDateOnly)
                {

                    // لو التاريخ اللي المستخدم دخله
                    // أصغر من 2000

                    // يبقى Validation فشل
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumDate.ToString("yyyy-MM-dd")),
                        new string[] { validationContext.MemberName });
                }
                return ValidationResult.Success;

            }
            return null;

        }

    }

}
