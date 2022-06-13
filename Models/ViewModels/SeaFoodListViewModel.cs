using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaFoodStore.Models.ViewModels
{
    public class SeaFoodListViewModel
    {
        public IEnumerable<SeaFood> SeaFoods { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}
