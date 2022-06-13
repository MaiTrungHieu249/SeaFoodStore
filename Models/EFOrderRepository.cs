using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeaFoodStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private SeaFoodStoreDbContext context;
        public EFOrderRepository(SeaFoodStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.SeaFood);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.SeaFood));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
