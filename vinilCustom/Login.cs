using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace vinilCustom
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        public static string usuario;

        //conecxão com banco de dados (SSPI = autenticação do windows)
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-OOSH39D\SQLEXPRESS;integrated security=SSPI;initial Catalog=db_vcustom");

        //para dar os comandos sql
        SqlCommand cm = new SqlCommand();

        //serve para fazer uma busca no banco de dados após um select
        SqlDataReader dr;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnSenha_MouseDown(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = false;
            btnSenha.Visible = false;
            cadAberto.Visible = true;
        }

        private void btnSenha_MouseUp(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
            btnSenha.Visible = true;
            cadAberto.Visible = false;
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
                    SqlDataAdapter da = new SqlDataAdapter(cm); //serve para fazer uma busca no banco de dados após um select
                    DataTable dt = new DataTable();//cria uma tabela
                    da.Fill(dt);//joda os dados do select dentro da tabela

                    if (dt.Rows.Count > 0) //verifica se há linhas na tabela
                    {
                        usuario = dt.Rows[0]["nm_atendente"].ToString();
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