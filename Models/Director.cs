namespace GraphQLDirector.Models
{
    public class Director
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public virtual ICollection<Video>? Videos { get; set; }


    }
}
