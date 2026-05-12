using System;
using System.Collections.Generic;
using System.Text;

namespace Admin_DASM.Services
{
    public class DocumentStateService
    {
        public List<FileModel> RecentUploads { get; set; } = new();
    }

    public class FileModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Size { get; set; }

        public string UploadedDate { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }

        public string FilePath { get; set; }

        public string UploadedBy { get; set; }

        public string UserLevel { get; set; }

        public Guid? FolderId { get; set; }
    }
}
