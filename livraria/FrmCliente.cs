using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.VisualBasic.Devices;

namespace livraria
{
    public partial class FrmCliente : UserControl
    {
        public FrmCliente()
        {
            InitializeComponent();
            desabilitaCampos();
        }

        //conecxão com banco de dados (SSPI = autenticação do windows)
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-OOSH39D\SQLEXPRESS;integrated security=SSPI;initial Catalog=db_livraria");

        //para dar os comandos sql
        SqlCommand cm = new SqlCommand();

        //serve para fazer uma busca no banco de dados após um select
        //SqlDataReader dr;

        private void cboPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPessoa.SelectedIndex == -1) //-1 no cbo é quando não tem nada marcado
            {
                lblCnpj.Visible = false;
                maskCnpj.Visible = false;
            }
            else if(cboPessoa.SelectedIndex == 0) //se estiver selecionado a primeira opção
            {
                lblCnpj.Visible = false;
                maskCnpj.Visible = false;
            }
            else
            {
                lblCnpj.Visible = true;
                maskCnpj.Visible = true;
            }
        }

        //metodos para quando clicar iniciar obrigatoriamente no começo
        private void maskCnpj_Click(object sender, EventArgs e)
        {
            if (maskCnpj.Text == "")
            {
                SendKeys.Send("{Home}");
            }
            
        }

        private void maskCpf_Click(object sender, EventArgs e)
        {
            if (maskCpf.Text == "")
            {
                SendKeys.Send("{Home}");
            }

        }

        private void maskCep_Click(object sender, EventArgs e)
        {
            if (maskCep.Text == "")
            {
                SendKeys.Send("{Home}");
            }

        }

        private void maskTelefone_Click(object sender, EventArgs e)
        {
            if (maskTelefone.Text == "")
            {
                SendKeys.Send("{Home}");
            }

        }

        //metodo para inserir apenas números no textBox
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }


        private void desabilitaCampos()
        {
            btnNovo.Enabled =true;
            btnGravar.Enabled = false;
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
            btnCancelar.Enabled = false;

            lblCodigo.Visible = false;
            lblCod.Visible = false;
            lblCnpj.Visible=false;

            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtLogradouro.Enabled = false;
            txtComplemento.Enabled = false;
            txtCidade.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;

            cboPessoa.Enabled = false;
            cboUF.Enabled = false;

            maskCep.Enabled = false;
            maskCnpj.Enabled = false;
            maskCpf.Enabled = false;
            maskTelefone.Enabled = false;
            maskCnpj.Visible = false;
            
        }

        private void habilitaCampos()
        {
            btnNovo.Enabled = false;
            btnGravar.Enabled = true;
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
            btnCancelar.Enabled = true;

            lblCodigo.Visible = false;
            lblCod.Visible = false;
            lblCnpj.Visible = false;

            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtLogradouro.Enabled = true;
            txtComplemento.Enabled = true;
            txtCidade.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;

            cboPessoa.Enabled = true;
            cboUF.Enabled = true;

            maskCep.Enabled = true;
            maskCnpj.Enabled = true;
            maskCpf.Enabled = true;
            maskTelefone.Enabled = true;
            maskCnpj.Visible = false;
        }

        private void limparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtLogradouro.Clear();
            txtComplemento.Clear();
            txtCidade.Clear();
            txtNumero.Clear();
            txtBairro.Clear();

            cboPessoa.SelectedIndex = -1;
            cboUF.SelectedIndex = -1;

            maskCep.Clear();
            maskCnpj.Clear();
            maskCpf.Clear();
            maskTelefone.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitaCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitaCampos();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (rdbInativo.Checked)
            {
                MessageBox.Show("Para inserir um cliente você precisa marcar o botão ATIVO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rdbAtivo.Checked = true;
            }
            else if(txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo NOME.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }
            else if(txtEmail.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo E-MAIL.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else if (maskTelefone.Text == "" || maskTelefone.Text.Length < 11)
            {
                MessageBox.Show("Obrigatório informar TELEFONE VÁLIDO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskTelefone.Focus();
            }
            else if(cboPessoa.SelectedIndex == -1)
            {
                MessageBox.Show("Obrigatório informar TIPO DE PESSOA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPessoa.Focus();
                cboPessoa.DroppedDown = true;
                
            }
            else if (cboPessoa.SelectedIndex == 0 && maskCpf.Text.Length < 11)
            {
                    MessageBox.Show("Obrigatório informar CPF VÁLIDO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maskCpf.Focus();
            }
            else if (cboPessoa.SelectedIndex == 1 && maskCnpj.Text.Length < 14)
            {
                    MessageBox.Show("Obrigatório informar CNPJ VÁLIDO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maskCnpj.Focus();
            }
            else if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo LOGRADOURO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogradouro.Focus();
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo NÚMERO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumero.Focus();
            }
            else if (txtBairro.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo BAIROO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBairro.Focus();
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo CIDADE.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCidade.Focus();
            }
            else if (maskCep.Text == "" || maskCep.Text.Length < 8)
            {
                MessageBox.Show("Obrigatório informar CEP VÁLIDO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCidade.Focus();
            }
            else if (cboUF.SelectedIndex == -1)
            {
                MessageBox.Show("Obrigatório informar o campo ESTADO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboUF.Focus();
                cboUF.DroppedDown = true;
            }
            else
            {
                try
                {
                    string nome = txtNome.Text;
                    string email = txtEmail.Text;
                    string telefone = maskTelefone.Text;
                    string cpf;
                    string cnpj;
                    string pessoa;
                    if(cboPessoa.SelectedIndex == 0)
                    {
                        pessoa = "F";
                        cpf = maskCpf.Text;
                        cnpj = "";
                    }
                    else
                    {
                        pessoa = "J";
                        cnpj = maskCnpj.Text;
                        cpf = "";
                    }

                    string logradouro = txtLogradouro.Text;
                    string numero = txtNumero.Text;
                    string complemento = txtComplemento.Text;
                    string bairro = txtBairro.Text; 
                    string cidade = txtCidade.Text;
                    string cep = maskCep.Text;
                    string uf = cboUF.SelectedItem.ToString();


                    string sql = "insert into tbl_cliente(nm_Cliente, ds_Email, no_CPF, no_CNPJ, nm_Logradouro, no_Logradouro, ds_Complemento, nm_Bairo, nm_Cidade, sg_UF, no_CEP, ds_Status, ds_Pessoa)values(@nome,@email,@cpf,@cnpj,@logradouro,@numero,@complemento,@bairro,@cidade,@uf,@cep,1,@pessoa) set @cd = SCOPE_IDENTITY()"; //esse set foi usado para adicionar ao "cd" o último "cd" inserido

                    cm.CommandText = sql;
                    cm.Connection = cn;

                    cm.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    cm.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cm.Parameters.Add("@cpf", SqlDbType.Char).Value = cpf;
                    cm.Parameters.Add("@cnpj", SqlDbType.Char).Value = cnpj;
                    cm.Parameters.Add("@logradouro", SqlDbType.VarChar).Value = logradouro;
                    cm.Parameters.Add("@numero", SqlDbType.VarChar).Value = numero;
                    cm.Parameters.Add("@complemento", SqlDbType.VarChar).Value = complemento;
                    cm.Parameters.Add("@bairro", SqlDbType.VarChar).Value = bairro;
                    cm.Parameters.Add("@cidade", SqlDbType.VarChar).Value = cidade;
                    cm.Parameters.Add("@uf", SqlDbType.Char).Value = uf;
                    cm.Parameters.Add("@cep", SqlDbType.Char).Value = cep;
                    cm.Parameters.Add("@pessoa", SqlDbType.Char).Value = pessoa;
                    cm.Parameters.AddWithValue("@cd", 0).Direction = ParameterDirection.Output; //isso exporta o código do cliente

                    cn.Open();
                    cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)

                    int cd = Convert.ToInt32(cm.Parameters["@cd"].Value);
                    string celular = maskTelefone.Text;

                    cm.CommandText = "insert into tbl_telefone(cd_Cliente, no_Telefone)values('" + cd + "','" + celular + "')";
                    cm.Connection = cn;
                    cm.ExecuteNonQuery();
                    cm.Parameters.Clear();

                    MessageBox.Show("Os dados foram gravados com sucesso!", "Inserção de dados concluído.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limparCampos();
                    desabilitaCampos();
                }
                catch (Exception ex)
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

       







        //private void manipularDados()
        //{
        //    lblCod.Visible=true;
        //    lblCodigo.Visible=true;
        //    btnAlterar.Enabled=true;
        //    btnCancelar.Enabled=true;
        //    btnRemover.Enabled=true;
        //    btnNovo.Enabled=false;
        //    btnGravar.Enabled=false;
        //    txtNome.Enabled = true;
        //    txtLogin.Enabled = true;
        //    txtSenha.Enabled = true;
        //}

        //private void FrmAtendente_Load(object sender, EventArgs e)
        //{
        //    desabilitaCampos();
        //}

        //private void btnNovo_Click(object sender, EventArgs e)
        //{
        //    habilitaCampos();
        //}

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    desabilitaCampos();
        //    limparCampos();
        //}

        //private void btnGravar_Click(object sender, EventArgs e)
        //{
        //    if (txtNome.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo nome", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtNome.Focus();
        //    }
        //    else if(txtLogin.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo login", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtLogin.Focus();
        //    }
        //    else if (txtSenha.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo senha", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtSenha.Focus();
        //    }
        //    else if (txtSenha.TextLength < 8)
        //    {
        //        MessageBox.Show("O campo senha deve conter no mínimo 8 caracteres", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtSenha.Focus();
        //    }
        //    else if (rdbInativo.Checked)
        //    {
        //        MessageBox.Show("É impossível cadastrar um funcionário se o STATUS estiver INATIVO", "ERRO AO GRAVAR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            string nome = txtNome.Text;
        //            string login = txtLogin.Text;
        //            string senha = txtSenha.Text;

        //            string sql = "insert into tbl_atendente(ds_Login, ds_Senha, nm_atendente, ds_Status)values(@login,@senha,@atendente,1)";

        //            SqlCommand cm = new SqlCommand(sql, cn);

        //            cm.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
        //            cm.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
        //            cm.Parameters.Add("@atendente", SqlDbType.VarChar).Value = nome;

        //            cn.Open();
        //            cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)
        //            MessageBox.Show("Os dados foram gravados com sucesso!", "Inserção de dados concluído.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            txtNome.Focus();
        //            limparCampos();
        //        }
        //        catch(Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            cn.Close();
        //        }
        //        finally
        //        {
        //            cn.Close();
        //        }
        //    }
        //}

        //private void txtBusca_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtBusca.Text != "")
        //    {
        //        try
        //        {
        //            cn.Open();
        //            //o uso do "like" é para o sistema de busca no sql e o uso da "%" faz referência ao que vem antes ou depois do conteúdo 
        //            cm.CommandText = "select * from tbl_atendente where nm_atendente like ('" + txtBusca.Text + "%')";
        //            cm.Connection = cn;

        //            //recebe os dados de uma tabela após um select
        //            SqlDataAdapter da = new SqlDataAdapter();    

        //            //pode representar uma ou mais tabelas de dados que ficarão alocadas em memória
        //            DataTable dt = new DataTable();

        //            //recebe os dados da instrução select
        //            da.SelectCommand = cm;

        //            da.Fill(dt); //preenche o DataTable "dt"

        //            dgvFunc.DataSource = dt; //preenche o quadro "dgvFunc" com o conteúdo da tabela

        //            cn.Close();

        //        }
        //        catch(Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally { cn.Close(); }
        //    }
        //    else
        //    {
        //        //isso é pra não aparecer nada no quadro quando o campo de busca estiver vazio
        //        dgvFunc.DataSource = null;
        //        desabilitaCampos();
        //    }
        //}

        //private void carregaAtendente()
        //{
        //    lblCod.Text = dgvFunc.SelectedRows[0].Cells[0].Value.ToString();
        //    txtLogin.Text = dgvFunc.SelectedRows[0].Cells[1].Value.ToString();
        //    txtNome.Text = dgvFunc.SelectedRows[0].Cells[3].Value.ToString();
        //    txtSenha.Text = dgvFunc.SelectedRows[0].Cells[2].Value.ToString();
        //    string valor = dgvFunc.SelectedRows[0].Cells[4].Value.ToString();
        //    //MessageBox.Show(valor);
        //    if(valor == "True")
        //    {
        //        rdbAtivo.Checked = true;
        //    }
        //    else
        //    {
        //        rdbInativo.Checked = true;
        //    }
        //    manipularDados();
        //}

        //private void dgvFunc_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    carregaAtendente();
        //    if(rdbInativo.Checked)
        //    {
        //        btnRemover.Enabled = false;
        //    }

        //}

        //private void btnAlterar_Click(object sender, EventArgs e)
        //{
        //    if (txtNome.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo nome", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtNome.Focus();
        //    }
        //    else if (txtLogin.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo login", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtLogin.Focus();
        //    }
        //    else if (txtSenha.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo senha", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtSenha.Focus();
        //    }
        //    else if (txtSenha.TextLength < 8)
        //    {
        //        MessageBox.Show("O campo senha deve conter no mínimo 8 caracteres", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtSenha.Focus();
        //    }
        //    else if (rdbInativo.Checked)
        //    {
        //        MessageBox.Show("Para INATIVAR um funcionário é preciso clicar no botão REMOVER.", "ERRO NA OPERAÇÃO!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            string nome = txtNome.Text;
        //            string login = txtLogin.Text;
        //            string senha = txtSenha.Text;
        //            int cd = Convert.ToInt32(lblCod.Text);

        //            //atualizando os campos , para alterar uma informação precisa ter uma informação constante que 
        //            //no caso foi usado o código do atendente
        //            string sql = "update tbl_atendente set ds_Login=@login, ds_Senha=@senha, nm_atendente=@atendente, ds_Status=1 where cd_Atendente=@cd";

        //            SqlCommand cm = new SqlCommand(sql, cn);

        //            cm.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
        //            cm.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
        //            cm.Parameters.Add("@atendente", SqlDbType.VarChar).Value = nome;
        //            cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

        //            cn.Open();
        //            cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)
        //            MessageBox.Show("Os dados foram alterados com sucesso!", "Alteração de dados concluída.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            txtNome.Focus();
        //            limparCampos();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            cn.Close();
        //        }
        //        finally
        //        {
        //            cn.Close();
        //        }
        //    }
        //}

        //private void btnRemover_Click(object sender, EventArgs e)
        //{
        //    if (txtNome.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo nome", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtNome.Focus();
        //    }
        //    else if (txtLogin.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo login", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtLogin.Focus();
        //    }
        //    else if (txtSenha.Text == "")
        //    {
        //        MessageBox.Show("Obrigatório informar o campo senha", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtSenha.Focus();
        //    }
        //    else if (txtSenha.TextLength < 8)
        //    {
        //        MessageBox.Show("O campo senha deve conter no mínimo 8 caracteres", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtSenha.Focus();
        //    }
        //    else if (rdbAtivo.Checked)
        //    {
        //        MessageBox.Show("Para remover o registro você precisa alterar o status para INATIVO.", "ERRO AO TENTAR EXCLUIR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        DialogResult exclusao = MessageBox.Show("Você tem certeza que deseja remover esse registro?", "EXCLUSÃO DE REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //        if(exclusao == DialogResult.No)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                int cd = Convert.ToInt32(lblCod.Text);

        //                string sql = "update tbl_atendente set ds_Status=0 where cd_Atendente=@cd";

        //                SqlCommand cm = new SqlCommand(sql, cn);

        //                cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

        //                cn.Open();
        //                cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)
        //                MessageBox.Show("O registro foi removido com sucesso!", "Remoção concluída!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                txtNome.Focus();
        //                limparCampos();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //                cn.Close();
        //            }
        //            finally
        //            {
        //                cn.Close();
        //            }
        //        }
        //    }


        //}
    }

}
