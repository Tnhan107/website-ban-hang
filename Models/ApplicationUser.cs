using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ThaiThanhNhan_buoi6.Models;

public class ApplicationUser : IdentityUser
{
    [Required(ErrorMessage = "Ho ten la bat buoc.")]
    [StringLength(100, ErrorMessage = "Ho ten khong duoc vuot qua 100 ky tu.")]
    public string FullName { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Dia chi khong duoc vuot qua 200 ky tu.")]
    public string? Address { get; set; }
}
