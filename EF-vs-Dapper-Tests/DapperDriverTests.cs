using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using EF_vs_Dapper;
using System.Diagnostics;

namespace EF_vs_Dapper_Tests
{
    [TestFixture]
    public class DapperDriverTests
    {
        [Test]
        public void Can_get_lots_of_records_with_new_instantiation_every_time_test()
        {
            for (int i = 0; i < 40; ++i)
            {
                var sw = Stopwatch.StartNew();
                var dapperDriver = new DapperDriver();
                var rows = dapperDriver.GetLotsOfRecords();

                Assert.That(rows, Is.Not.Null);
                Assert.That(rows.Count(), Is.GreaterThan(0));

                sw.Stop();

                Console.WriteLine("took {0} ms to get {1} records", 
                    sw.ElapsedMilliseconds,
                    rows.Count());
            }
        }

        [Test]
        public void Get_lots_of_records_with_same_object_test()
        {
            var dapperDriver = new DapperDriver();

            for (int i = 0; i < 40; ++i)
            {
                var sw = Stopwatch.StartNew();
                var rows = dapperDriver.GetLotsOfRecords();

                Assert.That(rows, Is.Not.Null);
                Assert.That(rows.Count(), Is.GreaterThan(0));

                sw.Stop();

                Console.WriteLine("took {0} ms to get {1} records", 
                    sw.ElapsedMilliseconds,
                    rows.Count());
            }
        }
    }
}
