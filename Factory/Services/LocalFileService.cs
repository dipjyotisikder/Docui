using docu.documents.model;
using docu.documents.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace docu.documents.Factories.Services
{
    public class LocalFileService : IFileService
    {
        private readonly IHostingEnvironment _env;
        public LocalFileService(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task<bool> Delete(string path)
        {
            string content_path_Root = _env.ContentRootPath + path;
            string web_path_Root = _env.WebRootPath + path;

            if (File.Exists(content_path_Root))
            {
                await Task.Run(() => File.Delete(content_path_Root));
                return true;
            }

            return false;
        }

        public async Task<MemoryStream> DownloadAsync(string path)
        {
            var url = _env.ContentRootPath + path;
            var client = new WebClient();
            var memory = new MemoryStream();
            var stream = client.OpenRead(url);
            await stream.CopyToAsync(memory);

            stream.Dispose();

            memory.Position = 0;
            return await Task.FromResult(memory);
        }

        public string GetDocumentName(IFormFile file)
        {
            var name = Path.GetFileNameWithoutExtension(file.FileName);
            name = name.Replace(" ", "_");
            return name;
        }


        public async Task<DocumentModel> UploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;

            //DRILL ORIGINAL NAME
            var originalName = GetDocumentName(file);

            //DRILL EXTENSION
            var extension = Path.GetExtension(file.FileName).ToLower();

            //GENERATE UNIQUE NAME
            var currentName = Guid.NewGuid().ToString();

            //ROOT PATH
            string rootPath = _env.ContentRootPath;

            //APPLICATION LOCAL DIRECTORY PATH
            string localDirectory = $"/StaticFiles/";

            //FILE PATH
            string imagePath = $"{rootPath}{localDirectory}{currentName}{extension}";

            //SAVE STREAM
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return await Task.FromResult(new DocumentModel
            {
                OriginalName = originalName,
                Name = currentName,
                Extension = extension,
                ContentType = file.ContentType,
                Path = Path.Combine(localDirectory, currentName + extension)
            });
        }
    }
}
