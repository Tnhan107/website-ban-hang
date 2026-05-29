using System.ComponentModel.DataAnnotations;

namespace ThaiThanhNhan_buoi6.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "UserName la bat buoc.")]
    [StringLength(50)]
    [Display(Name = "UserName")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ho ten la bat buoc.")]
    [StringLength(100)]
    [Display(Name = "Ho ten")]
    public string FullName { get; set; } = string.Empty;

    [StringLength(200)]
    [Display(Name = "Dia chi")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Email la bat buoc.")]
    [EmailAddress(ErrorMessage = "Email khong hop le.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mat khau la bat buoc.")]
    [DataType(DataType.Password)]
    [Display(Name = "Mat khau")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nhap lai mat khau.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Mat khau nhap lai khong khop.")]
    [Display(Name = "Nhap lai mat khau")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
