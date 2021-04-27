using FileDBProject.Models;
using System;
using System.Collections.Generic;

namespace FileDBProject.Repository
{
    public interface IFileDataRepository<TEntity>
    {
        List<TEntity> Get(Func<TEntity, bool> func);
        void Save(TEntity entity);
        List<File> GetAllDrives(Func<File, bool> func);
        List<File> GetFirstLevelChilds(Func<File, bool> func);
        List<File> GetFileById(Func<File, bool> func);
        List<File> GetFileByPath(Func<File, bool> func);

        void Delete(File entity);

        void Update(File file, File entity);

        void Update(File file, string displayname);
    }
}
