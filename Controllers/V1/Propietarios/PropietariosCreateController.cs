using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taller.Data;
using Taller.Models;

namespace Taller.Controllers.V1.Propietarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropietariosCreateController : ControllerBase
    {
        private readonly ApplicationDbContext ConexionConLaBaseDeDatos;

        public PropietariosCreateController(ApplicationDbContext variablesDeConexion)
        {
            ConexionConLaBaseDeDatos = variablesDeConexion;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Propietario propietario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ConexionConLaBaseDeDatos.Propietarios.Add(propietario);
            await ConexionConLaBaseDeDatos.SaveChangesAsync();
            return Ok(propietario);
        }

    }
}