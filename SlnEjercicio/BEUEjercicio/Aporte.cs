//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUEjercicio
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aporte
    {
        public int idaporte { get; set; }
        public Nullable<decimal> puntaje { get; set; }
        public Nullable<decimal> valor { get; set; }
        public Nullable<decimal> ponderado { get; set; }
        public Nullable<int> idcalificacion { get; set; }
        public string nombre { get; set; }
    
        public virtual Calificacion Calificacion { get; set; }
    }
}