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
