﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteProject.NoteDataContexts;

#nullable disable

namespace NoteProject.Migrations
{
    [DbContext(typeof(NoteDataContext))]
    partial class NoteDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NoteProject.Models.NoteModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NoteDesc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ParentNoteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentNoteID");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("NoteProject.Models.NoteModel", b =>
                {
                    b.HasOne("NoteProject.Models.NoteModel", "ParentNote")
                        .WithMany("ChildNotes")
                        .HasForeignKey("ParentNoteID");

                    b.Navigation("ParentNote");
                });

            modelBuilder.Entity("NoteProject.Models.NoteModel", b =>
                {
                    b.Navigation("ChildNotes");
                });
#pragma warning restore 612, 618
        }
    }
}
