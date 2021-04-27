using FileDBProject.Context;
using FileDBProject.Models;
using FileDBProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileDBProject.Implementation
{
    public class FileManager : IFileDataRepository<File>
    {
        readonly FileContext _fileContext;
        public FileManager(FileContext context)
        {
            _fileContext = context;
        }
        public List<File> Get(Func<File, bool> func)
        {
            if (func != null)
            {
                return _fileContext.Files.Where(func).ToList();
            }
            return null;
        }
        public void Save(File entity)
        {
            _fileContext.Files.Add(entity);
            _fileContext.SaveChanges();
        }
        public List<File> GetAllDrives(Func<File, bool> func)
        {
            if (func != null)
            {
                return _fileContext.Files.Where(func).ToList();
            }
            return null;
        }
        public List<File> GetFirstLevelChilds(Func<File, bool> func)
        {
            if (func != null)
            {
                return _fileContext.Files.Where(func).ToList();
            }
            return null;
        }
        public List<File> GetFileById(Func<File, bool> func)
        {
            if(func != null)
            {
                return _fileContext.Files.Where(func).ToList();
            }
            return null;
        }
        public List<File> GetFileByPath(Func<File, bool> func)
        {
            if (func != null)
            {
                return _fileContext.Files.Where(func).ToList();
            }
            return null;
        }

        public void Delete(File entity)
        {
            _fileContext.Files.Remove(entity);
            _fileContext.SaveChanges();
        }

        public void Update(File file,File entity)
        {
            file.Path = entity.Path;
            _fileContext.SaveChanges();
        }

        public void Update(File file, string displayname)
        {
            file.Path = displayname;
            _fileContext.SaveChanges();
        }
    }
}
