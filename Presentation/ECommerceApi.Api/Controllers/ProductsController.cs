using ECommerceApi.Application.Reposteries.ProductRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task WriteDatas()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 10", CreatedData = DateTime.Now, Status = true, Price = 150, Stock = 20 },
                new() {Id = Guid.NewGuid(), Name = "Product 10", CreatedData = DateTime.Now, Status = true, Price = 151, Stock = 25 },
                new() {Id = Guid.NewGuid(), Name = "Product 10", CreatedData = DateTime.Now, Status = true, Price = 152, Stock = 30 },
                new() {Id = Guid.NewGuid(), Name = "Product 10", CreatedData = DateTime.Now, Status = true, Price = 153, Stock = 35 }
            });

            var count = await _productWriteRepository.SaveAsnyc();
        }
    }
}
