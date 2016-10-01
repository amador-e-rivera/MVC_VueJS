using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_VueJS.Data_Access_Layer
{
    public interface IRepository <T, K>
    {
        T GetByID(K id);
        IList<T> GetAll();
        bool Update(T model);
        bool Create(T model);
        bool Delete(K id);
    }
}
