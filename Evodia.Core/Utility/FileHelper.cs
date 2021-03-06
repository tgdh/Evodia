﻿using System.IO;
using System.Web;

namespace Evodia.Core.Utility
{
    public class FileHelper
    {
        public string SaveFormAttachmentToServer(FileHelperSettings fileSavingOptions, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength <= 0) return string.Empty;

            var rootPath = Directory.GetParent(Directory.GetParent(HttpContext.Current.Server.MapPath("/")).FullName);
            var uploadFolder = Path.Combine(rootPath.FullName, "Uploads");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var formDirectory = Path.Combine(uploadFolder, fileSavingOptions.Directory);

            if (!Directory.Exists(formDirectory))
            {
                Directory.CreateDirectory(formDirectory);
            }

            var parentFolderPath = Path.Combine(formDirectory, fileSavingOptions.ParentFolderName.MakeValidFileName());

            if (!Directory.Exists(parentFolderPath))
            {
                Directory.CreateDirectory(parentFolderPath);
            }

            var fileName = file.FileName.MakeValidFileName();

            if (!string.IsNullOrWhiteSpace(fileSavingOptions.FilePrefix))
            {
                fileName = fileSavingOptions.FilePrefix + " - " + fileName;
            }

            var filePath = Path.Combine(parentFolderPath, fileName);

            file.SaveAs(filePath);

            return filePath;
        }
    }

    public class FileHelperSettings
    {
        public string Directory { get; set; }

        public string ParentFolderName { get; set; }

        public string FilePrefix { get; set; }
    }
}
