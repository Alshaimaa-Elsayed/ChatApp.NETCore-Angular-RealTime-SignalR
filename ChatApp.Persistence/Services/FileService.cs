
namespace ChatApp.Persistence.Services
{
    public sealed class FileService:IFileService
    {
        private const string FilesFolder = "Files";
        private readonly string _rootPath;
        public FileService()
        {
            _rootPath = Path.Combine("wwwroot", FilesFolder);
            EnsureDirectoryExists(FilesFolder);

        }

        public async Task<string> SaveImageAsync(IFormFile file, string email)
        {
            ValidateFile(file);
            ValidateUserIdentifier(email);

            string userFolderPath = Path.Combine(_rootPath, email);
            EnsureDirectoryExists(userFolderPath);

            string fileName = file.FileName;
            string filePath = Path.Combine(userFolderPath, fileName);

            await using var stream = new FileStream(filePath, FileMode.CreateNew,FileAccess.Write,FileShare.None);
            await file.CopyToAsync(stream);

            return Path.Combine(FilesFolder, email, fileName);

        }

        public async Task<bool> DeleteImageAsync(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return false;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);

            if (!File.Exists(fullPath))
                return false;

            File.Delete(fullPath);
            return true;
        }
        // ================== Private Helpers ==================

        private static void ValidateFile(IFormFile file)
        {
            if (file is null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
                throw new InvalidOperationException("Unsupported file type.");
        }
        private static void ValidateUserIdentifier(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
        }
        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
