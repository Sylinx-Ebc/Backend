using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class PostgreSqlContext:DbContext
    {

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) { }



        public DbSet<Product> product { get; set; }

        public DbSet<Account> account { get; set; }

        public DbSet<Purchase> purchase { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Purchase>(builder =>
            //{
            //    builder.HasNoKey();
            //    builder.ToTable("purchase");
            //});
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }
}
