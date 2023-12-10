namespace PokemonReviewAPI.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public ICollection<Review> Reviews { get; set;}
    }
}
