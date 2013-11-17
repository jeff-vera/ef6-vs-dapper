using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;

namespace EF_vs_Dapper
{
    public class DapperDriver
    {
        public IEnumerable<dynamic> GetLotsOfRecords()
        {
            using (var conn = new SqlConnection(
                "Server=.\\SQLEXPRESS;Database=AdventureWorks2012;Trusted_Connection=true"))
            {
                var data = 
                    conn.Query(
                    @"select TransactionID, ProductID, ReferenceOrderLineID, 
                    TransactionDate from production.transactionhistory");

                return data;
            }    
        }
    }
}
