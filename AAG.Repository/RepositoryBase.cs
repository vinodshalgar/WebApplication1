using AAG.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAG.Repository
{    
    /// <summary>
    /// following code inforces that class is
   ///  inheriting from DbContext
    /// and has default constructor
    /// </summary>
    /// <typeparam name="C"></typeparam>
    public class RepositoryBase<C> : IDisposable
        where C : DbContext, IDisposedTracker,new()
    {
        private C _DataContext;

        public virtual C DataContext
        {
            get
            {
                if(_DataContext== null)
                {
                    _DataContext = new C();                    
                }
                return _DataContext;
            }          
                        
        }

        public virtual OperationStatus Save<T>(T entity) where T : class
        {
            OperationStatus opStatus = new OperationStatus { Status = true };
            try
            {
                opStatus.Status = DataContext.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                opStatus = OperationStatus.CreateFromException("Error Saving " + typeof(T) + "." , ex);
            }
            return opStatus;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
