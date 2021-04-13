using docu.documents.Factories;
using docu.documents.Factories.Services;
using Microsoft.Extensions.DependencyInjection;

namespace docu.documents.Extensions
{
    public static class DocumentServiceExtension
    {
        public static IServiceCollection AddDocumentService(this IServiceCollection _services)
        {
            _services.AddScoped<IFileServiceFactory, FileServiceFactory>();
            _services.AddScoped<IFileService, LocalFileService>();
            _services.AddScoped<IFileService, AmazonS3FileService>();

            return _services;
        }
    }
}
