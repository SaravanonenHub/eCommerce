using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data;
using Core.Entities;
using Core.Intefaces;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetbyIdSync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

       

        public async Task<IReadOnlyList<T>> ListAllSync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await AddSpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> ListASync(ISpecification<T> spec)
        {
            return await AddSpecification(spec).ToListAsync();
        }

        public IQueryable<T> AddSpecification(ISpecification<T> spec)
        {
            return SpecficationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);
        }
    }
}