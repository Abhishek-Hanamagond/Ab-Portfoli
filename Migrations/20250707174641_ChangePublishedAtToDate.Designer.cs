﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using portfolio.Data;

#nullable disable

namespace portfolio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250707174641_ChangePublishedAtToDate")]
    partial class ChangePublishedAtToDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("portfolio.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("author")
                        .HasColumnType("text");

                    b.Property<string>("imageHint")
                        .HasColumnType("text");

                    b.Property<string>("imageUrl")
                        .HasColumnType("text");

                    b.Property<DateTime?>("publishedAt")
                        .HasColumnType("date");

                    b.PrimitiveCollection<List<string>>("skill")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("summary")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("portfolio.Models.CaseStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("imageHint")
                        .HasColumnType("text");

                    b.Property<string>("imageUrl")
                        .HasColumnType("text");

                    b.Property<string>("outcome")
                        .HasColumnType("text");

                    b.Property<string>("problem")
                        .HasColumnType("text");

                    b.Property<string>("solution")
                        .HasColumnType("text");

                    b.PrimitiveCollection<List<string>>("tags")
                        .HasColumnType("text[]");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CaseStudy");
                });

            modelBuilder.Entity("portfolio.Models.Projects", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageHint")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("LiveURL")
                        .HasColumnType("text");

                    b.Property<string>("SourceURL")
                        .HasColumnType("text");

                    b.PrimitiveCollection<List<string>>("Tags")
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
