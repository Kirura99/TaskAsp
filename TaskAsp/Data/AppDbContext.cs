using TaskAsp.Models;
using Microsoft.EntityFrameworkCore;


namespace TaskAsp.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Client>()
         .HasMany(c => c.Orders)
         .WithOne(o => o.Client!)
         .HasForeignKey(o => o.ClientId)
         .OnDelete(DeleteBehavior.Cascade);

        b.Entity<Order>()
         .HasOne(o => o.Product!)
         .WithMany()
         .HasForeignKey(o => o.ProductId)
         .OnDelete(DeleteBehavior.Restrict);
    }
}
