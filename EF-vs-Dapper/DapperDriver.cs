using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using EF_vs_Dapper.Dapper;

namespace EF_vs_Dapper
{
    public class DapperDriver
    {
        private const string _connectionString =
            "Server=.\\SQLEXPRESS;Database=AdventureWorks2012;Trusted_Connection=true";

        public IEnumerable<T> GetLotsOfRecords<T>()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var data = 
                    conn.Query<T>(
                    @"select TransactionID, ProductID, ReferenceOrderLineID, 
                    TransactionDate from production.transactionhistory");
                                    
                return data;
            }    
        }

        public IEnumerable<T> GetAFewRecords<T>()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var data =
                    conn.Query<T>(
                    @"select TransactionID, ProductID, ReferenceOrderLineID, 
                    TransactionDate from production.transactionhistory
                    where quantity > 1000");

                return data;
            }
        }
    }
}
