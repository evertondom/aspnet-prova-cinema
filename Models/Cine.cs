using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Cine
    {
        [Key]
        public int CinemaId { get; set; }

        [Required(ErrorMessage ="Local é obrigatório")]
        [Display(Name ="Local do Cinema")]
        [StringLength(50, MinimumLength =10, ErrorMessage ="Local inválido.")]
        public string LocalCinema {get; set;}
    }
}
