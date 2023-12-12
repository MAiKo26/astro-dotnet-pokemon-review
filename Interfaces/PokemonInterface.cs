using MySqlConnector.Logging;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Interfaces
{
    public interface PokemonInterface
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int id);
        bool PokemonExists(int id);

    }
}
