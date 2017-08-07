using ejercicio15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejercicio15.Repository {
    public class EntradasService : IEntradasService {
        
        private IEntradasRepository entradasRepository;

        public EntradasService(IEntradasRepository _entradasRepository) {
            this.entradasRepository = _entradasRepository;
        }

        public Entrada Get(long id) {
            
            return entradasRepository.GetEntrada(id);
            
        }

        public IQueryable<Entrada> GetEntradas() {

            return entradasRepository.GetEntradas();
            
        }

        public Entrada Create(Entrada entrada) {
            
            return entradasRepository.Create(entrada);
                    
        }

        public void Put(Entrada entrada) {
            
            entradasRepository.PutEntrada(entrada);
                       
        }

        public Entrada Delete(long id) {
            
            return entradasRepository.Delete(id);
                      
        }
             
    }
}