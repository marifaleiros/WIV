using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WIV.Domain
{
    [Table("WorkItem")]
    public class WorkItem
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string IterationPath { get; set; }

        public string AreaPath { get; set; }

        public string State { get; set; }
    }
}
