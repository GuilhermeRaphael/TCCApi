using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCCApi.Data;
using TCCApi.Models;

namespace TCCApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjetoController : ControllerBase
    {
        private readonly DataContext _context;

        public ObjetoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Objeto o = await _context.TB_OBJETOS.FirstOrDefaultAsync(oBusca => oBusca.Id == id);
                return Ok(o);
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
                List<Objeto> lista = await _context.TB_OBJETOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Objeto novoObjeto)
        {
            try
            {
                if (string.IsNullOrEmpty(novoObjeto.Nome))
                    throw new Exception("Nome não pode ser nulo");

                await _context.TB_OBJETOS.AddAsync(novoObjeto);
                await _context.SaveChangesAsync();

                return Ok(novoObjeto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Objeto novoObjeto)
        {
            try
            {
                if (string.IsNullOrEmpty(novoObjeto.Nome))
                {
                    throw new Exception("Nome não pode ser nulo");
                }

                _context.TB_OBJETOS.Update(novoObjeto);
                int linhasafetadas = await _context.SaveChangesAsync();

                return Ok(linhasafetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Objeto oRemover = await _context.TB_OBJETOS.FirstOrDefaultAsync(o => o.Id == id);

                _context.TB_OBJETOS.Remove(oRemover);
                int linhasafetadas = await _context.SaveChangesAsync();
                return Ok(linhasafetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}