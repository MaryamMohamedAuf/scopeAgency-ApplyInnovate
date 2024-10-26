﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using scopeAgency.Data;

#nullable disable

namespace scopeAgency.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241025085653_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("scopeAgency.Models.invoiceDetail", b =>
                {
                    b.Property<int>("linqNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("linqNo"));

                    b.Property<DateTime>("expiryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("unitNo")
                        .HasColumnType("int");

                    b.HasKey("linqNo");

                    b.HasIndex("unitNo");

                    b.ToTable("invoiceDetails");
                });

            modelBuilder.Entity("scopeAgency.Models.unit", b =>
                {
                    b.Property<int>("unitNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("unitNo"));

                    b.Property<string>("unitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("unitNo");

                    b.ToTable("units");
                });

            modelBuilder.Entity("scopeAgency.Models.invoiceDetail", b =>
                {
                    b.HasOne("scopeAgency.Models.unit", "unit")
                        .WithMany()
                        .HasForeignKey("unitNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("unit");
                });
#pragma warning restore 612, 618
        }
    }
}
