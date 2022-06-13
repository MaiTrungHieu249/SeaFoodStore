using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace SeaFoodStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            SeaFoodStoreDbContext context =
           app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<SeaFoodStoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.SeaFoods.Any())
            {
                context.SeaFoods.AddRange(
                new SeaFood
                {
                    Title = "Hàu nướng phô mai",
                    weight = "1Kg",
                    Genre = "Sò",
                    Price = 2m
                },
                new SeaFood
                {
                    Title = "Tôm Hùm Nướng",
                    weight = "1Kg",
                    Genre = "Tôm",
                    Price = 50m
                },
                new SeaFood
                {
                    Title = "Cua AlasKa  hấp xã",
                    weight = "1Kg",
                    Genre = "Cua",
                    Price = 100m
                },
                new SeaFood
                {
                    Title = "Bạch Tuộc sống chấm mù tạt",
                    weight = "1Kg",
                    Genre = "Mực",
                    Price = 10m
                },
                new SeaFood
                {
                    Title = "Tôm thẻ mắm nhỉ",
                    weight = "1kg",
                    Genre = "Tôm",
                    Price = 5m
                }
                );
                context.SaveChanges();
            }
        }
    }
}