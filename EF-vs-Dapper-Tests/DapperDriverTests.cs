using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using EF_vs_Dapper;
using System.Diagnostics;
using EF_vs_Dapper.Dapper;

namespace EF_vs_Dapper_Tests
{
    [TestFixture]
    public class DapperDriverTests
    {
        [Test]
        public void Can_get_lots_of_records_with_new_instantiation_every_time_test()
        {
            var times = new List<double>();

            for (int i = 0; i < 40; ++i)
            {
                var sw = Stopwatch.StartNew();
                var dapperDriver = new DapperDriver();
                var rows = dapperDriver.GetLotsOfRecords<TransactionHistory>();

                Assert.That(rows, Is.Not.Null);
                Assert.That(rows.Count(), Is.GreaterThan(0));

                sw.Stop();

                times.Add(sw.ElapsedMilliseconds);
                Console.WriteLine("took {0} ms to get {1} records", 
                    sw.ElapsedMilliseconds,
                    rows.Count());
            }

            Console.WriteLine("average: {0}, min: {1}, max: {2}",
                times.Average(),
                times.Min(),
                times.Max());

            var timesSansMinAndMax = new List<double>();
            timesSansMinAndMax.AddRange(times);
            timesSansMinAndMax.Remove(timesSansMinAndMax.Min());
            timesSansMinAndMax.Remove(timesSansMinAndMax.Max());
            Console.WriteLine("average sans min & max: {0}",
                timesSansMinAndMax.Average());
        }

        [Test]
        public void Can_get_lots_of_records_with_same_object_test()
        {
            var dapperDriver = new DapperDriver();
            var times = new List<double>();

            for (int i = 0; i < 40; ++i)
            {
                var sw = Stopwatch.StartNew();
                var rows = dapperDriver.GetLotsOfRecords<TransactionHistory>();

                Assert.That(rows, Is.Not.Null);
                Assert.That(rows.Count(), Is.GreaterThan(0));

                sw.Stop();

                times.Add(sw.ElapsedMilliseconds);
                Console.WriteLine("took {0} ms to get {1} records", 
                    sw.ElapsedMilliseconds,
                    rows.Count());
            }

            Console.WriteLine("average: {0}, min: {1}, max: {2}",
                times.Average(),
                times.Min(),
                times.Max());

            var timesSansMinAndMax = new List<double>();
            timesSansMinAndMax.AddRange(times);
            timesSansMinAndMax.Remove(timesSansMinAndMax.Min());
            timesSansMinAndMax.Remove(timesSansMinAndMax.Max());
            Console.WriteLine("average sans min & max: {0}",
                timesSansMinAndMax.Average());
        }

        [Test]
        public void Can_get_few_records_test()
        {
            var dapperDriver = new DapperDriver();
            var times = new List<double>();

            for (int i = 0; i < 100; ++i)
            {
                var sw = Stopwatch.StartNew();
                var rows = dapperDriver.GetAFewRecords<TransactionHistory>();

                Assert.That(rows, Is.Not.Null);
                Assert.That(rows.Count(), Is.GreaterThan(0));

                sw.Stop();

                times.Add(sw.ElapsedMilliseconds);
                Console.WriteLine("took {0} ms to get {1} records",
                    sw.ElapsedMilliseconds,
                    rows.Count());
            }

            Console.WriteLine("average: {0}, min: {1}, max: {2}",
                times.Average(),
                times.Min(),
                times.Max());

            var timesSansMinAndMax = new List<double>();
            timesSansMinAndMax.AddRange(times);
            timesSansMinAndMax.Remove(timesSansMinAndMax.Min());
            timesSansMinAndMax.Remove(timesSansMinAndMax.Max());
            Console.WriteLine("average sans min & max: {0}",
                timesSansMinAndMax.Average());
        }
    }
}
