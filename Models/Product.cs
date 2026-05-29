using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThaiThanhNhan_buoi6.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Ten san pham la bat buoc.")]
    [StringLength(100, ErrorMessage = "Ten san pham khong duoc vuot qua 100 ky tu.")]
    [Display(Name = "Ten san pham")]
    public string Name { get; set; } = string.Empty;

    [Range(1000, 100000000, ErrorMessage = "Gia san pham phai tu 1.000 den 100.000.000.")]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Gia")]
    public decimal Price { get; set; }

    [StringLength(1000, ErrorMessage = "Mo ta khong duoc vuot qua 1000 ky tu.")]
    [Display(Name = "Mo ta")]
    public string? Description { get; set; }

    [StringLength(500)]
    [Display(Name = "Anh dai dien")]
    public string? ImageUrl { get; set; }

    [Display(Name = "Danh muc")]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }

    public List<ProductImage> Images { get; set; } = [];
}
