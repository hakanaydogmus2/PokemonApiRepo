﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWebApi.Interfaces;
using PokemonWebApi.Models;
using PokemonWebApi.DTO;

namespace PokemonWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : Controller
	{
		private readonly ICountryRepository _countryRepository;
		private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
			_mapper = mapper;
        }

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
		
		public IActionResult GetCountries()
		{
			var countries = _mapper.Map<List<CountryDTO>>(_countryRepository.GetCountries());
			if(!ModelState.IsValid)
			{
				return BadRequest();
			}
			return Ok(countries);
		}

		[HttpGet("{countryId}")]
		[ProducesResponseType(200, Type =typeof(Country))]
		[ProducesResponseType(400)]

		public IActionResult GetCountry(int countryId)
		{
			if (!_countryRepository.CountryExist(countryId))
			{
				return NotFound();
			}
			var country = _mapper.Map<CountryDTO>(_countryRepository.GetCountry(countryId));

            if (!ModelState.IsValid)
            {
				return BadRequest(ModelState);
            }
			return Ok(country);
        }
		[HttpGet("owners/{ownerId}")]
		[ProducesResponseType(200, Type = typeof(Country))]
		[ProducesResponseType(400)]

		public IActionResult GetCountryOfAnOwner(int ownerId)
		{
			var country = _mapper.Map<CountryDTO>(_countryRepository
				.GetCountryByOwner(ownerId));

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);

			}
			return Ok(country);


		}

		
    }
}
