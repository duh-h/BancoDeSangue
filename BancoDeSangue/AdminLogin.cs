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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ALSenhaTb.Text == "")
            {
                MessageBox.Show("Coloque a senha");
            }else if (ALSenhaTb.Text == "senha")
            {
                Cadastrar log = new Cadastrar();
                log.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Senha Invalida");
                ALSenhaTb.Text = "";
            }
        }
    }
}
