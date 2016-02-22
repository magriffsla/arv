using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Arvelia.EF7.Sqlite.Repo
{
    

    public class Repo<TEntity>:IRepo<TEntity> where TEntity:class,IEntity
    {
        private const string ERR_NULL_ENTITY = @"entity can not be empty";
        private DbContext ctx;
        private DbSet<TEntity> db
        {
            get { return ctx.Set<TEntity>(); }
        }
        public Repo(DbContext context)
        {
            ctx = context;
        }
        public IEnumerable<TEntity> getAll()
        {
            return db.ToList();
        }
        /// <summary>
        /// add entity to repo
        /// </summary>
        /// <param name="entity"></param>
        public void add(TEntity entity)
        {
            try
            {
                PreventNullEntity(entity);
                db.Add(entity);
            }
            finally
            {
                ctx.SaveChanges();

            }
        }

        private static void PreventNullEntity(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(ERR_NULL_ENTITY);
            }
        }

        public void delete(TEntity entity)
        {
            try
            {
                PreventNullEntity(entity);
                db.Remove(entity);
            }
            finally
            {
                ctx.SaveChanges();
            }
        }
        public void update(TEntity entity)
        {
            try
            {
                PreventNullEntity(entity);
                db.Update(entity);
            }
            finally
            {
                ctx.SaveChanges();
            }
        }
        public TEntity get(int id)
        {
            return getAll()
                .Where(entity => entity.Id == id)
                .FirstOrDefault();
        }
    }
}
