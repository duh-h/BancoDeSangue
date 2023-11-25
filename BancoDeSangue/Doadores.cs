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
    public partial class Doadores : Form
    {
        public Doadores()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            PNameTb.Text = "";
            PIdadeTb.Text = "";
            PGeneroCb.SelectedIndex = -1;
            PNumeroTb.Text = "";
            PEnderecoTb.Text = "";
            PTipoCb.SelectedIndex = -1;

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (PNameTb.Text == "" || PNumeroTb.Text == "" || PIdadeTb.Text == "" || PGeneroCb.SelectedIndex == -1 || PTipoCb.SelectedIndex == -1)
            {
                MessageBox.Show("Dados Incopletos");
            }
            else
            {
                try
                {

                    using (MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;"))
                    {
                        string query = "INSERT INTO doadores (nome, idade, genero, numero, endereco, tipo) " +
                                       "VALUES (@Nome, @Idade, @Genero, @Numero, @Endereco, @Tipo)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@Nome", PNameTb.Text);
                            cmd.Parameters.AddWithValue("@Idade", PIdadeTb.Text);
                            cmd.Parameters.AddWithValue("@Genero", PGeneroCb.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Numero", PNumeroTb.Text);
                            cmd.Parameters.AddWithValue("@Endereco", PEnderecoTb.Text);
                            cmd.Parameters.AddWithValue("@Tipo", PTipoCb.SelectedItem.ToString());

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
    

