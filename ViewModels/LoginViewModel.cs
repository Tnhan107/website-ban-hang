using System.ComponentModel.DataAnnotations;

namespace ThaiThanhNhan_buoi6.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "UserName la bat buoc.")]
    [Display(Name = "UserName")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mat khau la bat buoc.")]
    [DataType(DataType.Password)]
    [Display(Name = "Mat khau")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Ghi nho dang nhap")]
    public bool RememberMe { get; set; }
}
