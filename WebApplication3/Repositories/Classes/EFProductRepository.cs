using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.DataContext;
using WebApplication3.Entities;
using WebApplication3.Repositories.Interfaces;

namespace WebApplication3.Repositories.Classes
{
    public class EFProductRepository : IProductRepository
    {

        private readonly ProductDbContext _context;

        public EFProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync(string key = "")
        {
            var keyCode = key.Trim().ToLower();
            return key==""?await _context.Products.ToListAsync(): await _context.Products.Where(i=>i.Name.ToLower().Contains(keyCode)).ToListAsync();   
        }
    }
}
