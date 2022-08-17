using ECommerceApi.Application.Reposteries;
using ECommerceApi.Domain.Entities.Common;
using ECommerceApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Persistence.Reposteries
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceApiDbContext _context;

        public ReadRepository(ECommerceApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table 
            => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true) 
            => tracking == true ? Table : Table.AsNoTracking();

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
            //=> await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            => tracking == true ? await Table.FindAsync(Guid.Parse(id)): await Table.AsNoTracking().FirstOrDefaultAsync( x => x.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true) 
            => tracking == true ? await Table.FirstOrDefaultAsync(method): await Table.AsNoTracking().FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true) 
            => tracking == true ? Table.Where(method): Table.Where(method).AsNoTracking();
    }
}
