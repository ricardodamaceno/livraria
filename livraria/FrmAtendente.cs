using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace livraria
{
    public partial class FrmAtendente : UserControl
    {
        public FrmAtendente()
        {
            InitializeComponent();
        }

        private void desabilitaCampos()
        {
            txtNome.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            btnAlterar.Enabled = false;
            btnGravar.Enabled = false;
            btnRemover.Enabled = false;
            btnCancelar.Enabled = false;
            btnNovo.Enabled = true;
        }

        private void habilitaCampos()
        {
            txtNome.Enabled = true;
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
            btnGravar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNovo.Enabled = false;
            txtNome.Focus();
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtLogin.Clear();
            txtSenha.Clear();
        }

        private void FrmAtendente_Load(object sender, EventArgs e)
        {
            desabilitaCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitaCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitaCampos();
            limparCampos();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo nome", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
            }
            else if(txtLogin.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo login", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo senha", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
            }
            else if (txtSenha.TextLength < 8)
            {
                MessageBox.Show("O campo senha deve conter no mínimo 8 caracteres", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Focus();
            }
        }
    }

}
