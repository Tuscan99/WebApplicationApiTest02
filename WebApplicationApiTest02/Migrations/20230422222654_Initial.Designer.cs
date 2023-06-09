﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplicationApiTest02.Models;

#nullable disable

namespace WebApplicationApiTest02.Migrations
{
    [DbContext(typeof(CurrencyDbContext))]
    [Migration("20230422222654_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationApiTest02.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("A_Date")
                        .HasColumnType("date");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("r_currency");
                });
#pragma warning restore 612, 618
        }
    }
}
