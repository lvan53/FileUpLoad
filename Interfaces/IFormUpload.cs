namespace FileUpload.Interfaces;

public interface IFileUpload
{
    /// <summary>
    /// Saves the supplied file to the hard drive
    /// </summary>
    /// <param name="file">The file definition we want to save</param>
    /// <returns></returns>
    Task<bool> UploadFile(IFormFile file);
}
