﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCompanyABC.Data;

#nullable disable

namespace MyCompanyABC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyCompanyABC.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("City")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Role")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstMidName = "Albert1",
                            LastName = "Nosteen1"
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstMidName = "Albert2",
                            LastName = "Nosteen2"
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstMidName = "Albert3",
                            LastName = "Nosteen3"
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstMidName = "Albert4",
                            LastName = "Nosteen4"
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstMidName = "Albert5",
                            LastName = "Nosteen5"
                        },
                        new
                        {
                            EmployeeId = 6,
                            FirstMidName = "Albert6",
                            LastName = "Nosteen6"
                        });
                });

            modelBuilder.Entity("MyCompanyABC.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MyCompanyABC.Models.ProjectList", b =>
                {
                    b.Property<int>("ProjectListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectListId"));

                    b.Property<int>("FK_EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FK_ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Stop")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectListId");

                    b.HasIndex("FK_EmployeeId");

                    b.HasIndex("FK_ProjectId");

                    b.ToTable("ProjectLists");
                });

            modelBuilder.Entity("MyCompanyABC.Models.ProjectList", b =>
                {
                    b.HasOne("MyCompanyABC.Models.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("FK_EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCompanyABC.Models.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("FK_ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
