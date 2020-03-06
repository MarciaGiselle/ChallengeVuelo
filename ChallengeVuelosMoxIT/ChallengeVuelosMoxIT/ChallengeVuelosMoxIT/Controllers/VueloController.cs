using Modelo;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChallengeVuelosMoxIT.Controllers
{
    public class VueloController : Controller
    {
        VueloServicio vueloServicio = new VueloServicio();

        public ActionResult Crear(int id)
        {
            Vuelo v = new Vuelo();

            if (id != 0 && ! id.Equals(null))
            {
                v = vueloServicio.GetById(id);
                if(v == null)
                {
                    TempData["VueloInvalido"] = true;
                    return RedirectToAction("Listar", "Vuelo");
                }
            }

            return View(v);
            
        }

        [HttpPost]
        public ActionResult Crear(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                if (vuelo.Id.Equals(null)  || vuelo.Id == 0)
                {
                    vueloServicio.Crear(vuelo);
                }
                else
                {
                    vueloServicio.Modificar(vuelo);
                }
                TempData["CreacionCorrecta"] = true;
                return RedirectToAction("Listar", "Vuelo");
            }

            return View(vuelo);
        }

        public ActionResult Listar()
        {
            if (TempData["VueloInvalido"] != null)
                ViewBag.VueloInvalido = "No existe el vuelo solicitado.";
            if (TempData["CreacionCorrecta"] != null)
                ViewBag.CreacionCorrecta = "Se han guardado los cambios correctamente.";
            if (TempData["EliminacionCorrecta"] != null)
                ViewBag.EliminacionCorrecta = "Se ha eliminado el vuelo.";
            return View(vueloServicio.Listar());
        }

        [HttpPost]
        public ActionResult EliminarVuelo(int id)
        {
            vueloServicio.Eliminar(id);
            TempData["EliminacionCorrecta"] = true;
            return RedirectToAction("Listar", "Vuelo");
        }

        public ActionResult Error(int error = 0)
        {
            switch (error)
            {
                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar...";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La dirección que está intentando ingresar no existe.";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Lo sentimos, algo salio muy mal :( ..";
                    break;
            }


            return View("Error");
        }

    }
}
