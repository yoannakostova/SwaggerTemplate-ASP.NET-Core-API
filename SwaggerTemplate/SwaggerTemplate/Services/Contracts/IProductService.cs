using SwaggerTemplate.Models;
using System.Threading.Tasks;

namespace SwaggerTemplate.Services.Contracts
{
    public interface IProductService
    {
        public Task<Product> GetProduct(int id);
        public Task<Product> CreateProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(int id);
    }
}
