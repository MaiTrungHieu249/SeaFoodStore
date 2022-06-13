using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeaFoodStore.Models;
using SeaFoodStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SeaFoodStore.Controllers
{
    public class HomeController : Controller
    {
        private ISeaFoodStoreRepository repository;
        public int PageSize = 3;
        public HomeController(ISeaFoodStoreRepository repo)
        {
            repository = repo;
        }
         public IActionResult Index(string genre, int seafoodPage = 1)
            => View(new SeaFoodListViewModel
         {
             SeaFoods = repository.SeaFoods
             .Where(p => genre == null || p.Genre == genre)
             .OrderBy(p => p.SeaFoodID)
             .Skip((seafoodPage - 1) * PageSize)
             .Take(PageSize),
             PagingInfo = new PagingInfo
             {
                 CurrentPage = seafoodPage,
                 ItemsPerPage = PageSize,
                 TotalItems = genre == null ?
                 repository.SeaFoods.Count() :
                 repository.SeaFoods.Where(e =>
                 e.Genre == genre).Count()
             },
             CurrentGenre = genre
         });
    }
}
    

