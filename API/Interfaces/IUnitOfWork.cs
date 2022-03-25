namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task<bool> completeAsync();
        bool HasChanges();

    }
}
