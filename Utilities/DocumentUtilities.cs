using System.Collections.Generic;
using static docu.documents.Constants.Constants;

namespace docu.documents.Utilities
{
    public static class DocumentUtilities
    {
        public static DocumentType GetType(string extension)
        {
            return GetMimeTypes()[extension];
        }

        private static Dictionary<string, DocumentType> GetMimeTypes()
        {
            return new Dictionary<string, DocumentType>
            {
                {".txt", DocumentType.Doc},
                {".pdf", DocumentType.Doc},
                {".doc", DocumentType.Doc},
                {".docx", DocumentType.Doc},
                {".xls", DocumentType.Doc},
                {".xlsx", DocumentType.Doc},
                {".zip", DocumentType.Doc},
                {".png", DocumentType.Photo},
                {".jpg", DocumentType.Photo},
                {".jpeg",DocumentType.Photo},
                {".gif", DocumentType.Photo},
                {".csv", DocumentType.Doc}
            };
        }
    }
}
