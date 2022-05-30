using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Assento
    {
        public int AssentoId { get; set; }

        [Required(ErrorMessage = "Número do Assento é obrigatório")]
        [Range(1, 30, ErrorMessage = "Número inválido, Escolha entre 1 e 30")]
        [Display(Name = "Número do Assento")]
        public int NumAssento { get; set; }
    }
}
