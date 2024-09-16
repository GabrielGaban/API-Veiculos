using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veiculosAPI.Data;
using veiculosAPI.Models;

namespace veiculosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly VeiculoDataAccess _dataAccess;

        public VeiculosController(VeiculoDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public ActionResult<List<Veiculo>> GetAllVeiculos()
        {
            return _dataAccess.GetAllVeiculos();
        }

        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetVeiculoById(int id)
        {
            var veiculo = _dataAccess.GetVeiculoById(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            return veiculo;
        }

        [HttpPost]
        public IActionResult AddVeiculo([FromBody] Veiculo veiculo)
        {
            _dataAccess.AddVeiculo(veiculo);
            return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.VeiculoID }, veiculo);
        }

        [HttpPut]
        public IActionResult UpdateVeiculo([FromBody] Veiculo veiculo)
        {
           
            _dataAccess.UpdateVeiculo(veiculo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVeiculo(int id)
        {
            var veiculo = _dataAccess.GetVeiculoById(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            _dataAccess.DeleteVeiculo(id);
            return NoContent();
        }
    }
}