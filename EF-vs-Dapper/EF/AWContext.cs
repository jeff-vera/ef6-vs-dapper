using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EF_vs_Dapper.EF
{
    public class AWContext : System.Data.Entity.DbContext 
    {
        public AWContext() : base("adventureWorksConnectionString") {}

        public DbSet<TransactionHistory> TransactionHistory { get; set; }
    }
}
