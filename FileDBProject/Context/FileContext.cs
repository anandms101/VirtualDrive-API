using FileDBProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FileDBProject.Context
{
    public class FileContext :DbContext
    {
        public FileContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<File> Files { get; set; }
    }
}
