using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaFoodStore.Models
{
    public class SeaFoodStoreDbContext : DbContext
    {
        public SeaFoodStoreDbContext(DbContextOptions<SeaFoodStoreDbContext>
       options)
        : base(options) { }
        public DbSet<SeaFood> SeaFoods { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
