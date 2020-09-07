using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace WebApiEscolastico.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CalificacionController : ApiController
    {
        public IHttpActionResult Post(Calificacion calificacion)
        {
            try
            {
                CalificacionBLL.Create(calificacion);
                return Content(HttpStatusCode.Created, "Calificacion creada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}