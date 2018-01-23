using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace Forum.Models
{
    public class DAOForum
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;
        string conexao = @"Data Source=.\SqlExpress;Initial Catalog=forum;user id=sa; password=senai@123";  

        public bool ValidaLogin(string user, string pass){
            bool resultado = false;

            try{
               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "SELECT * FROM usuario WHERE login='"+user+"' AND senha='"+pass+"'";

               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;  

        }

        public System.Collections.Generic.List<Usuario> ListarUsuario(){
            
            List<Usuario> usuario = new List<Usuario>();
            try{
               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "SELECT * FROM usuario";
               rd = cmd.ExecuteReader();

                while(rd.Read()){
                    usuario.Add(new Usuario(){
                        Id           = rd.GetInt32(0),
                        Nome         = rd.GetString(1),
                        Login        = rd.GetString(2),
                        Senha        = rd.GetString(3),
                        DataCadastro = rd.GetDateTime(4)
                    });
                }

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return usuario;
        }

        public System.Collections.Generic.List<Topico> ListarTopico(){
            
            List<Topico> topico = new List<Topico>();
            try{
               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "SELECT * FROM topicoforum";
               rd = cmd.ExecuteReader();

                while(rd.Read()){
                    topico.Add(new Topico(){
                        Id           = rd.GetInt32(0),
                        Titulo       = rd.GetString(1),
                        Descricao    = rd.GetString(2),
                        DataCadastro = rd.GetDateTime(3)
                    });
                }

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return topico;
        }

        public System.Collections.Generic.List<Postagem> ListarPostagem(){
            
            List<Postagem> postagem = new List<Postagem>();
            try{
               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "SELECT postagem.*, usuario.nome,"+
               "topicoforum.titulo, topicoforum.descricao, topicoforum.datacadastro AS datatopico FROM postagem"+
               "INNER JOIN usuario ON usuario.id = postagem.idusuario"+
               "INNER JOIN topicoforum ON topicoforum.id = postagem.idtopico";
               rd = cmd.ExecuteReader();

                while(rd.Read()){
                    postagem.Add(new Postagem(){
                        Id                 = rd.GetInt32(0),
                        IdTopico           = rd.GetInt32(1),
                        IdUsusario         = rd.GetInt32(2),
                        Mensagem           = rd.GetString(3),
                        DataCadastro       = rd.GetDateTime(4),
                        UsuarioNome        = rd.GetString(5),
                        TopicoTitulo       = rd.GetString(6),
                        TopicoDescricao    = rd.GetString(7),
                        TopicoDataCAdastro = rd.GetDateTime(8)
                    });
                }

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return postagem;
        }

        public bool CadastrarUsuario(Usuario usuario){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "INSERT INTO usuario (nome, login, senha, datacadastro) VALUES "+
               "('"+usuario.Nome+"','"+usuario.Login+"',"+usuario.Senha+", GETDATE())";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }

        public bool CadastrarTopico(Topico topico){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "INSERT INTO topicoforum (titulo, descricao, datacadastro) VALUES "+
               "('"+topico.Titulo+"','"+topico.Descricao+"', GETDATE())";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }

        public bool CadastrarPostagem(Postagem postagem){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "INSERT INTO postagem (idtopico, idusuario, mensagem, datapublicacao) VALUES "+
               "('"+postagem.IdTopico+"', '"+postagem.IdUsusario+"', '"+postagem.Mensagem+"', GETDATE())";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }


        public bool UpdateUsuario(Usuario usuario){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "UPDATE usuario SET nome = '"+usuario.Nome+"', login = '"+usuario.Login+"', senha='"+usuario.Senha+"' WHERE id = "+usuario.Id+"";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }

        public bool UpdateTopico(Topico topico){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "UPDATE topicoforum SET titulo = '"+topico.Titulo+"', descricao = '"+topico.Descricao+"', datacadastro='"+topico.DataCadastro+"' WHERE id = "+topico.Id+"";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }

        public bool UpdatePostagem(Postagem postagem){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "UPDATE postagem SET idtopico = '"+postagem.IdTopico+"', idusuario = '"+postagem.IdUsusario+"' , "+
               "mensagem = '"+postagem.Mensagem+"', descricao = '"+postagem.Descricao+"', datapublicacao='"+postagem.DataCadastro+"' WHERE id = "+postagem.Id+"";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }

        public bool DeletarUsuario(int id){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "DELETE FROM usuario WHERE id = '"+id+"'";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }

        public bool DeletarTopico(int id){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "DELETE FROM topicoforum WHERE id = '"+id+"'";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }

        public bool DeletarPostagem(int id){
            bool resultado = false;

            try{

               con = new SqlConnection();
               con.ConnectionString  = conexao;
               con.Open();
               cmd = new SqlCommand();
               cmd.Connection  = con;
               cmd.CommandType = CommandType.Text;
               cmd.CommandText = "DELETE FROM postagem WHERE id = '"+id+"'";
               
               int r =  cmd.ExecuteNonQuery();
               if(r > 0){
                   resultado = true;
               }

               cmd.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception(se.Message);
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }finally{
                con.Close();
            }

            return resultado;
        }


    }
}