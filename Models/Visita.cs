using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroVisitatori.Models
{
    public class Visita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio.")]
        [StringLength(100, ErrorMessage = "Il nome può contenere al massimo 100 caratteri.")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Il cognome è obbligatorio.")]
        [StringLength(100, ErrorMessage = "Il cognome può contenere al massimo 100 caratteri.")]
        public string Cognome { get; set; } = "";

        [Required(ErrorMessage = "L’azienda è obbligatoria.")]
        [StringLength(150, ErrorMessage = "L’azienda può contenere al massimo 150 caratteri.")]
        public string Azienda { get; set; } = "";

        [Required(ErrorMessage = "La persona da incontrare è obbligatoria.")]
        [StringLength(150, ErrorMessage = "Il nome del referente può contenere al massimo 150 caratteri.")]
        public string Referente { get; set; } = "";

        [Required(ErrorMessage = "Il motivo della visita è obbligatorio.")]
        [StringLength(300, ErrorMessage = "Il motivo della visita può contenere al massimo 300 caratteri.")]
        public string MotivoVisita { get; set; } = "";

        public DateTime OraIngresso { get; set; } = DateTime.Now;

        public DateTime? OraUscita { get; set; }
    }
}