using System.ComponentModel.DataAnnotations;

namespace WebAppliCRUD.Models
{
    public class Stud
    {
        [Key]
        public int stdid { get; set; }
        public string CardidHolder { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public Guid id { get; set; }
        public int CVC { get; set; }
    }
}
