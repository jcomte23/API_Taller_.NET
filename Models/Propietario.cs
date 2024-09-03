using System.Text.Json.Serialization;

namespace Taller.Models;
public class Propietario
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string NumeroDeIdentificacion { get; set; }
    public required string FotoPerfil { get; set; }
    public required string Direccion { get; set; }
    public required string Telefono { get; set; }
    public required string Correo { get; set; }
    public required string ColorDePelo { get; set; }



    // enlace a la tabla vehiculos
    // Enlaces foraneos
    [JsonIgnore]
    public virtual ICollection<Vehiculo>? Vehiculos { get; set; }
}
