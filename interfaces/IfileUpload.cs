namespace FileUpload.interfaces
{
    public interface IfileUpload
    {
        Task<bool> uploadfile(IFormFile file);
    }
}
