using OrdenacaoLivros.Models;

namespace OrdenacaoLivros.Repositories
{
    public interface ILivroRepository
    {
        void Adicionar(Livro livro);
        IReadOnlyList<Livro> ListarTodos();

        void ListarSemOrdenacao();
    }
}