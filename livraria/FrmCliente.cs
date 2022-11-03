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
using Microsoft.VisualBasic;


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
            txtBuscaCliente.Clear();

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

        private void txtBuscaCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscaCliente.Text != "")
            {
                try
                {
                    cn.Open();
                    //o uso do "like" é para o sistema de busca no sql e o uso da "%" faz referência ao que vem antes ou depois do conteúdo 
                    //isso faz o conteúdo ser buscado à medida que eu for escrevendo
                    cm.CommandText = "select * from vwConsultaCliente where nm_Cliente like ('" + txtBuscaCliente.Text + "%')";
                    cm.Connection = cn;

                    //recebe os dados de uma tabela após um select
                    SqlDataAdapter da = new SqlDataAdapter();

                    //pode representar uma ou mais tabelas de dados que ficarão alocadas em memória
                    DataTable dt = new DataTable();

                    //recebe os dados da instrução select
                    da.SelectCommand = cm;

                    da.Fill(dt); //preenche o DataTable "dt"

                    dgvCliente.DataSource = dt; //preenche o quadro "dgvFunc" com o conteúdo da tabela

                    if(dt.Rows.Count < 1)
                    {
                        try
                        {
                            cm.CommandText = "select * from tbl_cliente where nm_Cliente like ('" + txtBuscaCliente.Text + "%')";
                            cm.Connection = cn;
                            SqlDataAdapter daCompl = new SqlDataAdapter();
                            DataTable dtCompl = new DataTable();
                            daCompl.SelectCommand = cm;
                            daCompl.Fill(dtCompl); //preenche o DataTable "dt"
                            dgvCliente.DataSource = dtCompl; //preenche o quadro "dgvFunc" com o conteúdo da tabela
                        }
                        catch
                        {
                            dgvCliente.DataSource = null;
                        }
                    }

                    cn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { cn.Close(); }
            }
            else
            {
                //isso é pra não aparecer nada no quadro quando o campo de busca estiver vazio
                dgvCliente.DataSource = null;
            }
        }

        private void manipularDados()
        {
            lblCod.Visible = true;
            lblCodigo.Visible = true;
            btnAlterar.Enabled = true;
            btnCancelar.Enabled = true;
            btnRemover.Enabled = true;
            btnNovo.Enabled = false;
            btnGravar.Enabled = false;

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

        private void carregaCliente()
        {
            manipularDados();

            lblCod.Text = dgvCliente.SelectedRows[0].Cells[0].Value.ToString();
            txtNome.Text = dgvCliente.SelectedRows[0].Cells[1].Value.ToString();
            txtEmail.Text = dgvCliente.SelectedRows[0].Cells[2].Value.ToString();
            txtLogradouro.Text = dgvCliente.SelectedRows[0].Cells[5].Value.ToString();
            txtComplemento.Text = dgvCliente.SelectedRows[0].Cells[7].Value.ToString();
            txtCidade.Text = dgvCliente.SelectedRows[0].Cells[9].Value.ToString();
            txtNumero.Text = dgvCliente.SelectedRows[0].Cells[6].Value.ToString();
            txtBairro.Text = dgvCliente.SelectedRows[0].Cells[8].Value.ToString();

            if(dgvCliente.SelectedRows[0].Cells[13].Value.ToString() == "F")
            {
                cboPessoa.SelectedIndex = 0;
                maskCpf.Text = dgvCliente.SelectedRows[0].Cells[3].Value.ToString();
            }
            else
            {
                cboPessoa.SelectedIndex = 1;
                maskCnpj.Text = dgvCliente.SelectedRows[0].Cells[4].Value.ToString();
                maskCnpj.Visible = true;
            }

            cboUF.Text = dgvCliente.SelectedRows[0].Cells[10].Value.ToString();
            maskCep.Text = dgvCliente.SelectedRows[0].Cells[11].Value.ToString();
            try
            {
                maskTelefone.Text = dgvCliente.SelectedRows[0].Cells[14].Value.ToString();
            }
            catch (Exception ex)
            {
                maskTelefone.Text = null;
            }

            string status = dgvCliente.SelectedRows[0].Cells[12].Value.ToString();
            if (status == "True")
            {
                rdbAtivo.Checked = true;
            }
            else
            {
                rdbInativo.Checked = true;
            }
            
        }

        private void dgvCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carregaCliente();
            if (rdbInativo.Checked)
            {
                btnRemover.Enabled = false;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (rdbInativo.Checked)
            {
                MessageBox.Show("Para inserir um cliente você precisa marcar o botão ATIVO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rdbAtivo.Checked = true;
            }
            else if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo NOME.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo E-MAIL.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else if (maskTelefone.Text == "" || maskTelefone.Text.Length < 11)
            {
                MessageBox.Show("Obrigatório informar TELEFONE VÁLIDO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskTelefone.Focus();
            }
            else if (cboPessoa.SelectedIndex == -1)
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
                    if (cboPessoa.SelectedIndex == 0)
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
                    int cd = Convert.ToInt32(lblCod.Text);

                    string sql = "update tbl_cliente set nm_Cliente=@nome, ds_Email=@email, no_CPF=@cpf, no_CNPJ=@cnpj, nm_Logradouro=@logradouro, no_Logradouro=@numero, ds_Complemento=@complemento, nm_Bairo=@bairro, nm_Cidade=@cidade, sg_UF=@uf, no_CEP=@cep, ds_Status=1, ds_Pessoa=@pessoa where cd_Cliente=@cd"; //esse set foi usado para adicionar ao "cd" o último "cd" inserido

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
                    cm.Parameters.Add("@telefone", SqlDbType.Char).Value = telefone;
                    cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                    cn.Open();
                    cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)

                    cm.CommandText = "update tbl_telefone set no_Telefone=@telefone where cd_Cliente=@cd";
                    cm.Connection = cn;
                    cm.ExecuteNonQuery();
                    cm.Parameters.Clear();

                    MessageBox.Show("Os dados foram alterados com sucesso!", "Alteração de dados concluída.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo NOME.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo E-MAIL.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            
            else if (cboPessoa.SelectedIndex == -1)
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
            else if (rdbAtivo.Checked)
            {
                MessageBox.Show("para remover o cliente você precisa alterar o status para INATIVO.", "erro ao tentar excluir!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult exclusao = MessageBox.Show("você tem certeza que deseja remover esse cliente?", "exclusão de cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (exclusao == DialogResult.No)
                {
                    return;
                }
                else
                {

                    try
                    {

                        int cd = Convert.ToInt32(lblCod.Text);
                        cn.Open();

                        cm.CommandText = "ALTER TABLE tbl_telefone NOCHECK CONSTRAINT FK__tbl_telef__no_Te__4BAC3F29";
                        cm.Connection = cn;
                        cm.ExecuteNonQuery();

                        string sql = "delete from tbl_cliente where cd_Cliente=@cd"; //esse set foi usado para adicionar ao "cd" o último "cd" inserido

                        cm.CommandText = sql;
                        cm.Connection = cn;

                        cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                        
                        cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)

                        cm.CommandText = "delete from tbl_telefone where cd_Cliente=@cd";
                        cm.Connection = cn;
                        cm.ExecuteNonQuery();

                        cm.CommandText = "ALTER TABLE tbl_telefone CHECK CONSTRAINT FK__tbl_telef__no_Te__4BAC3F29";
                        cm.Connection = cn;
                        cm.ExecuteNonQuery();

                        cm.Parameters.Clear();

                        MessageBox.Show("Os dados foram removidos com sucesso!", "Remoção de dados concluída.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void maskCep_Leave(object sender, EventArgs e)
        {
            if(maskCep.TextLength > 8)
            {
                using (var ws = new WsCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(maskCep.Text.Trim());
                        txtBairro.Text = endereco.bairro;
                        txtLogradouro.Text = endereco.end;
                        txtCidade.Text = endereco.cidade;
                        txtComplemento.Text = endereco.complemento2;
                        cboUF.Text = endereco.uf;

                        //MessageBox.Show(endereco.cidade);

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("CEP não encontrado","ATENCÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
