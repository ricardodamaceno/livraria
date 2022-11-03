namespace vinilCustom
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pneMenu = new System.Windows.Forms.Panel();
            this.usuarioLogado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCaixa = new System.Windows.Forms.Button();
            this.btnPedido = new System.Windows.Forms.Button();
            this.btnAutores = new System.Windows.Forms.Button();
            this.btnEditora = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnLivros = new System.Windows.Forms.Button();
            this.btnFone = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnFunc = new System.Windows.Forms.Button();
            this.pneLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.principal1 = new vinilCustom.principal();
            this.frmAtendente2 = new vinilCustom.FrmAtendente();
            this.frmCliente2 = new vinilCustom.FrmCliente();
            this.pneMenu.SuspendLayout();
            this.pneLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pneMenu
            // 
            this.pneMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.pneMenu.Controls.Add(this.usuarioLogado);
            this.pneMenu.Controls.Add(this.label2);
            this.pneMenu.Controls.Add(this.btnSair);
            this.pneMenu.Controls.Add(this.btnCaixa);
            this.pneMenu.Controls.Add(this.btnPedido);
            this.pneMenu.Controls.Add(this.btnAutores);
            this.pneMenu.Controls.Add(this.btnEditora);
            this.pneMenu.Controls.Add(this.btnCategoria);
            this.pneMenu.Controls.Add(this.btnLivros);
            this.pneMenu.Controls.Add(this.btnFone);
            this.pneMenu.Controls.Add(this.btnCliente);
            this.pneMenu.Controls.Add(this.btnFunc);
            this.pneMenu.Controls.Add(this.pneLogo);
            this.pneMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pneMenu.Location = new System.Drawing.Point(0, 0);
            this.pneMenu.Name = "pneMenu";
            this.pneMenu.Size = new System.Drawing.Size(217, 541);
            this.pneMenu.TabIndex = 0;
            // 
            // usuarioLogado
            // 
            this.usuarioLogado.AutoSize = true;
            this.usuarioLogado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usuarioLogado.ForeColor = System.Drawing.Color.Yellow;
            this.usuarioLogado.Location = new System.Drawing.Point(12, 511);
            this.usuarioLogado.Name = "usuarioLogado";
            this.usuarioLogado.Size = new System.Drawing.Size(0, 21);
            this.usuarioLogado.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(12, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Usuário Logado:";
            // 
            // btnSair
            // 
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSair.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSair.Image = global::vinilCustom.Properties.Resources.sair;
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(0, 435);
            this.btnSair.Name = "btnSair";
            this.btnSair.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSair.Size = new System.Drawing.Size(217, 40);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnCaixa
            // 
            this.btnCaixa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCaixa.FlatAppearance.BorderSize = 0;
            this.btnCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaixa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCaixa.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCaixa.Image = global::vinilCustom.Properties.Resources.caixa1;
            this.btnCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaixa.Location = new System.Drawing.Point(0, 395);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCaixa.Size = new System.Drawing.Size(217, 40);
            this.btnCaixa.TabIndex = 9;
            this.btnCaixa.Text = "Caixa";
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Visible = false;
            // 
            // btnPedido
            // 
            this.btnPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPedido.FlatAppearance.BorderSize = 0;
            this.btnPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPedido.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPedido.Image = global::vinilCustom.Properties.Resources.pedidos1;
            this.btnPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPedido.Location = new System.Drawing.Point(0, 355);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnPedido.Size = new System.Drawing.Size(217, 40);
            this.btnPedido.TabIndex = 8;
            this.btnPedido.Text = "Pedido";
            this.btnPedido.UseVisualStyleBackColor = true;
            this.btnPedido.Visible = false;
            // 
            // btnAutores
            // 
            this.btnAutores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAutores.FlatAppearance.BorderSize = 0;
            this.btnAutores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAutores.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAutores.Image = global::vinilCustom.Properties.Resources.autores1;
            this.btnAutores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutores.Location = new System.Drawing.Point(0, 315);
            this.btnAutores.Name = "btnAutores";
            this.btnAutores.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnAutores.Size = new System.Drawing.Size(217, 40);
            this.btnAutores.TabIndex = 7;
            this.btnAutores.Text = "Autores";
            this.btnAutores.UseVisualStyleBackColor = true;
            this.btnAutores.Visible = false;
            // 
            // btnEditora
            // 
            this.btnEditora.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditora.FlatAppearance.BorderSize = 0;
            this.btnEditora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditora.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditora.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEditora.Image = global::vinilCustom.Properties.Resources.editora1;
            this.btnEditora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditora.Location = new System.Drawing.Point(0, 275);
            this.btnEditora.Name = "btnEditora";
            this.btnEditora.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnEditora.Size = new System.Drawing.Size(217, 40);
            this.btnEditora.TabIndex = 6;
            this.btnEditora.Text = "Editora";
            this.btnEditora.UseVisualStyleBackColor = true;
            this.btnEditora.Visible = false;
            // 
            // btnCategoria
            // 
            this.btnCategoria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategoria.FlatAppearance.BorderSize = 0;
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCategoria.Image = global::vinilCustom.Properties.Resources.categoria1;
            this.btnCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoria.Location = new System.Drawing.Point(0, 235);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCategoria.Size = new System.Drawing.Size(217, 40);
            this.btnCategoria.TabIndex = 5;
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Visible = false;
            // 
            // btnLivros
            // 
            this.btnLivros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLivros.FlatAppearance.BorderSize = 0;
            this.btnLivros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLivros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLivros.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLivros.Image = global::vinilCustom.Properties.Resources.livros1;
            this.btnLivros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLivros.Location = new System.Drawing.Point(0, 195);
            this.btnLivros.Name = "btnLivros";
            this.btnLivros.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLivros.Size = new System.Drawing.Size(217, 40);
            this.btnLivros.TabIndex = 4;
            this.btnLivros.Text = "Livros";
            this.btnLivros.UseVisualStyleBackColor = true;
            this.btnLivros.Visible = false;
            // 
            // btnFone
            // 
            this.btnFone.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFone.FlatAppearance.BorderSize = 0;
            this.btnFone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFone.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFone.Image = global::vinilCustom.Properties.Resources.telefone1;
            this.btnFone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFone.Location = new System.Drawing.Point(0, 155);
            this.btnFone.Name = "btnFone";
            this.btnFone.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnFone.Size = new System.Drawing.Size(217, 40);
            this.btnFone.TabIndex = 3;
            this.btnFone.Text = "Telefones";
            this.btnFone.UseVisualStyleBackColor = true;
            this.btnFone.Visible = false;
            // 
            // btnCliente
            // 
            this.btnCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCliente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCliente.Image = global::vinilCustom.Properties.Resources.cliente1;
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.Location = new System.Drawing.Point(0, 115);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCliente.Size = new System.Drawing.Size(217, 40);
            this.btnCliente.TabIndex = 2;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnFunc
            // 
            this.btnFunc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFunc.FlatAppearance.BorderSize = 0;
            this.btnFunc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFunc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFunc.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFunc.Image = global::vinilCustom.Properties.Resources.funcionarios2;
            this.btnFunc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFunc.Location = new System.Drawing.Point(0, 75);
            this.btnFunc.Name = "btnFunc";
            this.btnFunc.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnFunc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFunc.Size = new System.Drawing.Size(217, 40);
            this.btnFunc.TabIndex = 1;
            this.btnFunc.Text = "Funcionario";
            this.btnFunc.UseVisualStyleBackColor = true;
            this.btnFunc.Click += new System.EventHandler(this.btnFunc_Click);
            // 
            // pneLogo
            // 
            this.pneLogo.BackColor = System.Drawing.SystemColors.ControlText;
            this.pneLogo.Controls.Add(this.label1);
            this.pneLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pneLogo.Location = new System.Drawing.Point(0, 0);
            this.pneLogo.Name = "pneLogo";
            this.pneLogo.Size = new System.Drawing.Size(217, 75);
            this.pneLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vinil Custom";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // principal1
            // 
            this.principal1.AutoSize = true;
            this.principal1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.principal1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.principal1.Location = new System.Drawing.Point(217, 0);
            this.principal1.Name = "principal1";
            this.principal1.Size = new System.Drawing.Size(692, 541);
            this.principal1.TabIndex = 1;
            // 
            // frmAtendente2
            // 
            this.frmAtendente2.AutoSize = true;
            this.frmAtendente2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.frmAtendente2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmAtendente2.Location = new System.Drawing.Point(217, 0);
            this.frmAtendente2.Name = "frmAtendente2";
            this.frmAtendente2.Size = new System.Drawing.Size(692, 541);
            this.frmAtendente2.TabIndex = 2;
            // 
            // frmCliente2
            // 
            this.frmCliente2.AutoSize = true;
            this.frmCliente2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.frmCliente2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmCliente2.Location = new System.Drawing.Point(217, 0);
            this.frmCliente2.Name = "frmCliente2";
            this.frmCliente2.Size = new System.Drawing.Size(692, 541);
            this.frmCliente2.TabIndex = 3;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 541);
            this.Controls.Add(this.frmCliente2);
            this.Controls.Add(this.frmAtendente2);
            this.Controls.Add(this.principal1);
            this.Controls.Add(this.pneMenu);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenu_FormClosed);
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.pneMenu.ResumeLayout(false);
            this.pneMenu.PerformLayout();
            this.pneLogo.ResumeLayout(false);
            this.pneLogo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pneMenu;
        private Button btnCaixa;
        private Button btnPedido;
        private Button btnAutores;
        private Button btnEditora;
        private Button btnCategoria;
        private Button btnLivros;
        private Button btnFone;
        private Button btnCliente;
        private Button btnFunc;
        private Panel pneLogo;
        private Label label1;
        private Button btnSair;
        private Label usuarioLogado;
        private Label label2;
        private principal principal1;
        private FrmAtendente frmAtendente2;
        private FrmCliente frmCliente2;
    }
}