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
        protected DbContext context;
        public Repository(DbContext context,
            bool autoDetectChangeEnable= false,
             bool proxyCreationEnabled = false)
        {
            this.context.Configuration.AutoDetectChangesEnabled = autoDetectChangeEnable;
            this.context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
        public TEntity create<TEntity>(TEntity newTEntity) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = context.Set<TEntity>().Add(newTEntity);
                TrySaveChange();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result; 
        }

        protected virtual int TrySaveChange()
        {
            return context.SaveChanges();
        }

        public bool delete<TEntity>(TEntity deleteTEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                context.Set<TEntity>().Attach(deleteTEntity);
                context.Set<TEntity>().Attach(deleteTEntity);
                Result = TrySaveChange() < 0;
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
                Result = context.Set<TEntity>().Where(criteria).ToList();
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
                Result = context.Set<TEntity>().FirstOrDefault(criteria);
                
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
                context.Set<TEntity>().Attach(modifiedTEntity);
                context.Entry<TEntity>(modifiedTEntity).State=EntityState.Modified;
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
