﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestEF;

#nullable disable

namespace TestEF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestEF.EntityBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("TestEF.Location", b =>
                {
                    b.HasBaseType("TestEF.EntityBase");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("TestEF.Organization", b =>
                {
                    b.HasBaseType("TestEF.EntityBase");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Organizations", (string)null);
                });

            modelBuilder.Entity("TestEF.Place", b =>
                {
                    b.HasBaseType("TestEF.EntityBase");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("LocationId")
                        .IsUnique()
                        .HasFilter("[LocationId] IS NOT NULL");

                    b.HasIndex("OrganizationId")
                        .IsUnique()
                        .HasFilter("[OrganizationId] IS NOT NULL");

                    b.HasIndex("ParentId");

                    b.ToTable("Places", (string)null);
                });

            modelBuilder.Entity("TestEF.Place", b =>
                {
                    b.HasOne("TestEF.Location", "Location")
                        .WithOne("Place")
                        .HasForeignKey("TestEF.Place", "LocationId");

                    b.HasOne("TestEF.Organization", "Organization")
                        .WithOne("Place")
                        .HasForeignKey("TestEF.Place", "OrganizationId");

                    b.HasOne("TestEF.Place", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Location");

                    b.Navigation("Organization");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TestEF.Location", b =>
                {
                    b.Navigation("Place")
                        .IsRequired();
                });

            modelBuilder.Entity("TestEF.Organization", b =>
                {
                    b.Navigation("Place")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
