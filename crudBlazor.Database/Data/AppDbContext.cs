using crudBlazor.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace crudBlazor.Database.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ProductModel> Products { get; set; }
}
