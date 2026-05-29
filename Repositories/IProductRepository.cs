using ThaiThanhNhan_buoi6.Models;

namespace ThaiThanhNhan_buoi6.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);

    Task<Product?> GetByIdAsync(int id);

    Task AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task DeleteAsync(int id);
}
