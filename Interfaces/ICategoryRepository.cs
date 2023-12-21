using PokemonWebApi.Models;

namespace PokemonWebApi.Interfaces
{
	public interface ICategoryRepository
	{
		ICollection<Category> GetCategories();
		Category GetCategory(int id);
		Category GetCategory(string name);

		ICollection<Pokemon> GetPokemonsByCategory(int categoryId);
		bool CategoryExists(int id);

	}
}
