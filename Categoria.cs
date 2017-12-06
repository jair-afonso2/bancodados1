namespace ExemploCRUD
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Titulo { get; set; }

        public Categoria()
        {
        }
        public Categoria(string titulo)
        {
            this.Titulo = titulo;
        }
        
    }

    
}