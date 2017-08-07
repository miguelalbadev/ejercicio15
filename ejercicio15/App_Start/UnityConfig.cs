using ejercicio15.Repository;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Data.Entity.Infrastructure.Interception;
using System.Web.Http;
using Unity.WebApi;
using System;
using System.Collections.Generic;
using ejercicio15.Models;

namespace ejercicio15
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<Interception>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<IEntradasService, EntradasService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<DbInterceptor>());
            container.RegisterType<IEntradasRepository, EntradasRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public class DbInterceptor : IInterceptionBehavior {

            public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext) {
                
                // Invoke the next behavior in the chain.
                IMethodReturn result;
                if(ApplicationDbContext.applicationDbContext == null) {
                    using (var context = new ApplicationDbContext()) {

                        ApplicationDbContext.applicationDbContext = context;

                        using (var dbContextTransaction = context.Database.BeginTransaction()) {
                            try {

                                result = getNext()(input, getNext);

                                if (result.Exception != null) {
                                    throw new Exception("Ocurrió una excepción" + result.Exception);
                                }
                                context.SaveChanges();
                                dbContextTransaction.Commit();
                            }
                            catch (Exception e) {
                                dbContextTransaction.Rollback();
                                throw new Exception("He hecho rollback de la transacción", e);
                            }
                        }


                    }
                    ApplicationDbContext.applicationDbContext = null;
                    return result;
                }
                else {
                    result = getNext()(input, getNext);

                    if (result.Exception != null) {
                        throw new Exception("Ocurrió una excepción" + result.Exception);
                    }
                   
                    return result;
                }
                
                                
            }

            public IEnumerable<Type> GetRequiredInterfaces() {
                return Type.EmptyTypes;
            }

            public bool WillExecute {
                get { return true; }
            }

            private void WriteLog(string message) {
    
            }

            
        }

    }
}