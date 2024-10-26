using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scopeAgency.Models
{
    
    public class unit
    {
        [Key]
        public int unitNo { get; set; }
        public string unitName { get; set; }
       // public ICollection<invoiceDetail>? invoiceDetail { get; }

    }

    // Models/InvoiceDetail.cs
    public class invoiceDetail
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }  // Primary key
        [Required]
        public string productName { get; set; }
        [Precision(18, 2)]
        public decimal price { get; set; }
        public int quantity { get; set; }
        [Precision(18, 2)]
        public decimal total => price * quantity; // Calculated property

        [DataType(DataType.Date)] //It helps in rendering the appropriate UI controls in forms (date picker)

        public DateTime expiryDate { get; set; }
        [ForeignKey("unit")]
        public int unitNo { get; set; } // Foreign key property
        
        public virtual unit unit { get; set; } // Navigation property
        
      
    }

}
