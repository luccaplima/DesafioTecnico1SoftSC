using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebAPI_Lucca.Util
{
    // data access layer
    public class DAL
    {
        private static string Server = "localhost";
        private static string DataBase = "dbUsuarios";
        private static string User = "root";
        private static string Password = "";
        private static string Port = "3307";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={DataBase};Userid={User};Password={Password};Port={Port};Sslmode=none;";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }


        //retornar dados
        public DataTable RetornarDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdapter.Fill(Dados);

            return Dados;
        }

        //executa comandos no banco de dados mysql
        public void ExecutarComandosSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

    }
}
