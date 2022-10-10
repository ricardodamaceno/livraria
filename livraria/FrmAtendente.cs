﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace livraria
{
    public partial class FrmAtendente : UserControl
    {
        public FrmAtendente()
        {
            InitializeComponent();
        }

        //conecxão com banco de dados (SSPI = autenticação do windows)
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-OOSH39D\SQLEXPRESS;integrated security=SSPI;initial Catalog=db_livraria");

        //para dar os comandos sql
        //SqlCommand cm = new SqlCommand();

        //serve para fazer uma busca no banco de dados após um select
        SqlDataReader dr;

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
            txtNome.Focus();
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
            else
            {
                try
                {
                    string nome = txtNome.Text;
                    string login = txtLogin.Text;
                    string senha = txtSenha.Text;

                    string sql = "insert into tbl_atendente(ds_Login, ds_Senha, nm_atendente)values(@login,@senha,@atendente)";

                    SqlCommand cm = new SqlCommand(sql, cn);

                    cm.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    cm.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                    cm.Parameters.Add("@atendente", SqlDbType.VarChar).Value = nome;

                    cn.Open();
                    cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)
                    MessageBox.Show("Os dados foram gravados com sucesso!", "Inserção de dados concluído.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.Focus();
                    limparCampos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    cn.Close();
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }

}
