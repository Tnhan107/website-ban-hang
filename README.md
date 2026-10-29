Website quản lý sản phẩm / catalog bán hàng được xây dựng bằng **ASP.NET Core 8 MVC**.

## Tính năng

### Người dùng (Public)
- Xem danh sách sản phẩm
- Lọc sản phẩm theo danh mục
- Tìm kiếm sản phẩm theo tên / mô tả
- Xem chi tiết sản phẩm
- Đăng ký tài khoản
- Đăng nhập / Đăng xuất

### Quản trị (Admin)
- Quản lý **Sản phẩm** (Thêm, Sửa, Xóa, Xem)
- Quản lý **Danh mục** (Categories)
- Chỉ tài khoản có role **Admin** mới truy cập được khu vực `/Admin`

## Công nghệ sử dụng

| Thành phần              | Công nghệ                          |
|-------------------------|------------------------------------|
| Framework               | ASP.NET Core 8 MVC                 |
| Ngôn ngữ                | C#                                 |
| ORM                     | Entity Framework Core 8            |
| Database                | SQL Server (LocalDB)               |
| Authentication          | ASP.NET Core Identity              |
| Pattern                 | Repository Pattern                 |

## Cấu trúc thư mục chínhThaiThanhNhan_buoi6/
├── Areas/
│   └── Admin/                  # Khu vực quản trị
│       ├── Controllers/
│       └── Views/
├── Controllers/                # Controllers phía người dùng
├── Models/                     # Product, Category, ApplicationUser...
├── Repositories/               # Repository + EF Implementation
├── ViewModels/
├── Views/
├── Data/                       # DbContext, DbInitializer
├── Migrations/
└── wwwroot/text## Yêu cầu hệ thống

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server LocalDB (đi kèm Visual Studio) hoặc SQL Server Express
- Visual Studio 2022 / VS Code / Rider

## Cách chạy dự án

### 1. Clone repository

```bash
git clone https://github.com/Tnhan107/ThaiThanhNhan_buoi6.git
cd ThaiThanhNhan_buoi62.
```

2. Cấu hình databaseChuỗi kết nối mặc định trong appsettings.json:JSON"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=QLBanHang;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}Bạn có thể thay đổi nếu dùng SQL Server khác.3. Chạy Migration (nếu cần)Bashdotnet ef database updateNếu chưa có tool EF:Bashdotnet tool install --global dotnet-ef4. Chạy ứng dụngBashdotnet runHoặc mở bằng Visual Studio rồi nhấn F5.Ứng dụng sẽ chạy tại: https://localhost:xxxx (port tùy cấu hình).Tài khoản mặc địnhKhi chạy lần đầu, hệ thống sẽ khởi tạo role và có thể có tài khoản Admin (tùy theo DbInitializer).
Role mặc định khi đăng ký: Member
Role quản trị: Admin
Models chínhProduct
Id, Name, Price, Description, ImageUrl, CategoryId
Liên kết với Category và danh sách ProductImage
Category
Id, Name, Description
Có nhiều Product
ApplicationUser
Kế thừa từ IdentityUser
Thêm các trường: FullName, Address...
Ghi chú
Đây là bài tập buổi 6 (ASP.NET Core).
Database tên: QLBanHang
Sử dụng Repository Pattern để tách biệt logic truy cập dữ liệu.
