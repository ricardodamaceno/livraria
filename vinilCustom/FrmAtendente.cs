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

namespace vinilCustom
{
    public partial class FrmAtendente : UserControl
    {
        public FrmAtendente()
        {
            InitializeComponent();
        }

        //conecxão com banco de dados (SSPI = autenticação do windows)
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-OOSH39D\SQLEXPRESS;integrated security=SSPI;initial Catalog=db_vcustom");

        //para dar os comandos sql
        SqlCommand cm = new SqlCommand();

        //serve para fazer uma busca no banco de dados após um select
        //SqlDataReader dr;

        private void desabilitaCampos()
        {
            lblCod.Visible = false;
            lblCodigo.Visible = false;
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
            txtBusca.Text = "";
            //dgvFunc.DataSource = null;
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtLogin.Clear();
            txtSenha.Clear();
            txtNome.Focus();
            txtBusca.Clear();  
            rdbAtivo.Checked = true;
            lblCod.Visible = false;
            lblCodigo.Visible=false;
        }

        private void manipularDados()
        {
            lblCod.Visible=true;
            lblCodigo.Visible=true;
            btnAlterar.Enabled=true;
            btnCancelar.Enabled=true;
            btnRemover.Enabled=true;
            btnNovo.Enabled=false;
            btnGravar.Enabled=false;
            txtNome.Enabled = true;
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
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
            else if (rdbInativo.Checked)
            {
                MessageBox.Show("É impossível cadastrar um funcionário se o STATUS estiver INATIVO", "ERRO AO GRAVAR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string nome = txtNome.Text;
                    string login = txtLogin.Text;
                    string senha = txtSenha.Text;

                    string sql = "insert into tbl_atendente(ds_Login, ds_Senha, nm_atendente, ds_Status)values(@login,@senha,@atendente,1)";

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

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text != "")
            {
                try
                {
                    cn.Open();
                    //o uso do "like" é para o sistema de busca no sql e o uso da "%" faz referência ao que vem antes ou depois do conteúdo 
                    cm.CommandText = "select * from tbl_atendente where nm_atendente like ('" + txtBusca.Text + "%')";
                    cm.Connection = cn;

                    //recebe os dados de uma tabela após um select
                    SqlDataAdapter da = new SqlDataAdapter();    

                    //pode representar uma ou mais tabelas de dados que ficarão alocadas em memória
                    DataTable dt = new DataTable();

                    //recebe os dados da instrução select
                    da.SelectCommand = cm;

                    da.Fill(dt); //preenche o DataTable "dt"

                    dgvFunc.DataSource = dt; //preenche o quadro "dgvFunc" com o conteúdo da tabela
                    
                    cn.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { cn.Close(); }
            }
            else
            {
                //isso é pra não aparecer nada no quadro quando o campo de busca estiver vazio
                dgvFunc.DataSource = null;
                desabilitaCampos();
            }
        }

        private void carregaAtendente()
        {
            lblCod.Text = dgvFunc.SelectedRows[0].Cells[0].Value.ToString();
            txtLogin.Text = dgvFunc.SelectedRows[0].Cells[1].Value.ToString();
            txtNome.Text = dgvFunc.SelectedRows[0].Cells[3].Value.ToString();
            txtSenha.Text = dgvFunc.SelectedRows[0].Cells[2].Value.ToString();
            string valor = dgvFunc.SelectedRows[0].Cells[4].Value.ToString();
            //MessageBox.Show(valor);
            if(valor == "True")
            {
                rdbAtivo.Checked = true;
            }
            else
            {
                rdbInativo.Checked = true;
            }
            manipularDados();
        }

        private void dgvFunc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carregaAtendente();
            if(rdbInativo.Checked)
            {
                btnRemover.Enabled = false;
            }
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo nome", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
            }
            else if (txtLogin.Text == "")
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
            else if (rdbInativo.Checked)
            {
                MessageBox.Show("Para INATIVAR um funcionário é preciso clicar no botão REMOVER.", "ERRO NA OPERAÇÃO!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string nome = txtNome.Text;
                    string login = txtLogin.Text;
                    string senha = txtSenha.Text;
                    int cd = Convert.ToInt32(lblCod.Text);

                    //atualizando os campos , para alterar uma informação precisa ter uma informação constante que 
                    //no caso foi usado o código do atendente
                    string sql = "update tbl_atendente set ds_Login=@login, ds_Senha=@senha, nm_atendente=@atendente, ds_Status=1 where cd_Atendente=@cd";

                    SqlCommand cm = new SqlCommand(sql, cn);

                    cm.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    cm.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                    cm.Parameters.Add("@atendente", SqlDbType.VarChar).Value = nome;
                    cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                    cn.Open();
                    cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)
                    MessageBox.Show("Os dados foram alterados com sucesso!", "Alteração de dados concluída.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.Focus();
                    limparCampos();
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
                MessageBox.Show("Obrigatório informar o campo nome", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
            }
            else if (txtLogin.Text == "")
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
            else if (rdbAtivo.Checked)
            {
                MessageBox.Show("Para remover o registro você precisa alterar o status para INATIVO.", "ERRO AO TENTAR EXCLUIR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult exclusao = MessageBox.Show("Você tem certeza que deseja remover esse registro?", "EXCLUSÃO DE REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(exclusao == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        int cd = Convert.ToInt32(lblCod.Text);

                        string sql = "update tbl_atendente set ds_Status=0 where cd_Atendente=@cd";

                        SqlCommand cm = new SqlCommand(sql, cn);

                        cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                        cn.Open();
                        cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)
                        MessageBox.Show("O registro foi removido com sucesso!", "Remoção concluída!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Focus();
                        limparCampos();
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
    }

}
