using OrdenacaoLivros.Models;
using System.Collections.Generic;

namespace OrdenacaoLivros.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly List<Livro> _livros = new();

        public void Adicionar(Livro livro)
        {
            _livros.Add(livro);
        }

        public void ListarSemOrdenacao()
        {
            return;
        }

        public IReadOnlyList<Livro> ListarTodos()
        {
            return _livros.AsReadOnly();
        }
    }
}