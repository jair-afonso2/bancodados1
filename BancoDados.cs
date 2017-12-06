using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD
{
    public class BancoDados
    {
        SqlConnection cn;
        SqlCommand comandos;
        SqlDataReader rd;
        private Categoria categoria;

        public BancoDados(Categoria categoria)
        {
            this.categoria = categoria;
        }

        public BancoDados()
        {
        }

        public bool Adicionar(Categoria cat)
        {
            bool retorno = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;Password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "insert into categorias(titulo)values(@vt)";
                comandos.Parameters.AddWithValue("@vt", cat.Titulo);

                int resultado = comandos.ExecuteNonQuery();
                if (resultado > 0)
                    retorno = true;

                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar cadastrar. " + se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }

        public bool Atualizar(Categoria cat)
        {
            bool retorno = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;Password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "update categorias set titulo=@vt where idcategoria=@vi";
                comandos.Parameters.AddWithValue("@vt", cat.Titulo);
                comandos.Parameters.AddWithValue("@vi", cat.IdCategoria);

                int resultado = comandos.ExecuteNonQuery();
                if (resultado > 0)
                    retorno = true;

                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar. " + se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }

        public bool Apagar(Categoria cat)
        {
            bool retorno = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;Password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "delete from categorias where idcategoria=@vi";
                comandos.Parameters.AddWithValue("@vi", cat.IdCategoria);

                int resultado = comandos.ExecuteNonQuery();
                if (resultado > 0)
                    retorno = true;

                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar apagar. " + se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return retorno;
        }

        public List<Categoria> ListarCategorias(int id)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;Password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "Select * from categorias where idcategoria=@vi";
                comandos.Parameters.AddWithValue("@vi", id);
                rd = comandos.ExecuteReader();

                while (rd.Read())
                {
                    lista.Add(new Categoria { IdCategoria = rd.GetInt32(0), Titulo = rd.GetString(1) });
                }
                comandos.Parameters.Clear();

            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar listar. " + se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public List<Categoria> ListarCategorias(string titulo)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;Password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "Select * from categorias where titulo like @vt";
                comandos.Parameters.AddWithValue("@vt", titulo);
                rd = comandos.ExecuteReader();

                while (rd.Read())
                {
                    lista.Add(new Categoria { IdCategoria = rd.GetInt32(0), Titulo = rd.GetString(1) });
                }
                comandos.Parameters.Clear();

            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar listar. " + se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public bool AdicionarCliente(Cliente cliente)
        {
            bool rs = false;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User id=sa;Password=senai@123";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;

                comandos.CommandType = CommandType.StoredProcedure;
                comandos.CommandText = "sp_cadCliente";

                SqlParameter pnome = new SqlParameter("@nome",SqlDbType.VarChar,50);
                SqlParameter pemail = new SqlParameter("@email",SqlDbType.VarChar,100);
                SqlParameter pcpf = new SqlParameter("@cpf",SqlDbType.VarChar,20);

                pnome.Value = cliente.NomeCliente;
                pemail.Value = cliente.Email;
                pcpf.Value = cliente.Cpf;

                comandos.Parameters.Add(pnome);
                comandos.Parameters.Add(pemail);
                comandos.Parameters.Add(pcpf);

                int r = comandos.ExecuteNonQuery();

                if(r>0)
                    rs = true;

                comandos.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar inserir os dados. " + se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado. " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return rs;
        }      
    }
}