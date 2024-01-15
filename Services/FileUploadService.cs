using FileUpload.Interfaces;

namespace FileUpload.Services;

public class FileUploadService  : IFileUpload
{
    private readonly ILogger<FileUploadService> _logger;

    public FileUploadService(ILogger<FileUploadService> logger)
    {
        _logger = logger;
    }

    public async Task<bool> UploadFile(IFormFile file)
    {
        try
        {
            if (file.Length <= 0)
            {
                throw new InvalidOperationException("Cannot upload an empty file");
            }

            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "images"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = $"{DateTime.Now.ToFileTime()}-{file.FileName}";
            using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fileStream);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while attempting to upload a file: {Exception}", ex);
            return false;
        }
    }
}
