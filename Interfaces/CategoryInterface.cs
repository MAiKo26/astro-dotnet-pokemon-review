using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Interfaces
{
    public interface CategoryInterface
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int id);
    }
}
