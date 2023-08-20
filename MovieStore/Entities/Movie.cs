namespace MovieStore.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public int GenreId { get; set;}
        public Genre Genre { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int ActorId { get; set; }
        //public Actor Actor { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public decimal Price { get; set; }
    }
}
