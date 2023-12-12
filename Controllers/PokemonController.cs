using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Interfaces;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly PokemonInterface _pokemonRepistory;
        private readonly IMapper _mapper;

        public PokemonController(PokemonInterface pokemonInterface, IMapper mapper)
        {
            _pokemonRepistory = pokemonInterface;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDTO>>(_pokemonRepistory.GetPokemons());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int Id)
        {
            if (!_pokemonRepistory.PokemonExists(Id)) return NotFound();

            var pokemon = _mapper.Map<PokemonDTO>(_pokemonRepistory.GetPokemon(Id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{Id}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int Id)
        {
            if (!_pokemonRepistory.PokemonExists(Id)) return NotFound();

            var rating = _pokemonRepistory.GetPokemonRating(Id);

            if (!ModelState.IsValid) return BadRequest();

            return Ok(rating);

        }
    }
}
