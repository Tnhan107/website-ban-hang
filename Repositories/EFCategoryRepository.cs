using Microsoft.EntityFrameworkCore;
using ThaiThanhNhan_buoi6.Data;
using ThaiThanhNhan_buoi6.Models;

namespace ThaiThanhNhan_buoi6.Repositories;

public class EFCategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public EFCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories
            .Include(category => category.Products)
            .OrderBy(category => category.Name)
            .ToListAsync();
    }

    public Task<Category?> GetByIdAsync(int id)
    {
        return _context.Categories
            .Include(category => category.Products)
            .FirstOrDefaultAsync(category => category.Id == id);
    }

    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _context.Categories
            .Include(item => item.Products)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (category == null)
        {
            return;
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}
