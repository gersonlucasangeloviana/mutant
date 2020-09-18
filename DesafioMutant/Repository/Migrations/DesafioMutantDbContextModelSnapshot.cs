﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Database;

namespace Repository.Migrations
{
    [DbContext(typeof(DesafioMutantDbContext))]
    partial class DesafioMutantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Model.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GeoId")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("suite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("GeoId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Model.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("catchPhrase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("Domain.Model.Geo", b =>
                {
                    b.Property<int>("GeoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lng")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeoId");

                    b.ToTable("Geos");
                });

            modelBuilder.Entity("Domain.Model.User", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Model.Address", b =>
                {
                    b.HasOne("Domain.Model.Geo", "geo")
                        .WithMany()
                        .HasForeignKey("GeoId");
                });

            modelBuilder.Entity("Domain.Model.User", b =>
                {
                    b.HasOne("Domain.Model.Address", "address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Domain.Model.Company", "company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
