using maturitniZadani.Data;
using System.ComponentModel.DataAnnotations;

namespace maturitniZadani.Models
{
    public class PoznamkyModel


         
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public string MajitelId { get; set; } = String.Empty;

        [Required]
        public string Nadpis { get; set; } = String.Empty;

        [Required]
        public string Obsah { get; set; } = String.Empty;


        [Required]
        public DateTime CasPridani { get; set; } = DateTime.Now;

        [Required]
        public bool JeDulezita { get; set; } = false;
    }
}
