using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class CalificacionBLL
    {
        public static void Create(Calificacion a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Aporte mt = db.Aporte.Find(a.idcalificacion);
                        Config(a, byLamda);
                        db.Calificacion.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static void Config(Calificacion calif, bool byLamda)
        {
            calif.fecha = DateTime.Now;
            if (byLamda)
            {
                foreach (var ap in calif.Aporte)
                {
                    // valor = 20.00 y el ponderado 
                    ap.puntaje = (ap.valor * ap.ponderado) / 20;
                    calif.valor += ap.puntaje;

                }
                return;
            }
            
            calif.Aporte.ToList().ForEach(ap => ap.puntaje = (ap.valor * ap.ponderado)/20);
            calif.valor = calif.Aporte.Sum(ap => ap.puntaje);
        }

        public static Calificacion Get(int? id)
        {
            Entities db = new Entities();
            return db.Calificacion.Find(id);
        }


        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Calificacion Calificacion = db.Calificacion.Find(id);
                        db.Entry(Calificacion).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Calificacion> List()
        {
            Entities db = new Entities();
            return db.Calificacion.ToList();
        }

        public static List<Calificacion> List(int id)
        {
            Entities db = new Entities();
            return db.Calificacion.Where(x => x.Matricula.idmatricula == id).ToList();
        }









    }
}
