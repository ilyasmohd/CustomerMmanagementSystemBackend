using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagementSystem.DatabaseLayer.DbEntities
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Value { get; set; }
        public int State { get; set; }

        [ForeignKey("Customers")]
        public Int64 CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
