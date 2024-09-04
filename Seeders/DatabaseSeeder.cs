using Bogus;
using Taller.Models;

namespace Taller.Seeders;

public class DatabaseSeeder
{
    public static List<Propietario> GenerarPropietariosFalsos(int cantidadDePropietario)
    {
        var faker = new Faker<Propietario>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)  // IDs secuenciales
            .RuleFor(p => p.Nombre, f => f.Name.FirstName())
            .RuleFor(p => p.Apellido, f => f.Name.LastName())
            .RuleFor(p => p.NumeroDeIdentificacion, f => f.Random.AlphaNumeric(10))  // Ejemplo: 10 caracteres alfanuméricos
            .RuleFor(p => p.FotoPerfil, f => f.Image.PicsumUrl())  // URL de una imagen de perfil
            .RuleFor(p => p.Direccion, f => f.Address.FullAddress())
            .RuleFor(p => p.Telefono, f => f.Phone.PhoneNumber())
            .RuleFor(p => p.Correo, f => f.Internet.Email());

        return faker.Generate(cantidadDePropietario);
    }

}
