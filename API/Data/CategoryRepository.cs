using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Category>>> AddCategory(Category category)
        {
            category.Editing = category.IsNew = true;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        public async Task<Response<List<Category>>> DeleteCategory(int id)
        {
            Category category = await GetCategoryById(id);
            if (category == null)
                return new Response<List<Category>> { Success = false, Message = "Category not found. " };
            category.Deleted = true;
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        public async Task<Response<List<Category>>> GetAdminCategories()
        {
            var categories = await _context.Categories.Where(x => !x.Deleted).ToListAsync();
            return new Response<List<Category>> { Data = categories };
        }

        public async Task<Response<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.Where(x => !x.Deleted && x.Visible).ToListAsync();
            return new Response<List<Category>> { Data = categories };
        }

        public async Task<Response<List<Category>>> UpdateCategory(Category category)
        {
            var dbCategory = await GetCategoryById(category.Id);
            if (dbCategory == null)
                return new Response<List<Category>> { Success = false, Message = "Category not found. " };
            dbCategory.Name = category.Name;
            dbCategory.Url = category.Url;
            dbCategory.Visible = category.Visible;
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        private async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
