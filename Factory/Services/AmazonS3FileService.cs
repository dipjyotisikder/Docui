using docu.documents.model;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace docu.documents.Factories.Services
{
    public class AmazonS3FileService : IFileService
    {
        public Task<bool> Delete(string path)
        {
            throw new System.NotImplementedException();
        }

        public Task<MemoryStream> DownloadAsync(string path)
        {
            throw new System.NotImplementedException();
        }

        public string GetDocumentName(IFormFile file)
        {
            throw new System.NotImplementedException();
        }

        public Task<DocumentModel> UploadAsync(IFormFile file)
        {
            throw new System.NotImplementedException();
        }
    }
}
