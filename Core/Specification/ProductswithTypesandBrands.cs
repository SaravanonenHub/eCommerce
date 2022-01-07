using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductswithTypesandBrands : BaseSpecification<Product>
    {
        public ProductswithTypesandBrands()
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }

        public ProductswithTypesandBrands(int Id) : base(x => x.Id == Id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}