using Entity.Contexts;
using Entity.Data;
using Microsoft.EntityFrameworkCore;
using Opration.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opration.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DBAContext _context;

        public GenericRepository(DBAContext context)
        {
            _context = context;
        }

        public void Add(T entity)
            => _context.Set<T>().Add(entity);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);

    }
}