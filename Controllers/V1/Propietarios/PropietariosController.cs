using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Data;

namespace Taller.Controllers.V1.Propietarios;

[ApiController]
[Route("api/v1/[controller]")]
public class PropietariosController : ControllerBase
{

    private readonly ApplicationDbContext ConexionConLaBaseDeDatos;

    public PropietariosController(ApplicationDbContext variablesDeConexion)
    {
        ConexionConLaBaseDeDatos = variablesDeConexion;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var PropietarioTraidosDeLaBaseDeDatos = await ConexionConLaBaseDeDatos.Propietarios.ToListAsync();
        return Ok(PropietarioTraidosDeLaBaseDeDatos);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetOwnerById(int id)
    {
        var PropietarioTraidoDeLaBaseDeDatos = await ConexionConLaBaseDeDatos.Propietarios.FindAsync(id);
        return Ok(PropietarioTraidoDeLaBaseDeDatos);
    }

    [HttpGet("FindByName/{name}")]
    public async Task<IActionResult> GetOwnerByName(string name)
    {
        var PropietarioTraidoDeLaBaseDeDatos = await ConexionConLaBaseDeDatos.Propietarios.FirstOrDefaultAsync(p => p.Nombre.Contains(name));
        return Ok(PropietarioTraidoDeLaBaseDeDatos);
    }

    [HttpGet("FindByInitial/{initial}")]
    public async Task<IActionResult> GetOwnerByInitial(string initial)
    {
        var PropietarioTraidoDeLaBaseDeDatos = await ConexionConLaBaseDeDatos.Propietarios.Where(p => p.Nombre.StartsWith(initial)).ToListAsync();
        return Ok(PropietarioTraidoDeLaBaseDeDatos);
    }



}
