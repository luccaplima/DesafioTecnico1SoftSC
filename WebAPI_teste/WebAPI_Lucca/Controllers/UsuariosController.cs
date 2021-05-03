using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Lucca.Models;
using WebAPI_Lucca.Util;

namespace WebAPI_Lucca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET api/usuarios
        [HttpGet]
        public List<UsuariosModel> Listagem()
        {
            return new UsuariosModel().Listagem();
        }

        // GET api/usuarios/id
        [HttpGet]
        [Route("{id}")]
        public UsuariosModel RetornarUsuario(int id)
        {
            return new UsuariosModel().RetornarUsuario(id);
        }

        // POST api/usuarios/registrarcliente
        [HttpPost]
        [Route("registrarusuario")]
        public ReturnAllServices RegistrarUsuario([FromBody] UsuariosModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.RegistrarUsuario();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar atualizar usuário:" + ex.Message;
            }

            return retorno;

        }
    }



}
