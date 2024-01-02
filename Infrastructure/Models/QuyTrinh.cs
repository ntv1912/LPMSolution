using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public  class QuyTrinh
    {
        [Key] public int Id { get; set; }
        public string MaQuyTrinh { get; set; } = "";
        public string TenQuyTrinh { get; set; } = "";
        public string MoTa { get; set; } = "";
        public int ThuTucId { get; set; }
        [ForeignKey("ThuTucId")]
        public ThuTuc? ThuTuc { get; set; }
    }
}
