﻿// <auto-generated />
using Cinema.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20220530160330_atualizacao2")]
    partial class atualizacao2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinema.Models.Assento", b =>
                {
                    b.Property<int>("AssentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumAssento")
                        .HasColumnType("int");

                    b.HasKey("AssentoId");

                    b.ToTable("Assento");
                });

            modelBuilder.Entity("Cinema.Models.Cine", b =>
                {
                    b.Property<int>("CinemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocalCinema")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CinemaId");

                    b.ToTable("Cine");
                });

            modelBuilder.Entity("Cinema.Models.Filme", b =>
                {
                    b.Property<int>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoriaFilme")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NomeFilme")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("FilmeId");

                    b.ToTable("Filme");
                });

            modelBuilder.Entity("Cinema.Models.Hora", b =>
                {
                    b.Property<int>("HoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("HoraId");

                    b.ToTable("Hora");
                });

            modelBuilder.Entity("Cinema.Models.Ingresso", b =>
                {
                    b.Property<int>("IngressoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssentoId")
                        .HasColumnType("int");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int>("HoraId")
                        .HasColumnType("int");

                    b.Property<int>("SessaoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoIngressoId")
                        .HasColumnType("int");

                    b.HasKey("IngressoId");

                    b.HasIndex("AssentoId");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmeId");

                    b.HasIndex("HoraId");

                    b.HasIndex("SessaoId");

                    b.HasIndex("TipoIngressoId");

                    b.ToTable("Ingresso");
                });

            modelBuilder.Entity("Cinema.Models.Sessao", b =>
                {
                    b.Property<int>("SessaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumSala")
                        .HasColumnType("int");

                    b.HasKey("SessaoId");

                    b.ToTable("Sessao");
                });

            modelBuilder.Entity("Cinema.Models.TipoIngresso", b =>
                {
                    b.Property<int>("TipoIngressoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TIngresso")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("TipoIngressoId");

                    b.ToTable("TipoIngresso");
                });

            modelBuilder.Entity("Cinema.Models.Ingresso", b =>
                {
                    b.HasOne("Cinema.Models.Assento", "Assento")
                        .WithMany()
                        .HasForeignKey("AssentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Models.Cine", "Cinema")
                        .WithMany()
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Models.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Models.Hora", "Hora")
                        .WithMany()
                        .HasForeignKey("HoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Models.Sessao", "Sessao")
                        .WithMany()
                        .HasForeignKey("SessaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Models.TipoIngresso", "TipoIngresso")
                        .WithMany()
                        .HasForeignKey("TipoIngressoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assento");

                    b.Navigation("Cinema");

                    b.Navigation("Filme");

                    b.Navigation("Hora");

                    b.Navigation("Sessao");

                    b.Navigation("TipoIngresso");
                });
#pragma warning restore 612, 618
        }
    }
}