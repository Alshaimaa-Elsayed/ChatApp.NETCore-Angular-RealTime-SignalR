namespace ChatApp.Application.Interfaces.Services
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile file,string email);
        Task<bool> DeleteImageAsync(string relativePath);
    }
}
