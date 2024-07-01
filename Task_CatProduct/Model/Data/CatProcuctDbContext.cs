using Microsoft.EntityFrameworkCore;

namespace Task_CatProduct.Model.Data
{
    public class CatProcuctDbContext : DbContext
    {
        public CatProcuctDbContext(DbContextOptions<CatProcuctDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
