using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bangazon.Models {
    public class OrderProduct {
        [Key]
        public int OrderProductId { get; set; }

        [Required]
        [Display(Name ="Order Number")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

      
    }
}