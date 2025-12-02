using Microsoft.EntityFrameworkCore;

namespace PlantWorld.ApiProvider.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
    }
}
