using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace Estacionamento
{
    class Cadastrar
    {
        MySqlConnection conexao;

        //Declarando os vetores:

        public string[] nome;
        public long[] cpf;
        public string[] telefone;
        public string dados;
        public string resultado;
        public int i;
        public string msg;
        public int contador = 0;
        //Contrutor
        public Cadastrar(string Estacionamento)
        {
            conexao = new MySqlConnection("server=localhost;DataBase=" + Estacionamento + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor

        //Criar o método INSERIR
        public void Inserir(long cpf, string nome, string telefone)
        {
            try
            {
                dados = "('" + cpf + "','" + nome + "','" + telefone + "')";
                resultado = "Insert into Cliente(cpf, nome, telefone) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");//temos que fazer um mensagem pop-up para mostrar que os dados foram salvos com sucesso!

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
            }//fim do catch
        }//fim do método inserir

        public void PreencherVetor()
        {
            string query = "select * from Cliente";//Coletando o dado do BD

            //Instanciando os vetores
            cpf = new long[100];
            nome = new string[100];
            telefone = new string[100];

            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                cpf[i] = 0;
                nome[i] = "";
                telefone[i] = "";

            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cpf[i] = Convert.ToInt64(leitura["cpf"] + "");
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";


                i++;
                contador++;
            }//fim do while

            //Fechar o dataReader
            leitura.Close();
        }//fim do preencher Vetor

        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (long i = 0; i < contador; i++)
            {
                msg += "\n\nCpf: " + cpf[i]
                    + ", Nome: " + nome[i]
                    + ", Telefone: " + telefone[i];

            }//fim do for
            return msg;
        }//fim do consultarTudo

        public long ConsultarCpf(long ccpf)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (ccpf == cpf[i])
                {
                    return cpf[i];
                }
            }//fim do for
            return -1;
        }//fim do consultarcpf

        public string ConsultarNome(string ccpf)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (ccpf == nome[i])
                {
                    return nome[i];
                }
            }//fim do for
            return "Nome não encontrado";
        }//fim do consultarnome

        public string ConsultarTelefone(string ccpf)
        {
            PreencherVetor();
            for (long i = 0; i < contador; i++)
            {
                if (ccpf == telefone[i])
                {
                    return telefone[i];
                }
            }//fim do for
            return "Telefone não encontrado!";

        }//Fim do consultar telefone



        public void Atualizar(string campo, string novoDado, long codigo)
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


        public void Deletar(long cpf)
        {

            resultado = "delete from pessoa where codigo = '" + cpf + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");


        } //fim do deletar




    }//fim da classe
}//fim do projeto