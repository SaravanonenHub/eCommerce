using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Intefaces
{
    public interface IProductRepository
    {
         Task<Product> GetProductbyIdAsync(int Id);
         Task<IReadOnlyList<Product>> GetProducts();
         Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
         Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
    }
}