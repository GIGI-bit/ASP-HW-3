using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Repositories.Interfaces;

namespace WebApplication3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
          await _productRepository.AddAsync(product);
        }

        public async Task<List<Product>> GetAllByKey(string key)
        {
            return await _productRepository.GetAllAsync(key);

        }
    }
}
