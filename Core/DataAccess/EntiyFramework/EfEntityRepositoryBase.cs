using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntiyFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where  TContext: DbContext , new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext reCapContext = new TContext();
            return filter == null ? reCapContext.Set<TEntity>().ToList() : reCapContext.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext recapContext = new TContext())
            {
                return recapContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            using (TContext reCapContext = new TContext())
            {
                var addedEntity = reCapContext.Entry(entity);

                addedEntity.State = EntityState.Added;
                reCapContext.SaveChanges();
            }

        }

        public void Update(TEntity entity)
        {
            using (TContext reCapContext = new TContext())
            {
                var addedEntity = reCapContext.Entry(entity);

                addedEntity.State = EntityState.Modified;
                reCapContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext reCapContext =new TContext())
            {
                var addedEntity=reCapContext.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                reCapContext.SaveChanges();
            }
        }
    }
}
