using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeaFoodStore.MyTagHelper;
using SeaFoodStore.Models;
using System.Linq;
namespace SeaFoodStore.Pages
{
    public class MyCartModel : PageModel
    {
        private ISeaFoodStoreRepository repository;
        public MyCartModel(ISeaFoodStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long seafoodId, string returnUrl)
        {
            SeaFood seafood = repository.SeaFoods
            .FirstOrDefault(b => b.SeaFoodID == seafoodId);
            myCart.AddItem(seafood, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long seafoodId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.SeaFood.SeaFoodID == seafoodId).SeaFood);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}