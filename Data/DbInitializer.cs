using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ThaiThanhNhan_buoi6.Models;

namespace ThaiThanhNhan_buoi6.Data;

public static class DbInitializer
{
    public const string AdminRole = "Admin";
    public const string MemberRole = "Member";

    public static async Task SeedAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();

        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        await EnsureRoleAsync(roleManager, AdminRole);
        await EnsureRoleAsync(roleManager, MemberRole);

        await EnsureUserAsync(
            userManager,
            email: "admin@qlbanhang.local",
            userName: "admin",
            fullName: "Quan tri vien",
            address: "QLBanHang",
            password: "Admin@123",
            role: AdminRole);

        await EnsureUserAsync(
            userManager,
            email: "member@qlbanhang.local",
            userName: "member",
            fullName: "Thanh vien mau",
            address: "Viet Nam",
            password: "Member@123",
            role: MemberRole);
    }

    private static async Task EnsureRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private static async Task EnsureUserAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string userName,
        string fullName,
        string address,
        string password,
        string role)
    {
        var user = await userManager.FindByNameAsync(userName);

        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                FullName = fullName,
                Address = address,
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
            {
                throw new InvalidOperationException(string.Join("; ", createResult.Errors.Select(error => error.Description)));
            }
        }

        if (!await userManager.IsInRoleAsync(user, role))
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }
}
