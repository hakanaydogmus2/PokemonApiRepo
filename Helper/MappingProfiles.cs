using AutoMapper;
using PokemonWebApi.DTO;
using PokemonWebApi.Models;

namespace PokemonWebApi.Helper
{
	public class MappingProfiles: Profile
	{
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Owner, OwnerDTO>();
            CreateMap<Review, ReviewDTO>();
        }
    }
}
