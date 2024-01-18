using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.Interfaces;
using PokemonReviewAPI.Models;
using System.Diagnostics.Metrics;

namespace PokemonReviewAPI.Repository
{
    public class CountryRepository : CountryInterface
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public CountryRepository(DataContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool CountryExists(int id)
        {
            return this.context.Countries.Any(c => c.Id == id);

        }

        public bool CreateCountry(Country country)
        {
            this.context.Add(country);
            return Save();
        }

      

        public bool DeleteCountry(Country country)
        {
            this.context.Remove(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
           return this.context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return this.context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return this.context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return this.context.Owners.Where(o => o.Country.Id == countryId).ToList();
        }

        public bool Save()
        {
            var saved = this.context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            this.context.Update(country);
            return Save();
        }
    }
}
