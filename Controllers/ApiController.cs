using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;

namespace Forum.Controllers
{
    public class ApiController : Controller
    {
        Postagem postagem = new Postagem();
        Usuario usuario = new Usuario();
        Topico topico = new Topico();
        DAOForum forum = new DAOForum();

        // usuário ------------------------------------------------------------------------

        [HttpGet]
        [Route("api/usuariolistar")]
        public IEnumerable<Usuario> Listar(){
            return forum.ListarUsuario();
        }

        [HttpGet("{id}")]
        [Route("api/usuariobuscar/{id}")]
        public Usuario Busca(int id){
            return forum.ListarUsuario().Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("api/usuariocadastrar")]
        public IActionResult Cadastra([FromBody] Usuario usuario){
           forum.CadastrarUsuario(usuario);
           return Ok();
        }
        
        [HttpPut]
        [Route("api/usuarioalterar")]
        public IActionResult Update([FromBody] Usuario usuario){
           forum.UpdateUsuario(usuario);
           return Ok();
        }

        [HttpDelete]
        [Route("api/usuariodeletar")]
        public void Delete([FromBody] Usuario usuario){
           forum.DeletarUsuario(usuario.Id);
        }


        // topico ------------------------------------------------------------------------

        [HttpGet]
        [Route("api/topicolistar")]
        public IEnumerable<Topico> ListarTopico(){
            return forum.ListarTopico();
        }

        [HttpGet("{id}")]
        [Route("api/topicobuscar/{id}")]
        public Topico BuscaTopico(int id){
            return forum.ListarTopico().Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("api/topicocadastrar")]
        public IActionResult Cadastra([FromBody] Topico topico){
           forum.CadastrarTopico(topico);
           return Ok();
        }
        
        [HttpPut]
        [Route("api/topicoalterar")]
        public IActionResult Update([FromBody] Topico topico){
           forum.UpdateTopico(topico);
           return Ok();
        }

        [HttpDelete]
        [Route("api/topicodeletar")]
        public void Delete([FromBody] Topico topico){
           forum.DeletarTopico(topico.Id);
        }

        // postagem ------------------------------------------------------------------------

        [HttpGet]
        [Route("api/postagemlistar")]
        public IEnumerable<Postagem> ListarPostagem(){
            return forum.ListarPostagem();
        }

        [HttpGet("{id}")]
        [Route("api/postagembuscar/{id}")]
        public Postagem BuscaPostagem(int id){
            return forum.ListarPostagem().Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("api/postagemcadastrar")]
        public IActionResult Cadastra([FromBody] Postagem postagem){
           forum.CadastrarPostagem(postagem);
           return Ok();
        }
        
        [HttpPut]
        [Route("api/postagemalterar")]
        public IActionResult Update([FromBody] Postagem postagem){
           forum.UpdatePostagem(postagem);
           return Ok();
        }

        [HttpDelete]
        [Route("api/topicodeletar")]
        public void Delete([FromBody] Postagem postagem){
           forum.DeletarPostagem(postagem.Id);
        }
                   
    }
}