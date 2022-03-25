using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<Response<List<Product>>> GetProductsAsync();
        Task<Response<Product>> GetProductAsync(int productId);
        Task<Response<List<Product>>> GetProductsByCategory(string categoryUrl);
        Task<Response<ProductSearchResult>> SearchProducts(string searchText, int page);
        Task<Response<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<Response<List<Product>>> GetFeaturedProducts();
        Task<Response<List<Product>>> GetAdminProducts();
        Task<Response<Product>> CreateProduct(Product product);
        Task<Response<Product>> UpdateProduct(Product product);
        Task<Response<bool>> DeleteProduct(int productId);
    }
}
