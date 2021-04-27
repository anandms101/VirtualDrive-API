using AutoMapper;
using FileCoreServicesProject.Repository;
using FileDBProject.Models;
using FileDBProject.Repository;
using FileModelProject.Models;
using System;
using System.Collections.Generic;

namespace FileCoreServicesProject.Implementation
{
    public class FileService : IFileService
    {
        private readonly IFileDataRepository<File> fileDataRepository;
        private readonly IMapper mapper;

        public FileService(IFileDataRepository<File> fileDataRepository, IMapper mapper)
        {
            this.fileDataRepository = fileDataRepository;
            this.mapper = mapper;
        }
        public List<FileModel> Get()
        {
            var files = fileDataRepository.Get(f => f.Path != null);
            return mapper.Map<IEnumerable<File>, List<FileModel>>(files);
        }
        public void Save(FileModel fileModel)
        {
            fileDataRepository.Save(mapper.Map<File>(fileModel));
        }
        public List<FileModel> GetAllDrives()
        {
            var driveFiles = fileDataRepository.GetAllDrives(f => f.ParentId.Equals(0));
            return mapper.Map<IEnumerable<File>, List<FileModel>>(driveFiles);
        }
        public List<FileModel> GetFirstLevelChilds(long fileId){
            var firstChild = fileDataRepository.GetFirstLevelChilds(f => f.ParentId.Equals(fileId) );
            return mapper.Map<IEnumerable<File>, List<FileModel>>(firstChild);
        }
        public List<FileModel> GetFileById(long id)
        {
            var file = fileDataRepository.GetFileById(f => f.FileId.Equals(id));
            return mapper.Map<IEnumerable<File>, List<FileModel>>(file);
        }

        public List<FileModel> GetFileByPath(string path)
        {
            var file = fileDataRepository.GetFileByPath(f => string.Equals(f.Path.Replace(@"\", ""), path, StringComparison.OrdinalIgnoreCase));
            return mapper.Map<IEnumerable<File>, List<FileModel>>(file);
        }

        public void DeleteFileById(long fileId)
        {
            var files = fileDataRepository.GetFileById(f => f.FileId.Equals(fileId));
            foreach(var file in files)
            {
                fileDataRepository.Delete(file);
            }
        }

        public void PutRequestById(long fileId, FileModel fileModel)
        {
            var files = fileDataRepository.GetFileById(f => f.FileId.Equals(fileId));
            foreach (var file in files)
            {
                fileDataRepository.Update(file, mapper.Map<File>(fileModel));
            }
        }

        public void PutRequestById(long fileId, string displayname)
        {
            var files = fileDataRepository.GetFileById(f => f.FileId.Equals(fileId));
            foreach (var file in files)
            {
                fileDataRepository.Update(file, displayname);
            }
        }
    }
}
