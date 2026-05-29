using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThaiThanhNhan_buoi6.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Ten danh muc la bat buoc.")]
    [StringLength(50, ErrorMessage = "Ten danh muc khong duoc vuot qua 50 ky tu.")]
    [Display(Name = "Ten danh muc")]
    public string Name { get; set; } = string.Empty;

    [StringLength(250, ErrorMessage = "Mo ta khong duoc vuot qua 250 ky tu.")]
    [Display(Name = "Mo ta")]
    public string? Description { get; set; }

    public List<Product> Products { get; set; } = [];
}
