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
    public partial class VisualizarPacientes : Form
    {
        public VisualizarPacientes()
        {
            InitializeComponent();
            populate();
        }
        private void Reset()
        {
            PNomeTb.Text = "";
            PIdadeTb.Text = "";
            PGeneroCb.SelectedIndex = -1;
            PNumeroTb.Text = "";
            PEnderecoTb.Text = "";
            PTipoCb.SelectedIndex = -1;
            key = 0;

        }
        MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;");
        private void populate()
        {
            conexao.Open();
            string Querry = "SELECT * FROM bancodesangue.pacientes;";
            MySqlDataAdapter sda = new MySqlDataAdapter(Querry, conexao);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PacientesDGV.DataSource = ds.Tables[0];
            conexao.Close();
        }
        int key = 0;

        private void PacientesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PNomeTb.Text = PacientesDGV.SelectedRows[0].Cells[1].Value.ToString();
            PIdadeTb.Text = PacientesDGV.SelectedRows[0].Cells[2].Value.ToString();
            PNumeroTb.Text = PacientesDGV.SelectedRows[0].Cells[4].Value.ToString();
            PGeneroCb.SelectedItem = PacientesDGV.SelectedRows[0].Cells[3].Value.ToString();
            PTipoCb.SelectedItem = PacientesDGV.SelectedRows[0].Cells[6].Value.ToString();
            PEnderecoTb.Text = PacientesDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (PNomeTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PacientesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Selecione um paciente");
            }
            else
            {
                try
                {

                    using (MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;"))
                    {
                        string query = "DELETE FROM pacientes WHERE id = @Id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@Id", key);

                            conexao.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deletado com Sucesso");
                            conexao.Close();
                            Reset();
                            populate();

                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Pacientes pacientes = new Pacientes();
            pacientes.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PNomeTb.Text == "" || PNumeroTb.Text == "" || PIdadeTb.Text == "" || PGeneroCb.SelectedIndex == -1 || PTipoCb.SelectedIndex == -1)
            {
                MessageBox.Show("Dados incopletos");
            }
            else
            {
                try
                {

                    using (MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;"))
                    {
                        string query = "UPDATE pacientes SET nome = @Nome, idade = @Idade, genero = @Genero, numero = @Numero, endereco = @Endereco, tipo = @Tipo WHERE id = @Id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@Id", key);
                            cmd.Parameters.AddWithValue("@Nome", PNomeTb.Text);
                            cmd.Parameters.AddWithValue("@Idade", PIdadeTb.Text);
                            cmd.Parameters.AddWithValue("@Genero", PGeneroCb.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Numero", PNumeroTb.Text);
                            cmd.Parameters.AddWithValue("@Endereco", PEnderecoTb.Text);
                            cmd.Parameters.AddWithValue("@Tipo", PTipoCb.SelectedItem.ToString());

                            conexao.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Editado com Sucesso");
                            conexao.Close();
                            Reset();
                            populate();

                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
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