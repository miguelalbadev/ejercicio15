using ejercicio15;
using ejercicio15.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ejercicio15.Repository {

    public class EntradasRepository : IEntradasRepository {

       
        public Entrada Create(Entrada entrada) {
            return ApplicationDbContext.applicationDbContext.Entradas.Create();                
        }

        public Entrada GetEntrada(long id) {

            return ApplicationDbContext.applicationDbContext.Entradas.Find(id);

        }

        public IQueryable<Entrada> GetEntradas() {
            IList<Entrada> lista = new List<Entrada>(ApplicationDbContext.applicationDbContext.Entradas);
            return lista.AsQueryable();

        }

        public void PutEntrada(Entrada entrada) {
            if (ApplicationDbContext.applicationDbContext.Entradas.Count(e => e.Id == entrada.Id) == 0) {
                throw new Exception("No he encontrado la entidad ");
            }
            ApplicationDbContext.applicationDbContext.Entry(entrada).State = EntityState.Modified;
        }

        public Entrada PostEntrada(Entrada entrada) {
            return ApplicationDbContext.applicationDbContext.Entradas.Add(entrada);
        }

        public Entrada Delete(long id) {
            Entrada entrada = ApplicationDbContext.applicationDbContext.Entradas.Find(id);
            if (entrada == null) {
                throw new Exception("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entradas.Remove(entrada);
            return entrada;
            
        }
    }
}