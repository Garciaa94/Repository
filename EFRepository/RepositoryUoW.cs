using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.Data.Entity;

namespace EFRepository
{
    public class RepositoryUoW : Repository, IRepository, IUnitOfWork, IDisposable
    {
        public RepositoryUoW(DbContext context,
            bool autoDetectChangeEnable = false,
            bool proxyCreationEnabled = false) :
            base(context, autoDetectChangeEnable, proxyCreationEnabled)
        {

        }


        protected override int TrySaveChange()
        {
            return 0;
        }
        
        int IUnitOfWork.Save()
        {
            int Result = 0;
            try
            {
                Result = Context.SaveChanges();
            }
            catch(Exception e)
            {
                throw (e);
            }
            return Result;
        }
    }
}
