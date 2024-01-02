using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataConText : DbContext
    {
        public DataConText(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LinhVuc> tbLinhVuc { get; set; }
        public  DbSet<ThuTuc> tbThuTuc { get; set;}
        public DbSet<QuyTrinh> tbQuyTrinh { get; set; }
    }
}
