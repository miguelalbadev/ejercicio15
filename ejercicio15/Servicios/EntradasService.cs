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

            Entrada resultado;

            using (var context = new ApplicationDbContext()) {

                ApplicationDbContext.applicationDbContext = context;                

                using (var dbContextTransaction = context.Database.BeginTransaction()) {

                    try {
                        resultado = entradasRepository.GetEntrada(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception e) {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }

                }
                ApplicationDbContext.applicationDbContext = null;
                return resultado;
            }

        }

        public IQueryable<Entrada> GetEntradas() {

            IQueryable<Entrada> resultado;

            using (var context = new ApplicationDbContext()) {

                ApplicationDbContext.applicationDbContext = context;

                using (var dbContextTransaction = context.Database.BeginTransaction()) {

                    try {
                        resultado = entradasRepository.GetEntradas();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception e) {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }

                }
                ApplicationDbContext.applicationDbContext = null;
                return resultado;
            }

        }

        public Entrada Create(Entrada entrada) {

            using (var context = new ApplicationDbContext()) {

                ApplicationDbContext.applicationDbContext = context;

                using(var dbContextTransaction = context.Database.BeginTransaction()) {
                    try {
                        entrada = entradasRepository.Create(entrada);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch(Exception e) {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }
                
                
            }
            ApplicationDbContext.applicationDbContext = null;
            return entrada;
        }

        public void Put(Entrada entrada) {
            using(var context = new ApplicationDbContext()) {

                ApplicationDbContext.applicationDbContext = context;

                using(var dbContextTransaction = context.Database.BeginTransaction()) {
                    try {
                        entradasRepository.PutEntrada(entrada);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch(Exception e) {
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }
            }
            ApplicationDbContext.applicationDbContext = null;
        }

        public Entrada Delete(long id) {

            Entrada resultado;

            using(var context = new ApplicationDbContext()) {
                ApplicationDbContext.applicationDbContext = context;
                using(var dbContextTransaction = context.Database.BeginTransaction()) {
                    try {
                        resultado = entradasRepository.Delete(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch(Exception e) {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción", e);
                    }
                }
            }
            ApplicationDbContext.applicationDbContext = null;
            return resultado;
        }

        

        

        
    }
}