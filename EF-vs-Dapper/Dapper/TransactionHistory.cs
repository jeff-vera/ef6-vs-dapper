using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_vs_Dapper.Dapper
{
    public class TransactionHistory
    {
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int ReferenceOrderLineID { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
