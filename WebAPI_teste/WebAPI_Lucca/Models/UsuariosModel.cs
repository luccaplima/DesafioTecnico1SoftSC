using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Lucca.Util;

namespace WebAPI_Lucca.Models
{
    public class UsuariosModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string data_cadastro { get; set; }

        public List <UsuariosModel> Listagem()
        {
            List<UsuariosModel> lista = new List<UsuariosModel>();
            UsuariosModel item;

            DAL objDAL = new DAL();

            string sql = "SELECT * FROM Usuarios order by id asc";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new UsuariosModel()
                {
                    id = int.Parse(dados.Rows[i]["id"].ToString()),
                    nome = dados.Rows[i]["nome"].ToString(),
                    email = dados.Rows[i]["email"].ToString(),
                    telefone = dados.Rows[i]["telefone"].ToString(),
                    data_cadastro = DateTime.Parse(dados.Rows[i]["data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                };
                lista.Add(item);
            }
        
            return lista;
        }

        public UsuariosModel RetornarUsuario(int id)
        {
            UsuariosModel item;
            DAL objDAL = new DAL();

            string sql = $"SELECT * FROM Usuarios where id = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);

            item = new UsuariosModel()
            {
                id = int.Parse(dados.Rows[0]["id"].ToString()),
                nome = dados.Rows[0]["nome"].ToString(),
                email = dados.Rows[0]["email"].ToString(),
                telefone = dados.Rows[0]["telefone"].ToString(),
                data_cadastro = DateTime.Parse(dados.Rows[0]["data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
            };

            return item;
        }

        public void RegistrarUsuario()
        {
            DAL objDAL = new DAL();
            string sql = "INSERT INTO Usuarios(nome, email, telefone, data_cadastro)" + $"values ('{nome}', '{email}','{telefone}', '{DateTime.Parse(data_cadastro).ToString("yyyy/MM/dd")}')";
            objDAL.ExecutarComandosSQL(sql);
        }

        public void Excluir(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"DELETE FROM Usuarios WHERE id={id}";
            objDAL.ExecutarComandosSQL(sql);
        }

    }
}
