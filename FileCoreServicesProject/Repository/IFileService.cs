using FileDBProject.Models;
using FileModelProject.Models;
using System.Collections.Generic;

namespace FileCoreServicesProject.Repository
{
    public interface IFileService
    {
        List<FileModel> Get();
        void Save(FileModel fileModel);
        List<FileModel> GetAllDrives();
        List<FileModel> GetFirstLevelChilds(long fileId);
        List<FileModel> GetFileById(long id);
        List<FileModel> GetFileByPath(string path);

        void DeleteFileById(long fileId);

        void PutRequestById(long fileId, FileModel fileModel);

        void PutRequestById(long fileId, string displayname);
    }
}