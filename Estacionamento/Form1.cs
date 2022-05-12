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
   
    public partial class Form1 : Form
    {
        Form2 form;
        
        public Form1()

        {
            form = new Form2();
            InitializeComponent();

        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            Visible = true;
            form.ShowDialog(); //"" +Seja Bem Vindo ao Estacionamento Senac!!!
            Visible = false;
          

        }//Conexão com o formulario 2

        private void Entrada_Click(object sender, EventArgs e)
        {
            Visible = true;
            Model.ShowDialog();
            MessageBox.Show(Convert.ToString(DateTime.Now));

            Visible = false;


        }

        private void Saida_Click(object sender, EventArgs e)
        {
            Visible = true;
            MessageBox.Show(Convert.ToString(DateTime.Now));
            Visible = false;

        }
    }
}
