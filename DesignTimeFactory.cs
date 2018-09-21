using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EfCoreNpgsqlTest
{
    public class DesignTimeFactory : 
        IDesignTimeDbContextFactory<TestContext>
    {
        private readonly string _connectionString;

        public DesignTimeFactory()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build();
            _connectionString = configuration.GetConnectionString("default");
        }

        TestContext IDesignTimeDbContextFactory<TestContext>.CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            optionsBuilder.UseNpgsql(_connectionString, ob => ob.UseNodaTime().UseNetTopologySuite());
            return new TestContext(optionsBuilder.Options);
        }
        
        
    }
}