using System;

namespace Forum.Models
{
    public class Postagem
    {
        public int Id { get; set; }
        public int IdTopico { get; set; }
        public int IdUsusario { get; set; }
        public string Mensagem { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }


        public string TopicoTitulo { get; set; }
        public string TopicoDescricao { get; set; }
        public DateTime TopicoDataCAdastro { get; set; }
        

        public string UsuarioNome { get; set; }

    }
}