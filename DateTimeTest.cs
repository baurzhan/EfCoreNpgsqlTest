using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetTopologySuite.Utilities;
using NpgsqlTypes;
using Xunit;

namespace EfCoreNpgsqlTest
{
    public class DateTimeTest
    {
        private readonly string _connectionString;

        public DateTimeTest()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build();
            _connectionString = configuration.GetConnectionString("default");
        }

        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<TestContext>()
                .UseNpgsql(_connectionString, ob => ob.UseNodaTime().UseNetTopologySuite())
                .Options;
            using (var context = new TestContext(options))
            {
                var entity = new DateTimeEntity
                {
                    Valid = new NpgsqlRange<DateTime>(DateTime.UtcNow, DateTime.MaxValue)
                };
                context.DateTimeEntities.Add(entity);
                context.SaveChanges();
            }
        }
    }
}