using Microsoft.EntityFrameworkCore;
using ThaiThanhNhan_buoi6.Data;
using ThaiThanhNhan_buoi6.Models;

namespace ThaiThanhNhan_buoi6.Repositories;

public class EFProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public EFProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(product => product.Category)
            .Include(product => product.Images)
            .OrderBy(product => product.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
    {
        return await _context.Products
            .Include(product => product.Category)
            .Where(product => product.CategoryId == categoryId)
            .OrderBy(product => product.Name)
            .ToListAsync();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        return _context.Products
            .Include(product => product.Category)
            .Include(product => product.Images)
            .FirstOrDefaultAsync(product => product.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
