using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NodaTime;
using NpgsqlTypes;
using Xunit;

namespace EfCoreNpgsqlTest
{
    public class InstantTest
    {
        private readonly string _connectionString;

        public InstantTest()
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
                .UseNpgsql(_connectionString, ob => ob.UseNodaTime())
                .Options;
            using (var context = new TestContext(options))
            {
                var entity = new InstantEntity
                {
                    Valid = new NpgsqlRange<Instant>(Instant.FromDateTimeUtc(DateTime.UtcNow), Instant.MaxValue )
                };
                context.InstantEntities.Add(entity);
                context.SaveChanges();
            }
        }
    }
}