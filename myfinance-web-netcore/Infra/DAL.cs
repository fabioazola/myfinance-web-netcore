using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace myfinance_web_netcore.Infra
{
    public class DAL
    {
        private SqlConnection conn;

        private string connectionString;

        public static IConfiguration? Configuration;

        private static DAL? Instancia;

        //DesignerPartiner singleton
        public static DAL GetInstancia
        {

            get{
                if (Instancia == null)
                    Instancia = new();

                return Instancia;
            }
        }

        public DAL()
        {
            //ConnectionString - o valor esta no arquivio appsetings.json

            connectionString = Configuration.GetValue<string>("ConnectionString");
        }

        public void Conectar()
        {
            conn =  new();
            conn.ConnectionString = connectionString;
            conn.Open();
        }

        public void Desconectar()
        {
            conn.Close();
        }

        public DataTable RetornarDataTable(string sql)
        {
            var dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dataTable);
            return dataTable;
        }

        //INSERT, UPDATE, DELETE
        public void ExecutarCommandoSQL(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, conn);
            //transação
            comando.ExecuteNonQuery();


        }

    }
}

