using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }
        public ContatoModel BuscarPorID(int id) 
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> GetContatos()
        {
            return _context.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //INSERÇÃO NO BD
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorID(contato.Id);
            if (contatoDB == null) throw new System.Exception("Erro na att do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;
            
            _context.Contatos.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = BuscarPorID(id);
            if (contatoDB == null) throw new System.Exception("Erro na att do contato");
            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();
            return true;
        }
    }
}
