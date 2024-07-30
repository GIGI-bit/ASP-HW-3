using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(string key="");
        Task AddAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task DeleteAsync(Product product);

        Task UpdateAsync(Product product, int id);

    }
}
