using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengerAgroCare.Models
{
    [Table("Tabela_Usuarios_Grex_1")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Nome_Do_Usuario")]
        public string Name { get; set; }
        [Required]
        [Column("Avatar_Do_Usuario")]
        public string Avatar { get; set; } = "https://avatars.githubusercontent.com/u/121618159?v=4";
        [Required]
        [Column("Senha_Do_Usuario")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [Column("Email_Do_Usuario")]
        public string UserEmail { get; set; }
        [Required]
        [Column("Data_Do_Cadastro")]
        public DateTime RegisterDate { get; set; }= System.DateTime.Now;
        [Required]
        [Column("Usuario_Ativo")]
        public int IsActive { get; set; } = 1;
        public ICollection<Postagem>? Postagens { get; set; }
        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
