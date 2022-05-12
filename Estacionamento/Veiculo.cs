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
    public partial class Veiculo : Form
    {
        Auto aut;
        
        public Veiculo()
        {
            aut = new Auto("Estacionamento");
           
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            string placa = Placavei();
            string modelo = Movei();
            string cor = Corvei();
            aut.inserirVeiculo(placa, modelo, cor);
            aut.VetorAuto();

        }//Metodos estão dentro do forms 2

        public string Placavei()
        {
            return textBox1.Text;
        }
        public string Movei()
        {
            return textBox2.Text;
        }

        public string Corvei()
        {
            return textBox3.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }

}
