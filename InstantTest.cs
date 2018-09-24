using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NodaTime;
using Npgsql.Logging;
using NpgsqlTypes;
using Optiro.Data.Tests;
using Xunit;
using Xunit.Abstractions;

namespace EfCoreNpgsqlTest
{
    public class InstantTest
    {
        private readonly string _connectionString;

        public InstantTest(ITestOutputHelper outputHelper)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build();
            _connectionString = configuration.GetConnectionString("default");
            //NpgsqlLogManager.Provider = new NpgsqlLogginProvider(outputHelper);
            //NpgsqlLogManager.IsParameterLoggingEnabled = true;
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