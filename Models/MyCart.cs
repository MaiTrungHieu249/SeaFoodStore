using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SeaFoodStore.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(SeaFood seafood, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.SeaFood.SeaFoodID == seafood.SeaFoodID)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    SeaFood = seafood,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(SeaFood seafood) =>
        Lines.RemoveAll(l => l.SeaFood.SeaFoodID == seafood.SeaFoodID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.SeaFood.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public SeaFood SeaFood { get; set; }
        public int Quantity { get; set; }
    }
}