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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin log = new AdminLogin();
            log.Show();
            this.Hide();
        }
        MySqlConnection conexao = new MySqlConnection("Server=Lenovo;Database=bancodesangue;Uid=carlos;Pwd=root;");

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(*) FROM usuarios WHERE nome = @Nome AND senha = @Senha";

            using (MySqlCommand cmd = new MySqlCommand(query, conexao))
            {
                cmd.Parameters.AddWithValue("@Nome", LNomeTb.Text);
                cmd.Parameters.AddWithValue("@Senha", LSenhaTb.Text);

                conexao.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar()); 

                if (count == 1)
                {
                    Doadores mainForm = new Doadores();
                    mainForm.Show();
                    this.Hide();
       
                }
                else
                {
                    MessageBox.Show("Nome ou Senha Inválidos");
                }

                conexao.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
