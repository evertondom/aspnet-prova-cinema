using System.ComponentModel.DataAnnotations;
namespace Cinema.Models
{
    public class Sessao
    {
        [Key]
        public int SessaoId { get; set; }

        [Required(ErrorMessage ="Número da Sala é obrigatório")]
        [Range(1,5, ErrorMessage = "Número inválido, Escolha entre 1 e 5")]
        [Display(Name ="Número da Sala")]
        public int NumSala { get; set; }

    }
}
