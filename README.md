# JobTot Backend

## Yêu cầu

- .NET SDK 9.
- SQL Server đang chạy.
- Entity Framework CLI 9: `dotnet tool install --global dotnet-ef --version "9.*"` (cài một lần).

## Chạy Backend

Mở PowerShell tại thư mục `N06-JobTot.BE`.

1. Cấu hình kết nối SQL Server cho terminal hiện tại; sửa server và tên database cho phù hợp:

```powershell
$env:ConnectionStrings__SqlServer = "Server=localhost;Database=JobTot;Trusted_Connection=True;TrustServerCertificate=True"
```

2. Khôi phục dependency, cập nhật database và chạy API:

```powershell
dotnet restore JobTot.sln
dotnet ef database update --project src/JobTot.Infrastructure --startup-project src/JobTot.Api
dotnet run --project src/JobTot.Api --launch-profile http
```

Mở Swagger tại **http://localhost:5049/swagger**.

Nhấn `Ctrl+C` để dừng Backend.

## Tạo migration thiết kế bảng

Sau khi thêm hoặc sửa entities và cấu hình model, tạo migration (thay `TenMigration` bằng tên thay đổi):

```powershell
dotnet ef migrations add TenMigration `
  --project src/JobTot.Infrastructure `
  --startup-project src/JobTot.Api
```

## Tạo database và cập nhật cấu trúc bảng

Dùng kết nối SQL Server đã cấu hình ở trên, chạy:

```powershell
dotnet ef database update `
  --project src/JobTot.Infrastructure `
  --startup-project src/JobTot.Api
```

Lệnh tạo database nếu chưa có và áp dụng các migration còn thiếu để tạo hoặc cập nhật bảng. Tài khoản kết nối cần có quyền tạo database hoặc thay đổi cấu trúc tương ứng.

Nếu dự án đã có migrations, chỉ cần chạy `database update` để khởi tạo database; không cần tạo lại migration.
