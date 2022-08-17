using ECommerceApi.Application.Reposteries.CustomerRepositories;
using ECommerceApi.Domain.Entities;
using ECommerceApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Reposteries.CustomerRepositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ECommerceApiDbContext context) : base(context)
        {
        }
    }
}
