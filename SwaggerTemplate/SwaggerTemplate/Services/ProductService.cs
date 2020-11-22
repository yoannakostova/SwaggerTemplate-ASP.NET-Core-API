using Microsoft.EntityFrameworkCore;
using SwaggerTemplate.Database;
using SwaggerTemplate.Models;
using SwaggerTemplate.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerTemplate.Services
{
    public class ProductService : IProductService
    {
        private readonly SwaggerTemplateDbContext context;

        public ProductService(SwaggerTemplateDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await this.context.Products.AddAsync(product);
            await this.context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var productFromDb = await this.context.Products.FirstOrDefaultAsync(product => product.Id == product.Id);
            productFromDb.Name = product.Name;
            productFromDb.Price = product.Price;
            productFromDb.Category = product.Category;

            this.context.Products.Update(productFromDb);

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            this.context.Products.Remove(product);

            return true;
        }
    }
}
