﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ejercicio15;
using ejercicio15.Models;
using ejercicio15.Repository;

namespace ejercicio15.Controllers
{
    public class EntradasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IEntradasService entradasService;

        
        public EntradasController(IEntradasService _entradasService) {
            this.entradasService = _entradasService;
        }

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return entradasService.GetEntradas();
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada entrada = entradasService.Get(id);
            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrada.Id)
            {
                return BadRequest();
            }
            
            try
            {
                entradasService.Put(entrada);
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error en el método PUT ", e.InnerException);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            entrada = entradasService.Create(entrada);

            return CreatedAtRoute("DefaultApi", new { id = entrada.Id }, entrada);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            Entrada entrada;
            try {
                entrada = entradasService.Delete(id);
            }
            catch(Exception e) {
                throw new Exception("Ocurrió un error durante el método DELETE ", e.InnerException);
            }
            return Ok(entrada);
        }

    }
}