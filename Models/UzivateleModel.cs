using System.ComponentModel.DataAnnotations;

namespace maturitniZadani.Models
{
    public class UzivateleModel
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public string Jmeno { get; set; } = String.Empty;


        [Required]
        public string Heslo_hashed { get; set; } = String.Empty;
    }
}
