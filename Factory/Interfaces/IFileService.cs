using docu.documents.model;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace docu.documents.Factories
{
    public interface IFileService
    {
        Task<DocumentModel> UploadAsync(IFormFile file);

        Task<MemoryStream> DownloadAsync(string path);

        Task<bool> Delete(string path);

        string GetDocumentName(IFormFile file);
    }
}
