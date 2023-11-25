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
    public partial class Doacoes : Form
    {
        public Doacoes()
        {
            InitializeComponent();
            populate();
            SanguePopulate();
        }
        private void Reset()
        {
            Dnametb.Text = "";
            DTipoTb.Text = "";
            

        }
        MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;");
        private void populate()
        {
            conexao.Open();
            string Querry = "SELECT * FROM bancodesangue.doadores;";
            MySqlDataAdapter sda = new MySqlDataAdapter(Querry, conexao);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            doadoresDGV.DataSource = ds.Tables[0];
            conexao.Close();
        }
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
        int oldEstoque;

        private void getEstoque(string tipo)
        {
            conexao.Open();
            string Querry = "SELECT * FROM bancodesangue.doacoes WHERE tipo = @Tipo";
            MySqlCommand cmd = new MySqlCommand(Querry, conexao);
            cmd.Parameters.AddWithValue("@Tipo", tipo);
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                oldEstoque = Convert.ToInt32(dr["quantidade"].ToString()); 
            }
            conexao.Close();
        }


        private void doadoresDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dnametb.Text = doadoresDGV.SelectedRows[0].Cells[1].Value.ToString();
            DTipoTb.Text = doadoresDGV.SelectedRows[0].Cells[6].Value.ToString();
            getEstoque(DTipoTb.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Dnametb.Text == "")
            {
                MessageBox.Show("Selecione o doador");
            }
            else
            {
                try
                {
                    int estoque = oldEstoque + 1;
                    using (MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;"))
                    {
                        string query ="UPDATE doacoes SET quantidade = @Quantidade WHERE tipo = @Tipo";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@Tipo", DTipoTb.Text);
                            cmd.Parameters.AddWithValue("@Quantidade", estoque);

                            conexao.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Adicionado com Sucesso");
                            conexao.Close();
                            Reset();
                            SanguePopulate();

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
