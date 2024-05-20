using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengerAgroCare.Models
{
    [Table("Tabela_Postagem_Grex_1")]
    public class Postagem
    {
         
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User? User { get; set; }
        [Required]
        public int Like { get; set; } = 0;
        [Required]
        [Column("Texto_Postagem")]
        public string TxtPost { get; set; }
        [Required]
        [Column("Data_Do_Post")]
        public DateTime PostDate { get; set; }= DateTime.Now;
        public ICollection<Comentario>? Comentarios { get; set; }
    }
}

