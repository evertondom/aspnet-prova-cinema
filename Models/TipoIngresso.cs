using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class TipoIngresso
    {
        public int TipoIngressoId { get; set; }

        [Required(ErrorMessage = "Escolha o tipo do ingresso")]
        [Display(Name = "Tipo do Ingresso")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Informe um tipo válido.")]
        public string TIngresso { get; set; }
    }
}
