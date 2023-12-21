using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWebApi.DTO;
using PokemonWebApi.Interfaces;
using PokemonWebApi.Models;

namespace PokemonWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class CategoryController : Controller
	{
		
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type =typeof(IEnumerable<Category>))]
		public IActionResult GetCategories()
		{
			var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());
			if(!ModelState.IsValid)
			{
				return BadRequest();
			}
			return Ok(categories);
		}

		[HttpGet("{categoryId}")]
		[ProducesResponseType(200,Type =typeof(Category))]
		[ProducesResponseType(400)]
		public IActionResult GetCategory(int categoryId)
		{
			if(!_categoryRepository.CategoryExists(categoryId))
			{
				return NotFound();
			}
			var category = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategory(categoryId));
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(category);
		}

		[HttpGet("{categoryId}/Pokemons")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
		[ProducesResponseType(400)]

		public IActionResult GetPokemonsByCategory(int categoryId)
		{
			if (!_categoryRepository.CategoryExists(categoryId))
			{
				return NotFound();
			}

			var pokemons = _mapper.Map<List<PokemonDTO>>(_categoryRepository.GetPokemonsByCategory(categoryId));
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(pokemons);
		}



	}
}
