using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Bussiness.Abstract;
using NetCoreWebApi.Models.Concrete;

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _categoryRepository.Get(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAll()
        {
        var cat = await _categoryRepository.GettAll();
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            var cat = await _categoryRepository.Create(categoryDTO);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> Update (CategoryDTO category)
        {
           var cat = await _categoryRepository.Update(category);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _categoryRepository.Delete(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }


    }
}
