using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ThuTuc
    {
        [Key] public int Id { get; set; }
        public string MaThuTuc { get; set; } = "";
        public string TenThuTuc { get; set; } = "";
        public string MoTa { get; set; } = "";
        public int LinhVucId {  get; set; }
        [ForeignKey("LinhVucId")]
        public LinhVuc? LinhVuc { get; set;}
    }
}
