using EF_vs_Dapper.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EF_vs_Dapper
{
    public class EFDriver
    {
        private AWContext _context;

        public EFDriver()
        {
            _context = new AWContext();
            Database.SetInitializer<AWContext>(null);
        }
        public IEnumerable<TransactionHistory> GetLotsOfRecords()
        {
            var data = from x in _context.TransactionHistory
                        select x;

            return data.ToList();
        }


        public IEnumerable<TransactionHistory> GetAFewRecords()
        {
            var data = from x in _context.TransactionHistory
                       where x.Quantity > 1000
                       select x;
         
            return data.ToList();
        }
    }
}
