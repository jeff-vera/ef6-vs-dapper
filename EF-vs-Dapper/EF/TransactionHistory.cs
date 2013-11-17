using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EF_vs_Dapper.EF
{
    [Table("TransactionHistory", Schema="Production")]
    public class TransactionHistory
    {
        [Key]
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int ReferenceOrderLineID { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
