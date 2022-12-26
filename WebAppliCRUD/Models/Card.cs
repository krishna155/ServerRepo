using System.ComponentModel.DataAnnotations;
namespace WebAppliCRUD.Models
{
    public class Card
    {
        [Key]
        public Guid id { get; set; }
        public string CardidHolder { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }

        public int CVC { get; set; }

    }
}
