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
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
            populate();
        }
        private void Reset()
        {
            CNomeTb.Text = "";
            CSenhaTb.Text = "";
            key = 0;

        }
        MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;");
        private void populate()
        {
            conexao.Open();
            string Querry = "SELECT * FROM bancodesangue.usuarios;";
            MySqlDataAdapter sda = new MySqlDataAdapter(Querry, conexao);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            doadoresDGV.DataSource = ds.Tables[0];
            conexao.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        int key = 0;

       


        private void button1_Click(object sender, EventArgs e)
        {
            if (CNomeTb.Text == "" || CSenhaTb.Text == "")
            {
                MessageBox.Show("Dados Incompletos");
            }
            else
            {
                try
                {

                    using (MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;"))
                    {
                        string query = "INSERT INTO usuarios (nome, senha) " +
                                       "VALUES (@Nome, @Senha)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@Nome", CNomeTb.Text);
                            cmd.Parameters.AddWithValue("@Senha", CSenhaTb.Text);
                            

                            conexao.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Salvo com Sucesso");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (CNomeTb.Text == "" || CSenhaTb.Text == "")
            {
                MessageBox.Show("Dados incompletos");
            }
            else
            {
                try
                {

                    using (MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;"))
                    {
                        string query = "UPDATE usuarios SET nome = @Nome, senha = @Senha WHERE id = @Id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("@Id", key);
                            cmd.Parameters.AddWithValue("@Nome", CNomeTb.Text);
                            cmd.Parameters.AddWithValue("@Senha", CSenhaTb.Text);
                           

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

        private void button3_Click(object sender, EventArgs e)
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
                        string query = "DELETE FROM usuarios WHERE id = @Id";

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

        private void doadoresDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CNomeTb.Text = doadoresDGV.SelectedRows[0].Cells[1].Value.ToString();
            CSenhaTb.Text = doadoresDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (CNomeTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(doadoresDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
    
    
}

