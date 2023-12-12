using AutoMapper;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.Interfaces;
using PokemonReviewAPI.Models;

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
    }
}
