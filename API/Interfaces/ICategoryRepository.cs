using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Response<List<Category>>> GetCategories();
        Task<Response<List<Category>>> GetAdminCategories();
        Task<Response<List<Category>>> AddCategory(Category category);
        Task<Response<List<Category>>> UpdateCategory(Category category);
        Task<Response<List<Category>>> DeleteCategory(int id);
    }
}
