using ejercicio15;
using ejercicio15.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ejercicio15.Repository {

    public class EntradasRepository : IEntradasRepository {

        [ThreadStatic]
        public static ApplicationDbContext context;

        public Entrada Create(Entrada entrada) {

            return context.Entradas.Add(entrada);
            
        }

        public Entrada GetEntrada(long id) {

            return context.Entradas.Find(id);

        }

        public IQueryable<Entrada> GetEntradas() {
            IList<Entrada> lista = new List<Entrada>(context.Entradas);
            return lista.AsQueryable();

        }

        public void PutEntrada(long id, Entrada entrada) {
            context.Entry(entrada).State = EntityState.Modified;
        }

        public Entrada PostEntrada(Entrada entrada) {
            return context.Entradas.Add(entrada);
        }

        public Entrada DeleteEntrada(long id) {
            Entrada entrada = context.Entradas.Find(id);
            if (entrada == null) {
                return null;
            }
            else {
                return context.Entradas.Remove(entrada);
            }
        }
    }
}