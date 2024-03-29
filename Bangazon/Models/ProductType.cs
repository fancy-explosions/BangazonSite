using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Bangazon.Models
{
  public class ProductType
  {
    [Key]
    public int ProductTypeId { get; set; }

    [Required]
    [StringLength(255)]
    
    public string Label { get; set; }

    [NotMapped]
    public int Quantity { get; set; }

        public int CategoryQuantity
        {
            get
            {
                return Products.Count();
            }
        }

    public virtual ICollection<Product> Products { get; set; }
  }
}
