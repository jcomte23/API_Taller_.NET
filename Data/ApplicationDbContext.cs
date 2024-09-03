using Microsoft.EntityFrameworkCore;
using Taller.Models;

namespace Taller.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Propietario>(propietario =>
        {
            propietario.ToTable("propietarios");
            propietario.HasKey(p => p.Id);
            propietario.Property(p => p.Id).ValueGeneratedOnAdd();
            propietario.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
            propietario.Property(p => p.Apellido).HasMaxLength(100).IsRequired();
            propietario.Property(p => p.FotoPerfil).HasMaxLength(100).IsRequired();
            propietario.Property(p => p.Direccion).HasMaxLength(200).IsRequired();
            propietario.Property(p => p.Telefono).HasMaxLength(25).IsRequired();
            propietario.Property(p => p.Direccion).HasMaxLength(255).IsRequired();
            propietario.Ignore(p => p.ColorDePelo);
        });

        modelBuilder.Entity<Vehiculo>(vehiculo =>
        {
            vehiculo.ToTable("vehiculos");
            vehiculo.HasKey(v => v.Id);
            vehiculo.Property(v => v.Id).ValueGeneratedOnAdd();
            vehiculo.Property(v => v.Marca).HasMaxLength(100).IsRequired();
            vehiculo.Property(v => v.Modelo).HasMaxLength(50).IsRequired();
            vehiculo.Property(v => v.PropietarioId).IsRequired();
            vehiculo.Property(v => v.Año).IsRequired();
            vehiculo.Property(v => v.Color).HasMaxLength(50).IsRequired();
            vehiculo.Property(v => v.TipoVehiculo).HasMaxLength(50).IsRequired();
            vehiculo.Property(v => v.NumeroChasis).HasMaxLength(25).IsRequired();

            vehiculo.HasOne(v => v.Propietario)  // Relación uno a muchos
                    .WithMany(p => p.Vehiculos)       // Colección de vehículos en Propietario
                    .HasForeignKey(v => v.PropietarioId);  // Clave foránea en Vehiculo
        });
    }




}
