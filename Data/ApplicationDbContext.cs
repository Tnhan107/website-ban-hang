using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThaiThanhNhan_buoi6.Models;

namespace ThaiThanhNhan_buoi6.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<ProductImage> ProductImages => Set<ProductImage>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().ToTable("Category");
        builder.Entity<Product>().ToTable("Product");
        builder.Entity<ProductImage>().ToTable("ProductImage");

        builder.Entity<Category>()
            .HasIndex(category => category.Name)
            .IsUnique();

        builder.Entity<Category>()
            .HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .HasForeignKey(product => product.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasMany(product => product.Images)
            .WithOne(image => image.Product)
            .HasForeignKey(image => image.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Dien thoai", Description = "Smartphone moi va phu kien di kem." },
            new Category { Id = 2, Name = "Laptop", Description = "May tinh xach tay hoc tap va lam viec." },
            new Category { Id = 3, Name = "Phu kien", Description = "Tai nghe, sac, chuot va ban phim." }
        );

        builder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "iPhone 15",
                Price = 19990000,
                CategoryId = 1,
                ImageUrl = "https://placehold.co/600x400?text=iPhone+15",
                Description = "Dien thoai man hinh dep, hieu nang manh va camera sac net."
            },
            new Product
            {
                Id = 2,
                Name = "Samsung Galaxy S24",
                Price = 18990000,
                CategoryId = 1,
                ImageUrl = "https://placehold.co/600x400?text=Galaxy+S24",
                Description = "Smartphone Android cao cap phu hop hoc tap, lam viec va giai tri."
            },
            new Product
            {
                Id = 3,
                Name = "Laptop Dell Inspiron",
                Price = 15990000,
                CategoryId = 2,
                ImageUrl = "https://placehold.co/600x400?text=Dell+Inspiron",
                Description = "Laptop van phong gon nhe, phu hop sinh vien va nhan vien."
            },
            new Product
            {
                Id = 4,
                Name = "Tai nghe Bluetooth",
                Price = 1290000,
                CategoryId = 3,
                ImageUrl = "https://placehold.co/600x400?text=Tai+nghe",
                Description = "Tai nghe khong day pin tot, am thanh ro va de mang theo."
            }
        );

        builder.Entity<ProductImage>().HasData(
            new ProductImage { Id = 1, ProductId = 1, Url = "https://placehold.co/600x400?text=iPhone+15" },
            new ProductImage { Id = 2, ProductId = 2, Url = "https://placehold.co/600x400?text=Galaxy+S24" },
            new ProductImage { Id = 3, ProductId = 3, Url = "https://placehold.co/600x400?text=Dell+Inspiron" },
            new ProductImage { Id = 4, ProductId = 4, Url = "https://placehold.co/600x400?text=Tai+nghe" }
        );
    }
}
