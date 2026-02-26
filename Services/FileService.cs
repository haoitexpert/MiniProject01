using Microsoft.AspNetCore.Components.Forms;

namespace MiniProject01.Services
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IBrowserFile file, string folderName);
        void DeleteFile(string imageUrl);
    }

    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveFileAsync(IBrowserFile file, string folderName)
        {
            // Tạo tên file unique bằng Guid, tránh trùng
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, folderName);

            // Tạo folder nếu chưa có
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, fileName);

            // Ghi file - max 5MB
            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream(5 * 1024 * 1024).CopyToAsync(stream);

            // Trả về đường dẫn relative để lưu DB
            return $"/{folderName}/{fileName}";
        }

        public void DeleteFile(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl)) return;

            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl.TrimStart('/'));
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}