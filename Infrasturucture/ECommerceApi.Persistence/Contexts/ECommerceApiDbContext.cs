using ECommerceApi.Domain.Entities;
using ECommerceApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Contexts
{
    public class ECommerceApiDbContext : DbContext
    {
        public ECommerceApiDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in datas)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedData = DateTime.Now;
                    item.Entity.Status = true;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.ModifyData = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
