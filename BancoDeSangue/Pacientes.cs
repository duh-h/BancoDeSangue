using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
namespace BancoDeSangue
{
    public partial class Pacientes : Form
    {
        public Pacientes()
        {
            InitializeComponent();
        }

        MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;");
        private void Reset()
        {
            Dnametb.Text = "";
            DIdadeTb.Text = "";
            DGeneroCb.SelectedIndex = -1;
            DNumeroTb.Text = "";
            DenderecoTB.Text = "";
            DtipoCB.SelectedIndex = -1;

        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Dnametb.Text == "" || DNumeroTb.Text == "" || DIdadeTb.Text == "" || DGeneroCb.SelectedIndex == -1 || DtipoCB.SelectedIndex == -1)
            {
                MessageBox.Show("Dados Incopletos");
            }
            else
            {
                try
                {

                    using (MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;"))
                    {
                        string query = "INSERT INTO pacientes (nome, idade, genero, numero, endereco, tipo) " +
                                       "VALUES (@Nome, @Idade, @Genero, @Numero, @Endereco, @Tipo)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@Nome", Dnametb.Text);
                            cmd.Parameters.AddWithValue("@Idade", DIdadeTb.Text);
                            cmd.Parameters.AddWithValue("@Genero", DGeneroCb.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Numero", DNumeroTb.Text);
                            cmd.Parameters.AddWithValue("@Endereco", DenderecoTB.Text);
                            cmd.Parameters.AddWithValue("@Tipo", DtipoCB.SelectedItem.ToString());

                            conexao.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Salvo com Sucesso");
                            conexao.Close();
                            Reset();

                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            VisualizarPacientes Vp = new VisualizarPacientes();
            Vp.Show();
            this.Hide();
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

        private void label15_Click(object sender, EventArgs e)
        {
            Doacoes log = new Doacoes();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            estoqueDeSangue log = new estoqueDeSangue();
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


