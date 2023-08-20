namespace MovieStore.Entities
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
