using PokemonWebApi.Data;
using PokemonWebApi.Interfaces;
using PokemonWebApi.Models;
namespace PokemonWebApi.Repository
{
	
	public class PokemonRepository : IPokemonRepository
	{
		private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

		public Pokemon GetPokemon(int id)
		{
			return _context.Pokemons.Where(p => p.Id.Equals(id)).FirstOrDefault();
		}

		public Pokemon GetPokemon(string name)
		{
			return _context.Pokemons.Where(p => p.Name.Equals(name)).FirstOrDefault();
		}

		public decimal GetPokemonRating(int id)
		{
			var review = _context.Reviews.Where(r => r.Id.Equals(id));
		

			if(_context.Reviews.Count() <= 0)
			{
				return 0;
			}
		
			
			return ((decimal)review.Sum(r => r.Rating) / review.Count());
			
		}

		public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

		public bool PokemonExist(int id)
		{
			
			return _context.Pokemons.Any(p => p.Id.Equals(id));
		}

	}
}
