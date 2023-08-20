namespace MovieStore.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Movie> PurchasedMovies { get; set; }
        public ICollection<Genre> FavoriteGenres { get; set; }
    }
}
