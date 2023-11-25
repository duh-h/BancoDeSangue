using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeSangue
{
    public partial class estoqueDeSangue : Form
    {
        public estoqueDeSangue()
        {
            InitializeComponent();
            SanguePopulate();
        }
        MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;");
        
        private void SanguePopulate()
        {
            conexao.Open();
            string Querry = "SELECT * FROM bancodesangue.doacoes;";
            MySqlDataAdapter sda = new MySqlDataAdapter(Querry, conexao);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            estoqueDGV.DataSource = ds.Tables[0];
            conexao.Close();
        }

        private void estoqueDeSangue_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Doadores log = new Doadores();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            VisualizarDoadores log = new VisualizarDoadores();
            log.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Doacoes log = new Doacoes();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Pacientes log = new Pacientes();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            VisualizarPacientes log = new VisualizarPacientes();
            log.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashbord log = new Dashbord();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
