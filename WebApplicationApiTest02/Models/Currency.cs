using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationApiTest02.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string Code { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal Value { get; set; }

        [DataType(DataType.Date)]
        public DateOnly A_Date { get; set; }
    }
}
