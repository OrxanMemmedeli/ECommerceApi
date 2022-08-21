using ECommerceApi.Application.Reposteries.ProductRepositories;
using ECommerceApi.Application.RequestParameters;
using ECommerceApi.Application.ViewModels;
using ECommerceApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ECommerceApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]Pagination pagination)
        {
            var count = _productReadRepository.GetAll(false).Count();
            var products = await _productReadRepository.GetAll(false).Select(x => new
            {
                x.Id,
                x.Name,
                x.Stock,
                x.Price,
                x.CreatedData,
                x.ModifyData
            }).Skip(pagination.Page*pagination.Size).Take(pagination.Size)
                .ToListAsync();


            return Ok(new
            {
                products,
                count
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var products = await _productReadRepository.GetByIdAsync(id, false);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_Create_Product product)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            });
            await _productWriteRepository.SaveAsnyc();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);

            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;

            await _productWriteRepository.SaveAsnyc();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsnyc(id);

            await _productWriteRepository.SaveAsnyc();
            return Ok();
        }
    }
}
