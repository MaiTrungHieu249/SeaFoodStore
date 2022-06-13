using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaFoodStore.Models
{
    public interface ISeaFoodStoreRepository
    {
        IQueryable<SeaFood> SeaFoods { get; }
        void SaveBook(SeaFood b);
        void CreateBook(SeaFood b);
        void DeleteBook(SeaFood b);
    }
}
