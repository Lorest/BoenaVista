//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoenaVista.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Intervention
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> DateFin { get; set; }
        public Nullable<int> Id_Technicien { get; set; }
        public Nullable<int> Id_Machine { get; set; }
    
        public virtual Machine Machine { get; set; }
        public virtual Technicien Technicien { get; set; }
    }
}
