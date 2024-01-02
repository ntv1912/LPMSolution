using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Models
{
    public class LinhVuc
    {
        [Key] public int Id { get; set; }
        public string MaLinhVuc { get; set; } = "";
        public string TenLinhVuc { get; set; } = "";
        public string MoTa { get; set; } = "";
       
    }
}
