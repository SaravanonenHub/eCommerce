using AutoMapper;
using Core.Entities;
using eCommerceAPI.Dtos;
using Microsoft.Extensions.Configuration;

namespace eCommerceAPI.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDtos, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDtos destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}