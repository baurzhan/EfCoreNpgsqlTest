using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace EfCoreNpgsqlTest
{
    public class TestContext : DbContext
    {

       
        static TestContext()
        {
        }

        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InstantEntity> InstantEntities { get; set; }
        private void CreateAppModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstantEntity>(entity =>
            {
                entity.ToTable("instant_entities", "public");
                entity.HasKey(e => new {e.Id}).HasName("date_time_entity_pk");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Valid).HasColumnName("valid");
            });
        }
    }
}