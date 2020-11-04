using Employee.BLL.GenericRepository;
using Employee.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.DAL.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CDContext _context;
        private Dictionary<Type, object> repos;
        public UnitOfWork(CDContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repos == null)
            {
                repos = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repos.ContainsKey(type))
            {
                repos[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)repos[type];
        }
    }
}
