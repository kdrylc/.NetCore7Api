using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebApi.Models.Concrete
{
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
