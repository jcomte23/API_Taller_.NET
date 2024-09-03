using System.ComponentModel.DataAnnotations;

namespace Taller.Models;
public class Propietario
{
    [Key]
    public int Id { get; set; }

    [MinLength(5, ErrorMessage = "The Name field must be at least {1} characters.")]
    [MaxLength(90, ErrorMessage = "The Name field must be at most {1} characters.")]
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string NumeroDeIdentificacion { get; set; }

    [MaxLength(100, ErrorMessage = "The FotoPerfil field must be at most {1} characters.")]
    [Url(ErrorMessage = "The FotoPerfil field must be a valid URL.")]
    public required string FotoPerfil { get; set; }
    public required string Direccion { get; set; }

    [MinLength(5, ErrorMessage = "The Telefono field be at least {1} characters.")]
    [MaxLength(25, ErrorMessage = "The Telefono field  be at most {1} characters.")]
    [Phone(ErrorMessage = "the phone format is not valid, you can use this example format if you want => '### ### ## ##'")]
    public required string Telefono { get; set; }

    [EmailAddress(ErrorMessage = "The Email field is using an invalid format.")]
    [MinLength(5, ErrorMessage = "The Email field must be at least {1} characters.")]
    [MaxLength(255, ErrorMessage = "The Email field must be at most {1} characters.")]
    public required string Correo { get; set; }
}
