using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Repository
{
   public interface IRepository: IDisposable // Liberaacion de recursos no Administrable 
    {

        // crear metodo Agregar
        TEntity Create<TEntity>(TEntity newTEntity) where TEntity : class;

        //actualizar
        bool Update<TEntity>(TEntity modifiedTEntity) where TEntity : class;

        //eliminar
        bool Delete<TEntity>(TEntity deleteTEntity) where TEntity : class;

        //buscar
        TEntity FinEntity<TEntity>(Expression<Func<TEntity,bool>>criteria) where TEntity : class;
        IEnumerable<TEntity>FindEntitySet<TEntity>
            (Expression<Func<TEntity,bool>>criteria) where TEntity : class;
    }
}
