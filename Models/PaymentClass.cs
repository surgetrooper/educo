using System.ComponentModel.DataAnnotations;

namespace Payment_trial.Models
{
    public class PaymentClass
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Customer name must be less than 100 characters")]
        public string Customername { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number must be 10 digits")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Total amount must be greater than zero")]
        public double TotalAmount { get; set; }

    }
}
