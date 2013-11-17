using EF_vs_Dapper.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EF_vs_Dapper
{
    public class EFDriver
    {
        public IEnumerable<TransactionHistory> GetLotsOfRecords()
        {
            var context = new AWContext();
            Database.SetInitializer<AWContext>(null);

            var data = from x in context.TransactionHistory
                        select x;

            return data;
        }
    }
}
