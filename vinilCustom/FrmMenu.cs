using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vinilCustom
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            login telaLogin = new login();
            telaLogin.Show();
            this.Hide();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            usuarioLogado.Text = login.usuario;
            principal1.BringToFront();
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            frmAtendente2.BringToFront();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCliente2.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            principal1.BringToFront();
        }
    }
}
