using System.Collections.Generic;
using System.Reflection.Emit;
using scopeAgency.Models;
using Microsoft.EntityFrameworkCore;


namespace scopeAgency.Data
{
    public class ApplicationDbContext : DbContext
    {
        //DbContext is a base class in Entity Framework Core that represents a session with the database.
        //The ApplicationDbContext class typically contains the database sets (collections of entities) and configurations needed to interact with the database in an ASP.NET application.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<unit> units { get; set; }
        public DbSet<invoiceDetail> invoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<invoiceDetail>()
                .HasOne(i => i.unit)
                .WithMany()
                .HasForeignKey(i => i.unitNo); // Configure foreign key relationship
        }
       
    }
}
