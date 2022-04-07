using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("admin"))]
        public async Task<ActionResult<Response<List<Product>>>> GetAdminProducts()
        {

            var result = await _unitOfWork.ProductRepository.GetAdminProducts();
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<Product>>> CreateProduct(Product product)
        {
            var result = await _unitOfWork.ProductRepository.CreateProduct(product);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<Product>>> UpdateProduct(Product product)
        {
            var result = await _unitOfWork.ProductRepository.UpdateProduct(product);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Response<bool>>> DeleteProduct(int id)
        {
            var result = await _unitOfWork.ProductRepository.DeleteProduct(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Product>>>> GetProducts()
        {
            var result = await _unitOfWork.ProductRepository.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Response<Product>>> GetProduct(int productId)
        {
            var result = await _unitOfWork.ProductRepository.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<Response<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await _unitOfWork.ProductRepository.GetProductsByCategory(categoryUrl);
            return Ok(result);
        }

        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<Response<ProductSearchResult>>> SearchProducts(string searchText, int page = 1)
        {
            var result = await _unitOfWork.ProductRepository.SearchProducts(searchText, page);
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<Response<List<Product>>>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _unitOfWork.ProductRepository.GetProductSearchSuggestions(searchText);
            return Ok(result);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<Response<List<Product>>>> GetFeaturedProducts()
        {
            var result = await _unitOfWork.ProductRepository.GetFeaturedProducts();
            return Ok(result);
        }
    }
}
