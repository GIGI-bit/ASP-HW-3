using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllByKey(string key);
        Task AddAsync(Product product);

    }
}
