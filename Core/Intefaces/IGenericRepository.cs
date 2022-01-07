using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;

namespace Core.Intefaces
{
    public  interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetbyIdSync(int Id);
        Task<IReadOnlyList<T>> ListAllSync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListASync(ISpecification<T> spec);

      
    }
}