using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class Form2 : Form
    {
        Cadastro cadas;
        
        public Form2()
        {
            
            cadas = new Cadastro("Estacionamento");
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public string ConteudoTextBox()
        {
            return textBox1.Text;
        }//Fim do metodo para textBox1

        public string ConteTexCPF()
        {
            return textBox2.Text;
        }//Fim do método para textbox2

        public string ConteTexTele()
        {
            return textBox3.Text;
        }//Fim do método prara textbox3

        private void Salvar_Click(object sender, EventArgs e)
        {
            string nome = ConteudoTextBox();
            long cpf = Convert.ToInt64(ConteTexCPF());
            string telefone = ConteTexTele();
            cadas.Inserir(cpf, nome, telefone);
           
        }//Fim do botão Salvar

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }//Fim da classe
}//Fim do Projeto
