using OrdenacaoLivros.Models;
using OrdenacaoLivros.Services;
using OrdenacaoLivros.Repositories;




var repository = new LivroRepository();
var service = new LivroService(repository);


AdicionarLivrosIniciais(service);


ExibirListaOrdenada("Listar Livros sem ordenação:", service.ListarLivros());
ExibirListaOrdenada("Livros Ordenados por Título:", service.OrdenarLivros(l => l.Title));
ExibirListaOrdenada("Livros Ordenados por Autores Ascendentes e Titulos Descendentes:", service.OrdenarLivrosPorAutorETitulo());
ExibirListaOrdenada("Livros Ordenados por Edição descendente, Autores descendentes e Titulos ascendentes:", service.OrdenarLivrosPorEdicaoAutorETitulo());


void AdicionarLivrosIniciais(LivroService livroService)
{
    livroService.AddLivro(new Livro("Java How to Program", "Deitel & Deitel", 2007));
    livroService.AddLivro(new Livro("Patterns of Enterprise Application Architecture", "Martin Flower", 2002));
    livroService.AddLivro(new Livro("Head First Design Patterns", "Elisabeth Freeman", 2004));
    livroService.AddLivro(new Livro("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007));
}


void ExibirListaOrdenada(string titulo, IEnumerable<Livro> livros)
{
    Console.WriteLine(titulo);
    foreach (var livro in livros)
    {
        Console.WriteLine(livro);
    }
        ConsoleHelper.PrintSeparator(); 
}
