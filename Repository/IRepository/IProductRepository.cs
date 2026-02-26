using MiniProject01.Data;

namespace MiniProject01.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product obj);
        Task<Product> UpdateAsync(Product obj);
        Task<bool> DeleteAsync(int id);
        Task<Product> GetAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}