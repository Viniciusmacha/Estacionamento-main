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
        
        Form2 usua;
        public Form1()

        {
            
            usua = new Form2();
            InitializeComponent();

        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            Visible = true;
            usua.ShowDialog();
            Visible = false;
          

        }//Fim do método Cadastrar, devemos conectar com a base de dados dentro do texBox1.Text

        private void Entrada_Click(object sender, EventArgs e)
        {
           
        }

        private void Saida_Click(object sender, EventArgs e)
        {

        }
    }
}
