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
using Xceed.Words.NET;
using Word = Microsoft.Office.Interop.Word;


namespace vinilCustom
{
    public partial class FrmCliente : UserControl
    {
        public FrmCliente()
        {
            InitializeComponent();
            desabilitaCampos();
        }

        //conecxão com banco de dados (SSPI = autenticação do windows)
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-OOSH39D\SQLEXPRESS;integrated security=SSPI;initial Catalog=db_vcustom");

        //para dar os comandos sql
        SqlCommand cm = new SqlCommand();

        //serve para fazer uma busca no banco de dados após um select
        //SqlDataReader dr;


        //metodos para quando clicar iniciar obrigatoriamente no começo
        private void maskData_Click(object sender, EventArgs e)
        {
            if (maskData.Text.Length < 7)
            {
                SendKeys.Send("{Home}");
            }
            //else
            //{
            //    MessageBox.Show(maskData.Text.Length.ToString()); 
            //}
            
        }
        private void txtPlaca_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text == "")
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

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        //transforma o valor em dinheiro
        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                try
                {
                    double valor = Convert.ToDouble(txtValor.Text);
                    txtValor.Text = String.Format("{0:c}", valor);//isso transforma em dinheiro
                    txtValor.Text = txtValor.Text.Replace("R$ ", "");//isso tira o cifrão

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe um valor válido");
                }
                
            }
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                try
                {
                    double valor = Convert.ToDouble(txtValor.Text);
                    txtValor.Text = String.Format("{0:c}", valor);//isso transforma em dinheiro
                    txtValor.Text = txtValor.Text.Replace("R$ ", "");//isso tira o cifrão

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe um valor válido");
                }
            }
        }

        //validação de data
        private void maskData_Leave(object sender, EventArgs e)
        {
            DateTime valor;
            var convertido = DateTime
                .TryParseExact(maskData.Text, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out valor);
            if (convertido == false)
            {
                MessageBox.Show("Informe uma data válida");
                maskData.Focus();
            }

        }

        private void desabilitaCampos()
        {
            btnNovo.Enabled =true;
            btnGravar.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = false;
            imprimir.Enabled = false;

            lblCodigo.Visible = false;
            lblCod.Visible = false;

            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtLogradouro.Enabled = false;
            txtComplemento.Enabled = false;
            txtCidade.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtPlaca.Enabled = false;
            txtValor.Enabled = false;
            txtServico.Enabled = false;

            cboUF.Enabled = false;
            cboGarantia.Enabled = false;

            maskData.Enabled = false;
            maskCep.Enabled = false;
            maskCpf.Enabled = false;
            maskTelefone.Enabled = false;
            
        }

        private void habilitaCampos()
        {
            btnNovo.Enabled = false;
            btnGravar.Enabled = true;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = true;
            imprimir.Enabled = true;

            lblCodigo.Visible = false;
            lblCod.Visible = false;

            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtLogradouro.Enabled = true;
            txtComplemento.Enabled = true;
            txtCidade.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtPlaca.Enabled = true;
            txtValor.Enabled = true;
            txtServico.Enabled = true;

            cboUF.Enabled = true;
            cboGarantia.Enabled = true;

            maskData.Enabled = true;
            maskCep.Enabled = true;
            maskCpf.Enabled = true;
            maskTelefone.Enabled = true;
        }

        private void limparCampos()
        {
            lblCod.Text = "";
            txtNome.Clear();
            txtEmail.Clear();
            txtLogradouro.Clear();
            txtComplemento.Clear();
            txtCidade.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtPlaca.Clear();
            txtValor.Clear();
            txtServico.Clear();
            txtBuscaCliente.Clear();

            cboUF.SelectedIndex = -1;
            cboGarantia.SelectedIndex = -1;

            maskData.Clear();
            maskCep.Clear();
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
            if(txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo NOME.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }
            else if(txtEmail.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo E-MAIL.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
            }
            else if (maskData.Text == "" || maskData.Text.Length < 8)
            {
                MessageBox.Show("Obrigatório informar o campo DATA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskData.Focus();
            }
            else if (maskCep.Text == "" || maskData.Text.Length < 8)
            {
                MessageBox.Show("Obrigatório informar o campo CEP.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskCep.Focus();
            }
            else if (txtPlaca.Text == "" || maskData.Text.Length < 7)
            {
                MessageBox.Show("Obrigatório informar o campo PLACA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlaca.Focus();
            }
            else if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo RUA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogradouro.Focus();
            }
            else if (txtBairro.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo BAIRRO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBairro.Focus();
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo NÚMERO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumero.Focus();
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo CIDADE.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCidade.Focus();
            }
            else if (maskCpf.Text == "" )
            {
                MessageBox.Show("Obrigatório informar o campo CPF.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskCpf.Focus();
            }
            else if (cboUF.Text == "" || maskData.Text.Length < 2)
            {
                MessageBox.Show("Obrigatório informar o campo UF.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboUF.Focus();
            }
            else if (maskTelefone.Text == "" || maskTelefone.Text.Length < 11)
            {
                MessageBox.Show("Obrigatório informar TELEFONE VÁLIDO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskTelefone.Focus();
            }
            else if (cboGarantia.Text == "")
            {
                MessageBox.Show("Obrigatório informar GARANTIA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboGarantia.Focus();
            }
            else if (txtValor.Text == "")
            {
                MessageBox.Show("Obrigatório informar VALOR.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
            }
            else if (txtServico.Text == "")
            {
                MessageBox.Show("Obrigatório informar SERVIÇO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServico.Focus();
            }
            else
            {
                try
                {
                    string nome = txtNome.Text;
                    string email = txtEmail.Text;
                    string data = maskData.Text;
                    string cep = maskCep.Text;
                    string placa = txtPlaca.Text;
                    string rua = txtLogradouro.Text;
                    string bairro = txtBairro.Text;
                    string complemento = txtComplemento.Text;
                    string numero = txtNumero.Text;
                    string cidade = txtCidade.Text;
                    string cpf = maskCpf.Text;
                    string uf = cboUF.Text.ToString();
                    string telefone = maskTelefone.Text;
                    string garantia = cboGarantia.Text.ToString();
                    string valor = txtValor.Text;
                    string servico = txtServico.Text;

                    string sql = "insert into tbl_clientes(nm_Cliente, ds_Email, no_CEP, nm_Logradouro, nm_Bairo, ds_Complemento, no_Logradouro, nm_Cidade, no_CPF, sg_UF, no_Telefone)values(@nome,@email,@cep,@logradouro,@bairro,@complemento,@numero,@cidade,@cpf,@uf,@telefone) set @cd = SCOPE_IDENTITY()"; //esse set foi usado para adicionar ao "cd" o último "cd" inserido

                    cm.CommandText = sql;
                    cm.Connection = cn;

                    cm.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    cm.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cm.Parameters.Add("@cep", SqlDbType.Char).Value = cep;
                    cm.Parameters.Add("@logradouro", SqlDbType.VarChar).Value = rua;
                    cm.Parameters.Add("@bairro", SqlDbType.VarChar).Value = bairro;
                    cm.Parameters.Add("@complemento", SqlDbType.VarChar).Value = complemento;
                    cm.Parameters.Add("@numero", SqlDbType.VarChar).Value = numero;
                    cm.Parameters.Add("@cidade", SqlDbType.VarChar).Value = cidade;
                    cm.Parameters.Add("@cpf", SqlDbType.Char).Value = cpf;
                    cm.Parameters.Add("@uf", SqlDbType.Char).Value = uf;
                    cm.Parameters.Add("@telefone", SqlDbType.Char).Value = telefone;
                    cm.Parameters.Add("@data", SqlDbType.Date).Value = data;
                    cm.Parameters.Add("@placa", SqlDbType.VarChar).Value = placa;
                    cm.Parameters.Add("@garantia", SqlDbType.VarChar).Value = garantia;
                    cm.Parameters.Add("@valor", SqlDbType.Char).Value = valor;
                    cm.Parameters.Add("@servico", SqlDbType.VarChar).Value = servico;

                    cm.Parameters.AddWithValue("@cd", 0).Direction = ParameterDirection.Output; //isso exporta o código do cliente

                    cn.Open();
                    cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)

                    int cd = Convert.ToInt32(cm.Parameters["@cd"].Value);
                    if (lblCod.Text == "")
                    {
                        cm.CommandText = "insert into tbl_servico(no_data, no_Placa, ds_Garantia, no_Valor, ds_Servico, clienteId)" +
                        "values(@data,@placa,@garantia,@valor,@servico, '" + cd + "')";
                    }
                    else
                    {
                        cm.CommandText = "insert into tbl_servico(no_data, no_Placa, ds_Garantia, no_Valor, ds_Servico, clienteId)" +
                        "values(@data,@placa,@garantia,@valor,@servico, '" + lblCod.Text + "')";
                    }

                    cm.Connection = cn;
                    cm.ExecuteNonQuery();
                    cm.Parameters.Clear();

                    MessageBox.Show("Os dados foram gravados com sucesso!", "Inserção de dados concluído.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //limparCampos();
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
                    cm.CommandText = "select * from vwConsultaClientes where nm_Cliente like ('" + txtBuscaCliente.Text + "%')";
                    cm.Connection = cn;

                    SqlDataAdapter da = new SqlDataAdapter();

                    DataTable dt = new DataTable();

                    da.SelectCommand = cm;

                    da.Fill(dt); //preenche o DataTable "dt"

                    dgvCliente.DataSource = dt; //preenche o quadro "dgvFunc" com o conteúdo da tabela
                    //dgvCliente.Columns[1].Visible = false;

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
                dgvCliente.DataSource = null;
            }
        }

        private void manipularDados()
        {
            lblCod.Visible = true;
            lblCodigo.Visible = true;
            btnAlterar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNovo.Enabled = false;
            btnGravar.Enabled = false;
            imprimir.Enabled = true;

            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtLogradouro.Enabled = true;
            txtComplemento.Enabled = true;
            txtCidade.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtPlaca.Enabled = true;
            txtValor.Enabled = true;
            txtServico.Enabled = true;

            cboUF.Enabled = true;
            cboGarantia.Enabled = true;

            maskData.Enabled = true;
            maskCep.Enabled = true;
            maskCpf.Enabled = true;
            maskTelefone.Enabled = true;

        }

        private void carregaCliente()
        {
            manipularDados();

            lblCod.Text = dgvCliente.SelectedRows[0].Cells[0].Value.ToString();
            txtNome.Text = dgvCliente.SelectedRows[0].Cells[1].Value.ToString(); 
            txtEmail.Text = dgvCliente.SelectedRows[0].Cells[2].Value.ToString();
            maskData.Text = dgvCliente.SelectedRows[0].Cells[13].Value.ToString();
            maskCep.Text = dgvCliente.SelectedRows[0].Cells[3].Value.ToString();
            txtPlaca.Text = dgvCliente.SelectedRows[0].Cells[14].Value.ToString();
            txtLogradouro.Text = dgvCliente.SelectedRows[0].Cells[4].Value.ToString();
            txtBairro.Text = dgvCliente.SelectedRows[0].Cells[5].Value.ToString();
            txtComplemento.Text = dgvCliente.SelectedRows[0].Cells[6].Value.ToString();
            txtNumero.Text = dgvCliente.SelectedRows[0].Cells[7].Value.ToString();
            txtCidade.Text = dgvCliente.SelectedRows[0].Cells[8].Value.ToString();
            maskCpf.Text = dgvCliente.SelectedRows[0].Cells[9].Value.ToString();
            cboUF.Text = dgvCliente.SelectedRows[0].Cells[10].Value.ToString();
            maskTelefone.Text = dgvCliente.SelectedRows[0].Cells[11].Value.ToString();
            cboGarantia.Text = dgvCliente.SelectedRows[0].Cells[15].Value.ToString();
            txtValor.Text = dgvCliente.SelectedRows[0].Cells[16].Value.ToString();
            txtServico.Text = dgvCliente.SelectedRows[0].Cells[17].Value.ToString();

        }

        private void dgvCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carregaCliente();
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
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
            else if (maskData.Text == "" || maskData.Text.Length < 8)
            {
                MessageBox.Show("Obrigatório informar o campo DATA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskData.Focus();
            }
            else if (maskCep.Text == "" || maskData.Text.Length < 8)
            {
                MessageBox.Show("Obrigatório informar o campo CEP.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskCep.Focus();
            }
            else if (txtPlaca.Text == "" || maskData.Text.Length < 7)
            {
                MessageBox.Show("Obrigatório informar o campo PLACA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlaca.Focus();
            }
            else if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo RUA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogradouro.Focus();
            }
            else if (txtBairro.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo BAIRRO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBairro.Focus();
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo NÚMERO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumero.Focus();
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo CIDADE.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCidade.Focus();
            }
            else if (maskCpf.Text == "")
            {
                MessageBox.Show("Obrigatório informar o campo CPF.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskCpf.Focus();
            }
            else if (cboUF.Text == "" || maskData.Text.Length < 2)
            {
                MessageBox.Show("Obrigatório informar o campo UF.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboUF.Focus();
            }
            else if (maskTelefone.Text == "" || maskTelefone.Text.Length < 11)
            {
                MessageBox.Show("Obrigatório informar TELEFONE VÁLIDO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskTelefone.Focus();
            }
            else if (cboGarantia.Text == "")
            {
                MessageBox.Show("Obrigatório informar GARANTIA.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboGarantia.Focus();
            }
            else if (txtValor.Text == "")
            {
                MessageBox.Show("Obrigatório informar VALOR.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
            }
            else if (txtServico.Text == "")
            {
                MessageBox.Show("Obrigatório informar SERVIÇO.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServico.Focus();
            }
            else
            {
                try
                {
                    string nome = txtNome.Text;
                    string email = txtEmail.Text;
                    string data = maskData.Text;
                    string cep = maskCep.Text;
                    string placa = txtPlaca.Text;
                    string rua = txtLogradouro.Text;
                    string bairro = txtBairro.Text;
                    string complemento = txtComplemento.Text;
                    string numero = txtNumero.Text;
                    string cidade = txtCidade.Text;
                    string cpf = maskCpf.Text;
                    string uf = cboUF.Text.ToString();
                    string telefone = maskTelefone.Text;
                    string garantia = cboGarantia.Text.ToString();
                    string valor = txtValor.Text;
                    string servico = txtServico.Text;
                    int cd = Convert.ToInt32(lblCod.Text);

                    string sql = "update tbl_clientes set nm_Cliente=@nome, ds_Email=@email, no_CEP=@cep, nm_Logradouro=@logradouro, nm_Bairo=@bairro, ds_Complemento=@complemento, no_Logradouro=@numero, nm_Cidade=@cidade, no_CPF=@cpf, sg_UF=@uf, no_Telefone=@telefone where cd_Cliente=@cd";
                   
                    cm.CommandText = sql;
                    cm.Connection = cn;

                    cm.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    cm.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cm.Parameters.Add("@cep", SqlDbType.Char).Value = cep;
                    cm.Parameters.Add("@logradouro", SqlDbType.VarChar).Value = rua;
                    cm.Parameters.Add("@bairro", SqlDbType.VarChar).Value = bairro;
                    cm.Parameters.Add("@complemento", SqlDbType.VarChar).Value = complemento;
                    cm.Parameters.Add("@numero", SqlDbType.VarChar).Value = numero;
                    cm.Parameters.Add("@cidade", SqlDbType.VarChar).Value = cidade;
                    cm.Parameters.Add("@cpf", SqlDbType.Char).Value = cpf;
                    cm.Parameters.Add("@uf", SqlDbType.Char).Value = uf;
                    cm.Parameters.Add("@telefone", SqlDbType.Char).Value = telefone;
                    cm.Parameters.Add("@data", SqlDbType.Date).Value = data;
                    cm.Parameters.Add("@placa", SqlDbType.VarChar).Value = placa;
                    cm.Parameters.Add("@garantia", SqlDbType.VarChar).Value = garantia;
                    cm.Parameters.Add("@valor", SqlDbType.Char).Value = valor;
                    cm.Parameters.Add("@servico", SqlDbType.VarChar).Value = servico;
                    cm.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                    cn.Open();
                    cm.ExecuteNonQuery();//executa sem fazer consulta(usado para insert, update, delete)

                    cm.CommandText = "update tbl_servico set no_data=@data, no_Placa=@placa, ds_Garantia=@garantia, no_Valor=@valor, ds_Servico=@servico where clienteId=@cd";
                    
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
                    cm.Parameters.Clear();
                    cn.Close();
                }
                finally
                {
                    cn.Close();
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

        private void exportar_Click(object sender, EventArgs e)
        {
            if (dgvCliente.DataSource != null) {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = app.Application.Workbooks.Add(1); //"nome" da planilha
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1]; //planilha

            int i = 0;
            int j = 0;


            for (int c = 1; c <= dgvCliente.Columns.Count; c++)
                    //começando da coluna 1
            {

                    ws.Cells[1, c] = dgvCliente.Columns[c - 1].HeaderText;
                    //coloca o cabeçalho da planilha na [linha 1, coluna 1], começa na posição 0 o primeiro nome

            } 

            // passa as celulas do DataGridView para a Pasta do Excel 
            for (i = 0; i <= dgvCliente.RowCount - 1; i++)
                    //enquanto o i for menor ou igua a quantidade de linhas, faz o loop
            {

                for (j = 0; j <= dgvCliente.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dgvCliente[j, i];
                        ws.Cells[i + 2, j + 1] = cell.Value;
                        //coloca o valor da [linha 2, coluna 1] no valor da celula
                }
            }
                app.Columns.AutoFit();
                app.Visible = true;
            }
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && maskCpf.Text != "" && maskData.Text != "" && txtPlaca.Text != "" && txtServico.Text != "" && cboGarantia.Text != "" && txtValor.Text != "")
            {

                string conteudoTxt, novoConteudoTxt;
                string filtroTipoArquivo = "arquivos docx (*.docx)|*.docx";
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = filtroTipoArquivo;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = filtroTipoArquivo;

                //###### Primeiro procura o arquivo bruto usando o openFileDialog ######//
                try
                {
                    //Se abrir a caixa de diálogo e o usuário clicar em ok...
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //Pegar o caminho do arquivo escolhido
                        string caminhoAbrir = openFileDialog1.FileName;
                        //Jogar o conteúdo do arquivo numa string
                        //conteudoTxt = File.ReadAllText(caminhoAbrir);
                        var documento = DocX.Load(caminhoAbrir);

                        //Faz as substituições
                        documento.ReplaceText("#nome", txtNome.Text);
                        documento.ReplaceText("#cpf", maskCpf.Text);
                        documento.ReplaceText("#email", txtEmail.Text);
                        documento.ReplaceText("#data", maskData.Text);
                        documento.ReplaceText("#placa", txtPlaca.Text);
                        documento.ReplaceText("#serviço", txtServico.Text);
                        documento.ReplaceText("#garantia", cboGarantia.Text);
                        documento.ReplaceText("#valor", txtValor.Text);


                        //novoConteudoTxt = conteudoTxt.Replace("#nome", "deu");

                        //###### Salva o txt com os valores substituídos onde o usuário escolher ######//
                        try
                        {
                            //Se abrir a caixa de diálogo e o usuário clicar em ok...
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                //Pegar o caminho do arquivo que ele criou
                                string caminhoSalvar = saveFileDialog1.FileName;
                                //Salvar todo o texto no caminho do arquivo escolhido
                                documento.SaveAs(caminhoSalvar);
                                //File.WriteAllText(caminhoSalvar, novoConteudoTxt);
                                //Mostrar confirmação
                                MessageBox.Show("Arquivo salvo com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); };
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); };
            }
            else
            {
                MessageBox.Show("Verifique se os campos estão completos e tente novamente.");
            }
            //string caminho = @"C:\Programas\";

            //static void Replace()
            //{
            //    string caminho = @"C:\\Programas\\";
            //    using (var documento = DocX.Load(caminho+"Olá.docx"))

            //    {
            //        documento.ReplaceText("#nome", "Vinicius Mussak");

            //        string mes = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("pt-br"));
            //        documento.ReplaceText("#mes", mes);

            //        documento.SaveAs(caminho + "novo2.docx");
            //        //('" + txtBuscaCliente.Text + "%')
            //    }
            //}
        }

        private void tsmG90_Click(object sender, EventArgs e)
        {
            txtServico.Text += tsmG90.Text;
            txtServico.Text += " ";
        }

        private void tsmG40_Click(object sender, EventArgs e)
        {
            txtServico.Text += tsmG40.Text;
            txtServico.Text += " ";
        }
    }

}
