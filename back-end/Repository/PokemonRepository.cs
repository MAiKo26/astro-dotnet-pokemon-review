using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.Interfaces;
using PokemonReviewAPI.Models;
using System.Diagnostics.Metrics;

namespace PokemonReviewAPI.Repository
{
    public class PokemonRepository : PokemonInterface
    {
        private readonly DataContext context;
        public PokemonRepository(DataContext context)
        {
            this.context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = this.context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = this.context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };

            this.context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory
            {
                Category = category,
                Pokemon = pokemon
            };
            this.context.Add(pokemonCategory);

            this.context.Add(pokemon);
            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            this.context.Remove(pokemon);
            return Save();
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

        public bool Save()
        {
            var saved = this.context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            this.context.Update(pokemon);
            return Save();
        }
    }
}
