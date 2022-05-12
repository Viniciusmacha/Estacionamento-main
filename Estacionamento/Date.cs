using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace Estacionamento
{



    class Model
    {
        MySqlConnection conexao;
        public Model()
        {


        }//Fim do construtor

        public DateTime MarcarHora()
        {
            DateTime diaHj = DateTime.Now;
            return diaHj;
        }

        internal static void ShowDialog()
        {
            
        }

        //Criar o método INSERIR
    }//Fim da classe
}//Fim do projeto