using ECommerceApi.Application.Reposteries.OrderRepositories;
using ECommerceApi.Domain.Entities;
using ECommerceApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Reposteries.OrderRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ECommerceApiDbContext context) : base(context)
        {
        }
    }
}
