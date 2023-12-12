using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Interfaces;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {

        private readonly CountryInterface _countryRepistory;
        private readonly IMapper _mapper;

        public CountryController(CountryInterface countryInterface, IMapper mapper)
        {
            _countryRepistory = countryInterface;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var categories = _mapper.Map<List<CountryDTO>>(_countryRepistory.GetCountries());


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(categories);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int Id)
        {
            if (!_countryRepistory.CountryExists(Id)) return NotFound();

            var country = _mapper.Map<CountryDTO>(_countryRepistory.GetCountry(Id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("owners/{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCountry(int Id)
        {
            var countries = _mapper.Map<List<CountryDTO>>(_countryRepistory.GetCountryByOwner(Id));

            if (!_countryRepistory.CountryExists(Id)) return NotFound();


            if (!ModelState.IsValid) return BadRequest();

            return Ok(countries);

        }
    }
}
