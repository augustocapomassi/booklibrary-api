﻿// <auto-generated />
using BookLibrary.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookLibrary.Repository.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240511162214_MyMigration")]
    partial class MyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookLibrary.Repository.DBEntities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category");

                    b.Property<int>("CopiesInUse")
                        .HasColumnType("int")
                        .HasColumnName("copies_in_use");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("isbn");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int")
                        .HasColumnName("total_copies");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type");

                    b.HasKey("BookId")
                        .HasName("pk_books");

                    b.ToTable("books", (string)null);

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Category = "Hardcover",
                            CopiesInUse = 80,
                            FirstName = "Jane",
                            Isbn = "1234567891",
                            LastName = "Austen",
                            Title = "Pride and Prejudice",
                            TotalCopies = 100,
                            Type = "Fiction"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
