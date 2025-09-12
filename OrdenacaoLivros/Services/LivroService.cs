using OrdenacaoLivros.Models;
using OrdenacaoLivros.Repositories;
using System.Linq;

namespace OrdenacaoLivros.Services
{
    public class LivroService
    {
        private readonly ILivroRepository _repository;

        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public void AddLivro(Livro livro)
        {
            _repository.Adicionar(livro);
        }

        public IReadOnlyList<Livro> ListarLivros()
        {
            var livros = _repository.ListarTodos();
            if (!livros.Any())
            {
                Console.WriteLine("Não há livros cadastrados.");
            }
            return livros;
        }

        public IEnumerable<Livro> OrdenarLivros<TKey>(Func<Livro, TKey> keySelector, bool descending = false)
        {
            return descending
                ? _repository.ListarTodos().OrderByDescending(keySelector)
                : _repository.ListarTodos().OrderBy(keySelector);
        }
        
        public IEnumerable<Livro> OrdenarLivrosPorAutorETitulo()
        {
            return _repository.ListarTodos()
                .OrderBy(l => l.AuthorName)
                .ThenByDescending(l => l.Title);
        }

        public IEnumerable<Livro> OrdenarLivrosPorEdicaoAutorETitulo()
        {
            return _repository.ListarTodos()
                .OrderByDescending(l => l.EditionYear)
                .ThenByDescending(l => l.AuthorName)
                .ThenBy(l => l.Title);
        }
    }
}