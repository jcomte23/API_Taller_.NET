using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Models;
public class Vehiculo
{
    [Key]
    public int Id { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public required int PropietarioId { get; set; }
    public required int Año { get; set; }
    public required string Color { get; set; }
    public required string TipoVehiculo { get; set; }
    public required string NumeroChasis { get; set; }

    // Enlaces foraneos
    [ForeignKey("PropietarioId")]
    public Propietario? Propietario { get; set; }
}
