using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio15.Repository {
    public interface IEntradasService {

        Entrada Create(Entrada entrada);
        Entrada Get(long id);
        IQueryable<Entrada> GetEntradas();
        void Put(Entrada entrada);
        Entrada Delete(long id);
        
        
    }
}
