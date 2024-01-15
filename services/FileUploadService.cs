using FileUpload.interfaces;
using System.IO.Pipelines;

namespace FileUpload.services
{
    public class FileUploadService : IfileUpload
    {
        public async Task<bool> uploadfile(IFormFile file)
        {
            string path = string.Empty;
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,"images"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
                string fileName = $"{DateTime.Now.ToFileTime()}-{file.FileName}";

                using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                await file.OpenReadStream().CopyToAsync(fileStream);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occurred", ex);
            }
        }
    }
}
