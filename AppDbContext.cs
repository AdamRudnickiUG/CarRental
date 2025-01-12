using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using CarRental.Pages.CarClasses;
namespace CarRental;

public class AppDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().ToTable("Cars");
        modelBuilder.Entity<Car>().HasKey(i => i.CarID);

        modelBuilder.Entity<Car>()
            .HasDiscriminator<string>("CarType")
            .HasValue<Car>("Car")
            .HasValue<Lorry>("Lorry")
            .HasValue<FamilyCar>("Family Car")
            .HasValue<Motorbike>("Motorbike")
            .HasValue<Van>("Van");
    }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarRental;Trusted_Connection=True;");
    }
}