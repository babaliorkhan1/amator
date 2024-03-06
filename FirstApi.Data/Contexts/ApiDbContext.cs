using FirstApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data.Contexts
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {
//ssssssssalam
//salam da
        }
        public DbSet<Category> Categories { get; set; } 
    }
}
