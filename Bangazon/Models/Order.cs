using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bangazon.Models
{
    public class Order
    {
        [Key]
        [Display(Name ="Order Number")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime? DateCompleted { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }

}



