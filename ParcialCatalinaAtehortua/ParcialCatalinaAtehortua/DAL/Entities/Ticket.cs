using System.ComponentModel.DataAnnotations;

namespace ParcialCatalinaAtehortua.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name ="Fecha de uso")]
        public DateTime? UseDate { get; set; }
        [Display(Name ="Ocupada")]
        public bool IsUsed { get; set; }
        [Display(Name ="Portería")]
        [Required]
        [MaxLength(20)]
        public string? EntranceGate { get; set; }

    }
}
