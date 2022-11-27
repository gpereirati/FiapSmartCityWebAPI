using FiapSmartCityWebAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using FiapSmartCityWebAPI.Models;

namespace FiapSmartCityWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiapSmartCityWebAPIController : ControllerBase
    {
        [HttpGet]
        [Route("GetSmartCity")]
        public IActionResult Get()
        {
            try
            {
                 return Ok( new TipoProdutoDAL().Listar());
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetSmartCity/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                TipoProdutoDAL dal = new TipoProdutoDAL();
                TipoProduto TipoProduto = dal.Consultar(id);
                return Ok(TipoProduto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost(Name = "GetSmartCity")]
        public IActionResult Post([FromBody] TipoProduto TipoProduto)
        {
            try
            {
                // Cria o objeto DAL
                TipoProdutoDAL dal = new TipoProdutoDAL();
                // Insere a informação do banco de dados
                dal.Inserir(TipoProduto);

                // Cria uma propriedade para efetuar a consulta da informação cadastrada
                string location = "https://localhost:7013/FiapSmartCityWebAPI";

                return Created(new Uri(location), TipoProduto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete(Name = "GetSmartCity")]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoProdutoDAL dal = new TipoProdutoDAL();
                dal.Excluir(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut(Name = "GetSmartCity")]
        public IActionResult Put([FromBody] TipoProduto tipoProduto)
        {
            try
            {
                TipoProdutoDAL dal = new TipoProdutoDAL();
                dal.Alterar(tipoProduto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}

