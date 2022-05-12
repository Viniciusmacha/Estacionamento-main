using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Estacionamento
{
    class Auto

    {//Criação de Variavel  
        MySqlConnection conexao;
        public string resultado;
        public string dados;
        public int[] cod;
        public string[] modelo;
        public string[] cor;
        public string msg;
        public string[] placa;
        public int i;
        public int contador = 0;




        public Auto(string Estacionamento)
        {
            conexao = new MySqlConnection("server=localhost;DataBase=" + Estacionamento + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados

            }
            catch (Exception e)// Se caso der Algum erro no Banco de dados
            {
                Console.WriteLine("Algo deu Errado Como Assim!!\n\n" + e); // Erro Tecnico
                conexao.Close(); // Fechando a conexão com banco de dados 
            }//Fim da tentativa de conexão com banco de dados
        }//Fim do Contrutor


        public void inserirVeiculo(string placa, string modelo, string cor)
        {
            try
            {
                dados = "('" + placa + "','" + modelo + "','" + cor + "')";
                resultado = "insert into veiculos(placa,modelo,cor) values" + dados;
                // EXECULTAR O COMANDO RESULTADO NO BANCO DE DADOS
                MySqlCommand sql = new MySqlCommand(resultado, conexao); // VAI ESTRAR NO PROGRAMA NO BANCO DE DADOS "CONEXÃO"
                resultado = "" + sql.ExecuteNonQuery();// EXECULTAR E GUARDAR O " RESULTADO ", CONTRA O ENTER DO BANCO DE DADOS.
                Console.WriteLine(resultado);

            }
            catch (Exception erro)
            {
                Console.WriteLine("Algo deu Errado Aqui!\n\n" + erro);
            }//Fim do try catch
        }//Fim do metoro inserir veiculo

        public void VetorAuto()
        {
            string query = "select * from Veiculo";

            cod = new int[100];
            placa = new string[9];
            modelo = new string[50];
            cor = new string[50];

            for (i = 0; i < 100; i++)
            {
                cod[i] = 0;
                placa[i] = "";
                modelo[i] = "";
                cor[i] = "";
            }                
                //Criar o comando para coleta de dados
                MySqlCommand coletar = new MySqlCommand(query, conexao);
                //Usar o comando lendo os dados do banco
                MySqlDataReader leitura = coletar.ExecuteReader();

                i = 0;
                while (leitura.Read())
                {
                    cod[i] = Convert.ToInt32(leitura["''"] + "");
                    placa[i] = leitura["placa"] + "";
                    modelo[i] = leitura["modelo"] + "";
                    cor[i] = leitura["cor"] + "";


                    i++;
                    contador++;
                }//fim do while
                //Fechar o dataReader
                leitura.Close();      
            

        }//Fim preencher vetor     


        public string ConsultarTudo()
        {
            //Preencher o vetor
            VetorAuto();
            msg = "";
            for (long i = 0; i < contador; i++)
            {
                msg += "\n\ncodigo: " + cod[i]
                + ", Placa: " + placa[i]
                + ", Modelo: " + modelo[i]
                + ", Cor: " + cor[i];


            }//fim do for
            return msg;
        }//fim do consultarTudo



        public long ConsultarCodigo(long codd)
        {
            VetorAuto();
            for (long i = 0; i < contador; i++)
            {
                if (codd == cod[i])
                {
                    return cod[i];
                }
            }//fim do for
            return -1;
        }//fim do consultarcpf



        public string ConsultarPlaca(string codd)
        {
            VetorAuto();
            for (long i = 0; i < contador; i++)
            {
                if (codd == placa[i])
                {
                    return placa[i];
                }
            }//fim do for
            return "Nome não encontrado";
        }//fim do consultarnome

        public string ConsultarModelo(string codd)
        {
            VetorAuto();
            for (long i = 0; i < contador; i++)
            {
                if (codd == modelo[i])
                {
                    return modelo[i];
                }
            }//fim do for
            return "Nome não encontrado";
        }//fim do consultarnome



        public string ConsultarCor(string codd)
        {
            VetorAuto();
            for (long i = 0; i < contador; i++)
            {
                if (codd == cor[i])
                {
                    return cor[i];
                }
            }//fim do for
            return "Telefone não encontrado!";



        }//Fim do consultar telefone





        public void Atualizar(string campo, string novoDado, string codigo)
        {
            try
            {
                resultado = "update pessoa set " + campo + " = '" +
                novoDado + "' where codigo = '" + codigo + "'";
                //Executar o script
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com Sucesso!");
            }



            catch (Exception e)
            {



                Console.WriteLine("Algo deu errado!" + e);



            }//fim do atualizar



        }




        public void Deletar(string codd)
        {



            resultado = "delete from pessoa where codigo = '" + cod + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");




        } //fim do deletar






    }//fim da classe
}//fim do projeto






  
