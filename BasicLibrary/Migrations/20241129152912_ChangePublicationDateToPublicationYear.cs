﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ChangePublicationDateToPublicationYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "PublicationYear",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
