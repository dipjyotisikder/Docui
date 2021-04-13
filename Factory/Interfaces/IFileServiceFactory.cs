using static docu.documents.Constants.Constants;

namespace docu.documents.Factories
{
    public interface IFileServiceFactory
    {
        IFileService Create(Environment environment);
    }
}

