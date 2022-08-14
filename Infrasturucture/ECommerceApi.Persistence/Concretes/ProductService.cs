using ECommerceApi.Application.Abstractions;
using ECommerceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        => new()
        {
            new() {Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock= 15, Status = true },
            new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 50, Stock= 18, Status = true },
            new() {Id = Guid.NewGuid(), Name = "Product 3", Price = 55.5, Stock= 25, Status = true },
            new() {Id = Guid.NewGuid(), Name = "Product 4", Price = 12, Stock= 30, Status = false },
            new() {Id = Guid.NewGuid(), Name = "Product 5", Price = 15.4, Stock= 12, Status = true },
            new() {Id = Guid.NewGuid(), Name = "Product 6", Price = 150, Stock= 19, Status = false },
            new() {Id = Guid.NewGuid(), Name = "Product 7", Price = 80, Stock= 10, Status = true },
            new() {Id = Guid.NewGuid(), Name = "Product 8", Price = 66, Stock= 10, Status = true },
        };
    }
}
