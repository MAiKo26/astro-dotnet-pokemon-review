using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Interfaces;
using PokemonReviewAPI.Models;
using PokemonReviewAPI.Repository;

namespace PokemonReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {

        private readonly CategoryInterface _categoryRepistory;
        private readonly IMapper _mapper;

        public CategoryController(CategoryInterface categoryInterface, IMapper mapper)
        {
            _categoryRepistory = categoryInterface;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepistory.GetCategories());


            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(categories);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int Id)
        {
            if (!_categoryRepistory.CategoryExists(Id)) return NotFound();

            var category = _mapper.Map<CategoryDTO>(_categoryRepistory.GetCategory(Id));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int Id)
        {
            var pokemons = _mapper.Map<List<PokemonDTO>>(_categoryRepistory.GetPokemonByCategory(Id));

            if (!_categoryRepistory.CategoryExists(Id)) return NotFound();

            
            if (!ModelState.IsValid) return BadRequest();

            return Ok(pokemons);

        }
    }
}
