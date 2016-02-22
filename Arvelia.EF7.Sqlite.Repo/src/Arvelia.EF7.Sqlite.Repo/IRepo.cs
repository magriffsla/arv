using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arvelia.EF7.Sqlite.Repo
{
    public interface IRepo<T> where T : class, IEntity
    {
        IEnumerable<T> getAll();
        void add(T entity);
        void delete(T entity);
        void update(T entity);
        T get(int id);
    }
}
