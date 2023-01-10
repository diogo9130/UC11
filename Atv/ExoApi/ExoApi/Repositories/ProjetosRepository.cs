using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class ProjetosRepository
    {
        private readonly SqlContext _context;
        public ProjetosRepository(SqlContext context)
        {
            _context = context;
        }
        
        public List<Projetos> Get()
        {
            return _context.Projetos.ToList();
        }
        
        public Projetos Get(int id)
        {
            return _context.Projetos.Find(id);
        }
        
        public void Delete(Projetos projeto)
        {
            _context.Projetos.Remove(projeto);
            _context.SaveChanges();
        }

        public void Cadastrar(Projetos projeto)
        {
            projeto.Data_Inicio = Convert.ToDateTime(projeto.Data_Inicio).ToString("yyyy-MM-dd");
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        public void Atualizar(Projetos projeto)
        {
            Projetos ProjetoBuscado = _context.Projetos.Find(projeto.Id);

            if (ProjetoBuscado != null)
            {
                ProjetoBuscado.Titulo = projeto.Titulo;
                ProjetoBuscado.Status = projeto.Status;
                ProjetoBuscado.Data_Inicio = projeto.Data_Inicio;
                ProjetoBuscado.Tecnologias = projeto.Tecnologias;
                ProjetoBuscado.Requisitos = projeto.Requisitos;
                ProjetoBuscado.Area = projeto.Area;
            }
            
            _context.Projetos.Update(ProjetoBuscado);
            _context.SaveChanges();
        }
    }
}
