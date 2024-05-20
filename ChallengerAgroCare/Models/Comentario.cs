using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengerAgroCare.Models
{
    [Table("Tabela_Comentario_Grex_1")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
  
        [ForeignKey("UserId")]
        public int? UseId { get; set; }
        public User? User { get; set; }
        
        public int? PostId { get; set; }
        
        [ForeignKey("PostagemId")]
        public Postagem? Post { get; set; }
        [Required]
        [Column("Texto_Do_Comentario")]
        public string TxtComment { get; set; }
        [Required]
        [Column("Data_Do_Comentario")]
        public DateTime CommentDate { get; set; }= DateTime.Now;
        [Required]
        [Column("Like_Comentario")]
        public int Like { get; set; } = 0;
    }
}
