using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Demo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbLinhVuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLinhVuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenLinhVuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLinhVuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbThuTuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaThuTuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenThuTuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinhVucId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbThuTuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbThuTuc_tbLinhVuc_LinhVucId",
                        column: x => x.LinhVucId,
                        principalTable: "tbLinhVuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbQuyTrinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuyTrinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenQuyTrinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThuTucId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbQuyTrinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbQuyTrinh_tbThuTuc_ThuTucId",
                        column: x => x.ThuTucId,
                        principalTable: "tbThuTuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbQuyTrinh_ThuTucId",
                table: "tbQuyTrinh",
                column: "ThuTucId");

            migrationBuilder.CreateIndex(
                name: "IX_tbThuTuc_LinhVucId",
                table: "tbThuTuc",
                column: "LinhVucId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbQuyTrinh");

            migrationBuilder.DropTable(
                name: "tbThuTuc");

            migrationBuilder.DropTable(
                name: "tbLinhVuc");
        }
    }
}
