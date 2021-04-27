using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileDBProject.Models
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FileId { get; set; }
        public string Path { get; set; }
        public long ParentId { get; set; }
        public string FileType { get; set; }
    }
}
