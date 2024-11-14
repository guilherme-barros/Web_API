using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web_API.Models;

namespace Web_API.Controller
{
    [Route("[controller]")]
    public class ComputadoresController : ControllerBase
    {
        private readonly DataContext _context;
        public ComputadoresController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Computador c = await _context.TB_COMPUTADORES.FirstOrDefaultAsync(c => c.Id == id);

                return Ok(c);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Computador> lista = await _context.TB_COMPUTADORES.ToListAsync();
                return Ok(lista);
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpGet("GetPecas/{id}")]
        public async Task<IActionResult> Getsingle(int id)
        {
            try
            {
                List<Peca> pecas = new List<Peca>();
                List<Peca> lista = await _context.TB_COMPUTADORES.ToListAsync();
                return Ok(lista);
            }
            catch (SystemException ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}