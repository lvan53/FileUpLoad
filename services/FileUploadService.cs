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
                string extension = Path.GetExtension(file.FileName);
                string randomfile = Path.GetRandomFileName() ;

                using (var fileStream = new FileStream(Path.Combine(path, randomfile), FileMode.Create))
                {
                    await fileStream.CopyToAsync(fileStream);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("erreur", ex);

            }
        }
    }
}
