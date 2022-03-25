using API.Interfaces;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UnitOfWork(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IProductRepository ProductRepository => new ProductRepository(_context, _httpContextAccessor);
        public async Task<bool> completeAsync()
        {
           return await _context.SaveChangesAsync() > 0;
        }
        public bool HasChanges()
        {
            _context.ChangeTracker.DetectChanges();
            return _context.ChangeTracker.HasChanges();
        }
    }
}
