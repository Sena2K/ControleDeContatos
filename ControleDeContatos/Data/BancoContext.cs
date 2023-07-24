using ControleDeContatos.Models;    
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=./;Database=DbContatos;User ID=sa;Password=_43690;TrustServerCertificate=true");
        }

        public DbSet<ContatoModel> Contatos { get; set; }   

    }
}
    