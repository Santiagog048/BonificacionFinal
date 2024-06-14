using System.Linq;
using System.Net;
using System.Web.Mvc;
using BonificacionFinal;

namespace BonificacionFinal.Controllers
{
    public class FuncionalidadesController : Controller
    {
        private BonificacionFinalEntities db = new BonificacionFinalEntities();

        // GET: Funcionalidades/Buscar
        public ActionResult Buscar()
        {
            return View();
        }

        // POST: Funcionalidades/Buscar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buscar(string codigoCurso)
        {
            if (string.IsNullOrEmpty(codigoCurso))
            {
                ModelState.AddModelError("", "Debe ingresar un código de curso.");
                return View();
            }

            Curso curso = db.Curso.FirstOrDefault(c => c.CodigoCurso == codigoCurso);
            if (curso == null)
            {
                ModelState.AddModelError("", "Curso no encontrado.");
                return View();
            }

            return View("DetallesCurso", curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
