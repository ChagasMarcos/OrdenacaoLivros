namespace OrdenacaoLivros.Models
{
    public class Livro
    {
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public int EditionYear { get; set; }
    
        
        public Livro(string title, string authorName, int editionYear) 
        {
            Title = title;
            AuthorName = authorName;
            EditionYear = editionYear;  
        }


        public override string ToString()
        {
            return $"{Title}, {AuthorName}, {EditionYear}";
        }

    }

}
