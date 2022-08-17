using ECommerceApi.Application.Reposteries.CustomerRepositories;
using ECommerceApi.Application.Reposteries.OrderRepositories;
using ECommerceApi.Application.Reposteries.ProductRepositories;
using ECommerceApi.Persistence.Contexts;
using ECommerceApi.Persistence.Reposteries.CustomerRepositories;
using ECommerceApi.Persistence.Reposteries.OrderRepositories;
using ECommerceApi.Persistence.Reposteries.ProductRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

        }
    }
}
