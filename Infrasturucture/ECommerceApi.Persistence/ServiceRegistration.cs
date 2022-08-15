using ECommerceApi.Application.Abstractions;
using ECommerceApi.Persistence.Concretes;
using ECommerceApi.Persistence.Contexts;
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

            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
