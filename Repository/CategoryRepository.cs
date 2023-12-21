using PokemonWebApi.Data;
using PokemonWebApi.Interfaces;
using PokemonWebApi.Models;

namespace PokemonWebApi.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
		{
			return _context.Categories.Any(c => c.Id.Equals(id));
		}

		public ICollection<Category> GetCategories()
		{
			
			return _context.Categories.OrderBy(c => c.Id).ToList();
		}

		public Category GetCategory(int id)
		{
			return _context.Categories.Where(c => c.Id.Equals(id)).FirstOrDefault();
		}

		public Category GetCategory(string name)
		{
			throw new NotImplementedException();
		}

		public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
		{
			return _context.PokemonCategories.Where(pc =>  pc.CategoryId.Equals(categoryId)).Select(pc => pc.Pokemon).ToList();
		}
	}
}
