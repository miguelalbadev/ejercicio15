using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio15.Repository {
    public interface IEntradasRepository {

        Entrada Create(Entrada entrada);
        IQueryable<Entrada> GetEntradas();
        Entrada GetEntrada(long id);
        void PutEntrada(Entrada entrada);
        Entrada Delete(long id);
    }
}
