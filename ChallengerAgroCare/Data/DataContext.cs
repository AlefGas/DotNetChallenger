using ChallengerAgroCare.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengerAgroCare.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> Options) : base(Options)
        {
          
        }

        public DbSet<User> users { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

    }
} 
    
       

        
        
    

