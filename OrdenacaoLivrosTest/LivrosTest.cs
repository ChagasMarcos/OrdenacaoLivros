using OrdenacaoLivros.Models;
using OrdenacaoLivros.Services;
using OrdenacaoLivros.Repositories;
using Moq;

namespace OrdenacaoLivrosTest
{
    public class LivrosTest
    {
        [Fact]
        public void AddLivro_DeveAdicionarLivroNaLista()
        {
            // Arrange
            var mockRepository = new Mock<ILivroRepository>();
            var service = new LivroService(mockRepository.Object);
            var livro = new Livro("Java How to Program", "Deitel & Deitel", 2007);

            // Act
            service.AddLivro(livro);

            // Assert
            // Verifica se o método Adicionar do repositório foi chamado exatamente uma vez
            mockRepository.Verify(repo => repo.Adicionar(livro), Times.Once);
        }

        [Fact]
        public void OrdenarLivrosPorTitulo_DeveOrdenarCorretamente()
        {
            // Arrange
            var livrosDesordenados = new List<Livro>
            {
                new Livro ("Java How to Program", "Deitel & Deitel", 2007),
                new Livro ("Patterns of Enterprise Application Architecture", "Martin Flower", 2002),
                new Livro ("Head First Design Patterns", "Elisabeth Freeman", 2004),
                new Livro ("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007)
            };

            var mockRepository = new Mock<ILivroRepository>();
            // Configura o mock para retornar a lista desordenada quando o método ListarTodos for chamado
            mockRepository.Setup(repo => repo.ListarTodos()).Returns(livrosDesordenados);
            var service = new LivroService(mockRepository.Object);

            // Act
            var resultado = service.OrdenarLivros(l => l.Title).ToList();

            // Assert
            Assert.Equal("Head First Design Patterns", resultado[0].Title);
            Assert.Equal("Internet & World Wide Web: How to Program", resultado[1].Title);
            Assert.Equal("Java How to Program", resultado[2].Title);
            Assert.Equal("Patterns of Enterprise Application Architecture", resultado[3].Title);
        }

        // Os outros testes de ordenação seguem a mesma lógica do teste de título.
        // Abaixo, um exemplo com o teste de Autor e Título.
        [Fact]
        public void OrdenarLivrosPorAutorETitulo_DeveOrdenarCorretamente()
        {
            // Arrange
            var livrosDesordenados = new List<Livro>
            {
                new Livro("Java How to Program", "Deitel & Deitel", 2007),
                new Livro("Patterns of Enterprise Application Architecture", "Martin Flower", 2002),
                new Livro("Head First Design Patterns", "Elisabeth Freeman", 2004),
                new Livro("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007)
            };

            var mockRepository = new Mock<ILivroRepository>();
            mockRepository.Setup(repo => repo.ListarTodos()).Returns(livrosDesordenados);
            var service = new LivroService(mockRepository.Object);

            // Act
            var resultado = service.OrdenarLivrosPorAutorETitulo().ToList();

            // Assert
            Assert.Equal("Deitel & Deitel", resultado[0].AuthorName);
            Assert.Equal("Deitel & Deitel", resultado[1].AuthorName);
            Assert.Equal("Elisabeth Freeman", resultado[2].AuthorName);
            Assert.Equal("Martin Flower", resultado[3].AuthorName);

            Assert.Equal("Java How to Program", resultado[0].Title);
            Assert.Equal("Internet & World Wide Web: How to Program", resultado[1].Title);
            Assert.Equal("Head First Design Patterns", resultado[2].Title);
            Assert.Equal("Patterns of Enterprise Application Architecture", resultado[3].Title);
        }

        // O teste de ordenação por Edição, Autor e Título também seria adaptado seguindo a mesma lógica.
    }
}