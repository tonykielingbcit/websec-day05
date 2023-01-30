using System.ComponentModel.DataAnnotations;

namespace Paypal.NET.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
