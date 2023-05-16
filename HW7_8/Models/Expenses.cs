using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW7_8.Models
{
    public class Expenses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public decimal MoneySpent { get; set; }

        public DateTime Date { get; set; }

        public string? Comment { get; set; }

        [Required]
        public Category Category { get; set; }
    }
}
