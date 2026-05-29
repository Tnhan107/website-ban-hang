using Microsoft.AspNetCore.Mvc;
using ThaiThanhNhan_buoi6.Repositories;

namespace ThaiThanhNhan_buoi6.Controllers;

public class ProductsController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<IActionResult> Index(int? categoryId, string? keyword)
    {
        var products = categoryId.HasValue
            ? await _productRepository.GetByCategoryAsync(categoryId.Value)
            : await _productRepository.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            products = products.Where(product =>
                product.Name.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase) ||
                (product.Description?.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase) ?? false));
        }

        ViewBag.Categories = await _categoryRepository.GetAllAsync();
        ViewBag.CategoryId = categoryId;
        ViewBag.Keyword = keyword;

        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
}
