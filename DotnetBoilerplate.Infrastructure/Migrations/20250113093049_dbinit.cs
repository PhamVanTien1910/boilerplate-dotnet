using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotnetBoilerplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payment_methods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_methods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles_role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    payment_method_id = table.Column<int>(type: "int", nullable: false),
                    payment_order_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_payment_methods_payment_method_id",
                        column: x => x.payment_method_id,
                        principalTable: "payment_methods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_login = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_superuser = table.Column<bool>(type: "bit", nullable: false),
                    is_staff = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    date_joined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_user_roles_role_role_id",
                        column: x => x.role_id,
                        principalTable: "roles_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "payment_methods",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[] { 1, new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8415), "VNPay", new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.InsertData(
                table: "roles_role",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 13, 9, 30, 48, 368, DateTimeKind.Utc).AddTicks(2383), "admin", new DateTime(2025, 1, 13, 9, 30, 48, 368, DateTimeKind.Utc).AddTicks(2384) },
                    { 2, new DateTime(2025, 1, 13, 9, 30, 48, 368, DateTimeKind.Utc).AddTicks(2387), "member", new DateTime(2025, 1, 13, 9, 30, 48, 368, DateTimeKind.Utc).AddTicks(2388) }
                });

            migrationBuilder.InsertData(
                table: "users_user",
                columns: new[] { "id", "created_at", "date_joined", "email", "name", "is_active", "is_staff", "is_superuser", "last_login", "password", "role_id", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8403), new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8403), "admin@email.com", "Admin", true, false, true, new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8404), "$2a$11$Wi6bPQOYhCmUz3Aocja9KugllugDNZjlTDZtOxS3mfcpNxBTiUgCa", 1, new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8407) },
                    { 2, new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8409), new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8410), "tien@email.com", "Tien", true, false, false, new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8410), "$2a$11$Wi6bPQOYhCmUz3Aocja9KugllugDNZjlTDZtOxS3mfcpNxBTiUgCa", 2, new DateTime(2025, 1, 13, 9, 30, 48, 517, DateTimeKind.Utc).AddTicks(8411) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_payment_method_id",
                table: "orders",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_email",
                table: "users_user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_user_role_id",
                table: "users_user",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "users_user");

            migrationBuilder.DropTable(
                name: "payment_methods");

            migrationBuilder.DropTable(
                name: "roles_role");
        }
    }
}
