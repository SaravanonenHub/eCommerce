using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Data;
using Core.Entities;
using Core.Intefaces;
using Core.Specification;
using eCommerceAPI.Dtos;
using eCommerceAPI.Errors;
using eCommerceAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<ProductType> _productstypeRepo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsbrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productsbrandRepo
        , IGenericRepository<ProductType> productstypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productsbrandRepo = productsbrandRepo;
            _productsRepo = productsRepo;
            _productstypeRepo = productstypeRepo;


        }

        [HttpGet]
        public async Task<ActionResult<Pagination<IReadOnlyList<Product>>>> GetProducts(
            [FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductswithTypesandBrands(productParams);
            var countspec = new ProductswithFiltesForCountSpecification(productParams);
            var totalItems = await _productsRepo.CountAsync(countspec);
            var products = await _productsRepo.ListASync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDtos>>(products);
            return Ok(new Pagination<ProductToReturnDtos>(productParams.PageIndex
            ,productParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDtos>> GetProduct(int id)
        {
            var spec = new ProductswithTypesandBrands(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product,ProductToReturnDtos>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            return Ok(await _productsbrandRepo.ListAllSync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            return Ok(await _productstypeRepo.ListAllSync());
        }
    }
}