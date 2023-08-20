namespace MovieStore.Entities
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        ICollection<Movie> Movies { get; set; }
    }
}
