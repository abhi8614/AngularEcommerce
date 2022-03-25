using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<Response<List<Category>>>> GetCategories()
        {
            var result = await _unitOfWork.CategoryRepository.GetCategories();
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<List<Category>>>> GetAdminCategories()
        {
            var result = await _unitOfWork.CategoryRepository.GetAdminCategories();
            return Ok(result);
        }

        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<List<Category>>>> DeleteCategory(int id)
        {
            var result = await _unitOfWork.CategoryRepository.DeleteCategory(id);
            return Ok(result);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<List<Category>>>> AddCategory(Category category)
        {
            var result = await _unitOfWork.CategoryRepository.AddCategory(category);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<List<Category>>>> UpdateCategory(Category category)
        {
            var result = await _unitOfWork.CategoryRepository.UpdateCategory(category);
            return Ok(result);
        }
    }
}
