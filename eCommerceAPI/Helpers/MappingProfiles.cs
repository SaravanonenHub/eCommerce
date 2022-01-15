using AutoMapper;
using Core.Entities;
using eCommerceAPI.Dtos;

namespace eCommerceAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDtos>()
            .ForMember(d => d.ProductBrand,o => o.MapFrom(e => e.ProductBrand.Name))
            .ForMember(d => d.ProductType,o => o.MapFrom(e => e.ProductType.Name));
        }
    }
}