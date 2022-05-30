using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Hora
    {
        public int HoraId { get; set; }

        [Required(ErrorMessage = "Horário da Sessão é obrigatório")]
        [Display(Name = "Horário da Sessão")]
        [StringLength(5)]
        [RegularExpression(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$", ErrorMessage = "Formato invalido (HH:MM)")]
        public string Horario { get; set; }
    }
}
