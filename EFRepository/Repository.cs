using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Repository;
using System.Data.Entity;


namespace EFRepository
{
    public class Repository :IRepository,IDisposable
    {
        protected DbContext Context;
        public Repository(DbContext context,
            bool autoDetectChangesEnabled= false,
            bool proxyCreationEnabled = false)
        {
            this.Context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            this.Context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
        public TEntity Create<TEntity>(TEntity newTEntity) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = Context.Set<TEntity>().Add(newTEntity);
                TrySaveChange();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        private static TEntity NewMethod<TEntity>() where TEntity : class
        {
            return null;
        }

        protected virtual int TrySaveChange()
        {
            return Context.SaveChanges();
        }

        public bool Delete<TEntity>(TEntity deleteTEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(deleteTEntity);
                Context.Set<TEntity>().Attach(deleteTEntity);
                Result = TrySaveChange() > 0;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindEntitySet<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            List<TEntity> Result = null;
            try
            {
                Result = Context.Set<TEntity>().Where(criteria).ToList();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        public TEntity FinEntity<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = Context.Set<TEntity>().FirstOrDefault(criteria);
                
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        public bool Update<TEntity>(TEntity modifiedTEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(modifiedTEntity);
                Context.Entry<TEntity>(modifiedTEntity).State=EntityState.Modified;
                Result = TrySaveChange() < 0;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }
    }
}
