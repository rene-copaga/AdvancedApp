﻿// <auto-generated />
using AdvancedApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AdvancedApp.Migrations
{
    [DbContext(typeof(AdvancedContext))]
    partial class AdvancedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdvancedApp.Models.Employee", b =>
                {
                    b.Property<string>("SSN")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FamilyName");

                    b.Property<string>("FirstName");

                    b.Property<decimal>("Salary");

                    b.HasKey("SSN");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AdvancedApp.Models.SecondaryIdentity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("InActiveUse");

                    b.Property<string>("Name");

                    b.Property<string>("PrimarySSN");

                    b.HasKey("Id");

                    b.HasIndex("PrimarySSN")
                        .IsUnique()
                        .HasFilter("[PrimarySSN] IS NOT NULL");

                    b.ToTable("SecondaryIdentity");
                });

            modelBuilder.Entity("AdvancedApp.Models.SecondaryIdentity", b =>
                {
                    b.HasOne("AdvancedApp.Models.Employee", "PrimaryIdentity")
                        .WithOne("OtherIdentity")
                        .HasForeignKey("AdvancedApp.Models.SecondaryIdentity", "PrimarySSN");
                });
#pragma warning restore 612, 618
        }
    }
}
