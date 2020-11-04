using Employee.BLL.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.DAL.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Save();
    }
}
