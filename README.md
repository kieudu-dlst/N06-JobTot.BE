# Khởi tạo database Backend

## Hướng dẫn chạy Backend

### Yêu cầu

- Cài .NET SDK 9 và runtime ASP.NET Core 9 (được cài kèm SDK).
- Có kết nối Internet khi khôi phục các package NuGet lần đầu.
- Kiểm tra SDK bằng `dotnet --list-sdks`; cần có phiên bản `9.0.x` hoặc SDK mới hơn hỗ trợ build `net9.0`.

### Khởi động

Mở terminal tại thư mục `N06-JobTot.BE`, nơi chứa `JobTot.sln`, rồi chạy:

```powershell
dotnet restore JobTot.sln
dotnet build JobTot.sln --no-restore
dotnet run --project src/JobTot.Api --launch-profile http --no-build
```

Giữ terminal đang chạy và mở **http://localhost:5049/**. Với bộ khung hiện có trên GitHub, API trả về:

```json
{"name":"JobTot API","status":"Skeleton"}
```

Có thể kiểm tra bằng PowerShell:

```powershell
Invoke-RestMethod http://localhost:5049/
```

Nhấn `Ctrl+C` trong terminal để dừng API. Nếu cổng 5049 đang được dùng, dừng tiến trình đang sử dụng cổng hoặc chạy trên cổng khác:

```powershell
dotnet run --project src/JobTot.Api --no-launch-profile --no-build -- --urls http://localhost:5050
```

Khi đó truy cập **http://localhost:5050/**.

### Phạm vi của bộ khung

Bộ khung trên GitHub chưa kết nối database, chưa có API nghiệp vụ và chưa bật Swagger. Chưa cần cài SQL Server, cấu hình connection string hay chạy migrations để khởi động bộ khung.

Các mục format C#, nghiệp vụ và migrations bên dưới là ghi chú cho phần triển khai đầy đủ; chỉ áp dụng khi các file cấu hình, công cụ và code tương ứng đã được bổ sung. Code đầy đủ đang có riêng trên máy có thể yêu cầu cấu hình database và môi trường khác với bộ khung này.

## Format C#

Chạy từ thư mục `BE/JobTot`. CSharpier được ghim phiên bản trong manifest tool;
quy tắc thụt lề và xuống dòng nằm trong `.editorconfig` và `.csharpierrc.json`.

```powershell
dotnet tool restore
dotnet csharpier src
dotnet csharpier src --check
```

## Quản lý cẩm nang và báo cáo

Admin viết bài tại `/admin/career-articles`: nhập tiêu đề, danh mục, mô tả và nội dung; lưu nháp, xem trước hoặc xuất bản. Có thể chuyển bài đã xuất bản về nháp để ẩn khỏi trang ứng viên. Trang `/career-articles` và khối cẩm nang hiển thị bài đã xuất bản; khối cẩm nang lấy 4 bài mới cập nhật nhất.

Áp dụng migration `AddCareerArticles` bằng lệnh cập nhật database bên dưới rồi khởi động lại API. Migration chỉ tạo bảng bài viết, không xuất bản các nội dung minh họa cũ. Nội dung hỗ trợ `##`/`###` cho tiêu đề, `**chữ đậm**` và `-` cho dòng liệt kê; HTML hiển thị dạng chữ.

## Tạo Migrations
dotnet ef migrations add Ten-Migration `
  --project src/JobTot.Infrastructure `
  --startup-project src/JobTot.Api `
  --configuration CodeFirst

## Update Database Structure
dotnet ef database update `
  --project src/JobTot.Infrastructure `
  --startup-project src/JobTot.Api `
  --configuration CodeFirst

## Dữ liệu mẫu

Thông tin đăng nhập tài khoản mẫu được quản lý riêng trong môi trường phát triển; không lưu mật khẩu trong repository.
