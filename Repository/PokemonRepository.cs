using PokemonReviewAPI.Data;
using PokemonReviewAPI.Interfaces;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Repository
{
    public class PokemonRepository : PokemonInterface
    {
        private readonly DataContext context;
        public PokemonRepository(DataContext context)
        {
            this.context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return this.context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return this.context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var review = this.context.Reviews.Where(p => p.Pokemon.Id == id);

            if (review.Count() <= 0)
            {
                return 0;
            }

            return (decimal)review.Sum(r => r.Rating) / review.Count();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return this.context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int id)
        {
            return this.context.Pokemon.Any(p => p.Id == id);
        }
    }
}
