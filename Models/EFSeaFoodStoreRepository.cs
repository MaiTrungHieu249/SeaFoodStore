using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaFoodStore.Models
{
    public class EFSeaFoodStoreRepository : ISeaFoodStoreRepository
    {
        private SeaFoodStoreDbContext context;
        public EFSeaFoodStoreRepository(SeaFoodStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<SeaFood> SeaFoods => context.SeaFoods;
        public void CreateBook(SeaFood b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteBook(SeaFood b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
        public void SaveBook(SeaFood b)
        {
            context.SaveChanges();
        }
    }
}
