using Bangazon.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bangazon.Models
{
    public class PaymentType : IIsDeleted
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Payment Type")]
        [StringLength(55)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Account Number")]
        [StringLength(20)]
        public string AccountNumber { get; set; }

        public bool Active { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public ICollection<Order> Orders { get; set; }
        public PaymentType()
        {
            Active = true;
        }

    }
}
