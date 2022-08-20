using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {
        public int Id {get; set;}

        public string Descricao {get; set;}

        public string Tipo {get; set;}

        public PlanoContaModel()
		{
			Id = 0;
			Descricao = "";
			Tipo = "";
		}
			
		
		
        public List<PlanoContaModel> ListaPlanoContas()
        {
            List<PlanoContaModel> lista = new List<PlanoContaModel>();
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = "Select id, descricao, tipo from plano_contas";
            var dataTable = objDAL.RetornarDataTable(sql);

            for (int i=0; i< dataTable.Rows.Count; i++)
            {
                /*
				var plano_conta = new PlanoContaModel(){
                    Id = int.Parse (dataTable.Rows[i]["id"].ToString()),
                    Descricao = dataTable.Rows[i]["descricao"].ToString(),
                    Tipo = dataTable.Rows[i]["tipo"].ToString()                                        
                };*/
            }

            return lista;
        }

    }
}
