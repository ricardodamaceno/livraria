using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace livraria
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        //conecxão com banco de dados (SSPI = autenticação do windows)
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-OOSH39D\SQLEXPRESS;integrated security=SSPI;initial Catalog=db_livraria");

        //para dar os comandos sql
        SqlCommand cm = new SqlCommand();

        //serve para fazer uma busca no banco de dados após um select
        SqlDataReader dr;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSenha_MouseDown(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = false;
        }

        private void btnSenha_MouseUp(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Obrigatório preencher os campos.", "ATENÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                try
                {
                    cn.Open();
                    cm.CommandText = "select * from tbl_atendente where ds_Login = ('" + txtNome.Text + "') and ds_Senha = ('" + txtSenha.Text + "') and ds_Status = 1";
                    cm.Connection = cn;
                    dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {

                        FrmMenu menu = new FrmMenu();
                        menu.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Usuario ou Senha inválido.", "ATENÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNome.Clear();
                        txtSenha.Clear();
                        txtNome.Focus();

                    }
                    cn.Close();
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}