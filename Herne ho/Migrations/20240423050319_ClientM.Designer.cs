﻿// <auto-generated />
using System;
using Herne_ho.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Herne_ho.Migrations
{
    [DbContext(typeof(AppDb))]
    [Migration("20240423050319_ClientM")]
    partial class ClientM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Herne_ho.Models.Entities.ClientModel", b =>
                {
                    b.Property<Guid>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CLientPhone")
                        .HasColumnType("text");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ClientId");

                    b.ToTable("ClientModels");
                });

            modelBuilder.Entity("Herne_ho.Models.Entities.WorkerModel", b =>
                {
                    b.Property<Guid>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClientModelClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("WorkerEmail")
                        .HasColumnType("text");

                    b.Property<string>("WorkerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkerPhone")
                        .HasColumnType("text");

                    b.Property<int>("WorkerType")
                        .HasColumnType("integer");

                    b.HasKey("WorkerId");

                    b.HasIndex("ClientModelClientId");

                    b.ToTable("WorkerModels");
                });

            modelBuilder.Entity("Herne_ho.Models.Entities.WorkerModel", b =>
                {
                    b.HasOne("Herne_ho.Models.Entities.ClientModel", null)
                        .WithMany("HiredWorker")
                        .HasForeignKey("ClientModelClientId");
                });

            modelBuilder.Entity("Herne_ho.Models.Entities.ClientModel", b =>
                {
                    b.Navigation("HiredWorker");
                });
#pragma warning restore 612, 618
        }
    }
}
