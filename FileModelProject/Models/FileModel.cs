namespace FileModelProject.Models
{
    public class FileModel
    {
        public long FileId { get; set; }
        public string Path { get; set; }
        public long ParentId { get; set; }
        public string FileType { get; set; }
    }
}
