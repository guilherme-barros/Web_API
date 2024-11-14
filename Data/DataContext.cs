using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalApi.Utils;
using Web_API.Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Computador> TB_COMPUTADORES { get; set; }
        public DbSet<Peca> TB_PECAS { get; set; }
        public DbSet<Periferico> TB_PERIFERICOS { get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computador>().ToTable("TB_COMPUTADORES");
            modelBuilder.Entity<Peca>().ToTable("TB_PECAS");
            modelBuilder.Entity<Periferico>().ToTable("TB_PERIFERICOS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            modelBuilder.Entity<Usuario>()
            .HasMany(c => c.Computadores)
            .WithOne(u => u.Usuario)
            .HasForeignKey(c => c.UsuarioId)
            .IsRequired(false);

            modelBuilder.Entity<Computador>()
            .HasMany(p => p.Pecas)
            .WithOne(c => c.Computador)
            .HasForeignKey(p => p.ComputadorId)
            .IsRequired(false);

            modelBuilder.Entity<Computador>()
            .HasMany(p => p.Perifericos)
            .WithOne(c => c.Computador)
            .HasForeignKey(p => p.ComputadorId)
            .IsRequired(false);


            modelBuilder.Entity<Computador>().HasData(new Computador
            {
                Id = 1,
                Marca = "Dell",
                Descricao = "Notebook Dell",
                Valor = 1000,
                UsuarioId = 1
            });


            modelBuilder.Entity<Peca>().HasData
            (
                new Peca() {Id = 1, Nome = "Processador AMD Athlon 3000G", Geracao = 9, Marca = "AMD", Descricao = "", Preco = 359.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.Processador, ComputadorId = 1},
                new Peca() {Id = 2, Nome = "Placa Mae Mancer A520M-DX", Marca = "Mancer", Descricao = "", Preco = 389.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.PlacaMae, ComputadorId = 1},
                new Peca() {Id = 3, Nome = "Memoria Corsair ValueSelec", Marca = "Corsair", Descricao = "", Preco = 106.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.MemoriaRAM, ComputadorId = 1},
                new Peca() {Id = 4, Nome = "Placa de Video TGT GeForce GT610", Marca = "TGT", Descricao = "", Preco = 129.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.PlacaVideo, ComputadorId = 1},
                new Peca() {Id = 5, Nome = "SSD TGT Egon T2", Marca = "TGT", Descricao = "", Preco = 79.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.Armazenamento, ComputadorId = 1},
                new Peca() {Id = 6, Nome = "Gabinete Office Aigo Q2506", Marca = "Aigo", Descricao = "", Preco = 94.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.Gabinete, ComputadorId = 1},
                new Peca() {Id = 7, Nome = "Fonte TGT TG205", Marca = "TGT", Descricao = "", Preco = 59.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.FonteAlimentacao, ComputadorId = 1},
                new Peca() {Id = 8, Nome = "Processador AMD Ryzen Threadripper PRO 5975WX", Geracao = 16, Marca = "AMD", Descricao = "", Preco = 4779.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.Processador, ComputadorId = 2},
                new Peca() {Id = 9, Nome = "Placa Mae Gigabyte X670E Aorus Xtreme", Marca = "Gigabyte", Descricao = "", Preco = 5.999, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.PlacaMae, ComputadorId = 2},
                new Peca() {Id = 10, Nome = "Memoria Team Group T-Force Delta", Marca = "Team Group T-Force", Descricao = "", Preco = 4199.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.MemoriaRAM, ComputadorId = 2},
                new Peca() {Id = 11, Nome = "Placa de VIdeo PNY GeForce RTX 6000 ADA Generation", Marca = "PNY", Descricao = "", Preco = 52999.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.PlacaVideo, ComputadorId = 2},
                new Peca() {Id = 12, Nome = "SSD NAS Apacer Endurance PB4480", Marca = "NAS Apacer", Descricao = "", Preco = 4159.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.Armazenamento, ComputadorId = 2},
                new Peca() {Id = 13, Nome = "Gabinete Gamer Cooler Master Sneaker X Red", Marca = "Cooler Master", Descricao = "", Preco = 7899.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.Gabinete, ComputadorId = 2},
                new Peca() {Id = 14, Nome = "Gonte Asus ROG THOR 1600W Titanium", Marca = "Asus", Descricao = "", Preco = 4499.99, TipoPeca = Web_API.Models.Enuns.TipoPecaEnum.FonteAlimentacao, ComputadorId = 2}
            );

            modelBuilder.Entity<Peca>().HasData
            (
                new Periferico() {Id = 1, Nome = "Monitor SZL17", Marca = "SZL", Descricao = "", Preco = 349.99, TipoPeriferico = Web_API.Models.Enuns.TipoPerifericosEnum.Monitor, ComputadorId = 1},
                new Periferico() {Id = 2, Nome = "Teclado Gamer TGT M16L", Marca = "TGT", Descricao = "", Preco = 44.99, TipoPeriferico = Web_API.Models.Enuns.TipoPerifericosEnum.Teclado, ComputadorId = 1},
                new Periferico() {Id = 3, Nome = "Mouse Multi Com Fio", Marca = "Multi", Descricao = "", Preco = 7.89, TipoPeriferico = Web_API.Models.Enuns.TipoPerifericosEnum.Mouse, ComputadorId = 1},
                new Periferico() {Id = 4, Nome = "Monitor Gamer AOC Agon Pro Porsche Design", Marca = "AOC", Descricao = "", Preco = 11999.99, TipoPeriferico = Web_API.Models.Enuns.TipoPerifericosEnum.Monitor, ComputadorId = 2},
                new Periferico() {Id = 5, Nome = "Teclado Mecanico Razer Blackwidow V4 PRO", Marca = "Razer", Descricao = "", Preco = 1899.99, TipoPeriferico = Web_API.Models.Enuns.TipoPerifericosEnum.Teclado, ComputadorId = 2},
                new Periferico() {Id = 6, Nome = "Mouse Gamer Zowie EC3-CW", Marca = "Zonwie", Descricao = "", Preco = 1099.99, TipoPeriferico = Web_API.Models.Enuns.TipoPerifericosEnum.Mouse, ComputadorId = 2}
            );

            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);
            base.OnModelCreating(modelBuilder);
        }
            protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
            .HaveColumnType("varchar").HaveMaxLength(200);

            base.ConfigureConventions(configurationBuilder);
        }
    }
}