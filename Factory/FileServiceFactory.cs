using docu.documents.Factories.Services;
using Microsoft.AspNetCore.Hosting;
using static docu.documents.Constants.Constants;

namespace docu.documents.Factories
{

    public class FileServiceFactory : IFileServiceFactory
    {
        private IFileService amazonS3FileService = null;
        private IFileService localFileService = null;

        private readonly IHostingEnvironment _hostingEnv;

        public FileServiceFactory(
            IHostingEnvironment env)
        {
            _hostingEnv = env;
        }


        public IFileService Create(Environment environment)
        {
            if (environment == Environment.amazons3)            //if (type == StorageType.amazon.ToString())
            {
                if (amazonS3FileService == null)
                {
                    amazonS3FileService = new AmazonS3FileService();
                    return amazonS3FileService;
                }
                else
                {
                    return amazonS3FileService;
                }
            }
            else if (environment == Environment.local)
            {
                if (localFileService == null)
                {
                    localFileService = new LocalFileService(_hostingEnv);
                    return localFileService;
                }
                else
                {
                    return localFileService;
                }
            }

            return null;
        }

    }
}
