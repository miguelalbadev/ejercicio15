﻿using ejercicio15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejercicio15.Repository {
    public class EntradasService : IEntradasService {

        public static ApplicationDbContext applicationDbContext;

        private IEntradasRepository entradasRepository;

        public EntradasService(IEntradasRepository _entradasRepository) {
            this.entradasRepository = _entradasRepository;
        }

        public Entrada Create(Entrada entrada) {

            using (var context = new ApplicationDbContext()) {

                applicationDbContext = context;

                using(var dbContextTransaction = context.Database.BeginTransaction()) {

                    try {
                        entrada = entradasRepository.Create(entrada);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch(Exception e) {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transacción",e);
                    }
                    

                }
            }
            return entrada;
        }
    }
}