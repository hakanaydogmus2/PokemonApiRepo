﻿using AutoMapper;
using PokemonWebApi.Interfaces;
using PokemonWebApi.Data;
using PokemonWebApi.Models;

namespace PokemonWebApi.Repository
{
	public class CountryRepository : ICountryRepository
	{
		private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CountryExist(int id)
		{
			return _context.Countries.Where(c  => c.Id.Equals(id)).Any(); 
		}

		public ICollection<Country> GetCountries()
		{
			return _context.Countries.OrderBy(c => c.Id).ToList();
		}

		public Country GetCountry(int id)
		{
			return _context.Countries.Where(c => c.Id.Equals(id)).FirstOrDefault();
		}

		public Country GetCountryByOwner(int ownerId)
		{
			return _context.Owners.Where(o => o.Id.Equals(ownerId))
				.Select(o => o.Country).FirstOrDefault();
		}

		public ICollection<Owner> GetOwnersFromACountry(int countryId)
		{
			return _context.Owners.Where(o => o.Country.Id.Equals(countryId)).ToList();
				
		}
	}
}
