using Microsoft.AspNetCore.Mvc;
using SeaFoodStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaFoodStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private ISeaFoodStoreRepository repository;
        public GenreNavigation(ISeaFoodStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.SeaFoods
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    } 
}
