using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantWorld.ApiProvider.Repositories.Interfaces;
using System.Net.Sockets;

namespace PlantWorld.ApiProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Category category)
        {
            var createdCategory = await _categoryRepo.AddAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Models.Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            var updatedCategory = await _categoryRepo.UpdateAsync(category);
            if (updatedCategory == null)
            {
                return NotFound();
            }
            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryRepo.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
