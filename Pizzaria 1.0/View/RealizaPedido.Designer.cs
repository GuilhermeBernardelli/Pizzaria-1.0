namespace Pizzaria_1._0.View
{
    partial class RealizaPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealizaPedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVlPedidoAberto = new System.Windows.Forms.Label();
            this.pnlPagamento = new System.Windows.Forms.GroupBox();
            this.rdbDinheiro = new System.Windows.Forms.RadioButton();
            this.rdbCartao = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbItens = new System.Windows.Forms.ComboBox();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.chkMeia = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.pnlPagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(2, 585);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(154, 13);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "© 2018 Prezia Software House";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.chkMeia);
            this.panel1.Controls.Add(this.btnSelecionar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtVlPedidoAberto);
            this.panel1.Controls.Add(this.pnlPagamento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtObservacao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbItens);
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.lblLabel);
            this.panel1.Controls.Add(this.dgvPedido);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 580);
            this.panel1.TabIndex = 2;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.Color.Transparent;
            this.btnSelecionar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.BackgroundImage")));
            this.btnSelecionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelecionar.FlatAppearance.BorderSize = 0;
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionar.ForeColor = System.Drawing.Color.White;
            this.btnSelecionar.Location = new System.Drawing.Point(555, 365);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(33, 33);
            this.btnSelecionar.TabIndex = 63;
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(285, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 62;
            this.label4.Text = "TOTAL :    R$";
            // 
            // txtVlPedidoAberto
            // 
            this.txtVlPedidoAberto.AutoSize = true;
            this.txtVlPedidoAberto.BackColor = System.Drawing.Color.DarkGreen;
            this.txtVlPedidoAberto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtVlPedidoAberto.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVlPedidoAberto.Location = new System.Drawing.Point(438, 463);
            this.txtVlPedidoAberto.Name = "txtVlPedidoAberto";
            this.txtVlPedidoAberto.Size = new System.Drawing.Size(86, 41);
            this.txtVlPedidoAberto.TabIndex = 61;
            this.txtVlPedidoAberto.Text = "0,00";
            // 
            // pnlPagamento
            // 
            this.pnlPagamento.Controls.Add(this.rdbDinheiro);
            this.pnlPagamento.Controls.Add(this.rdbCartao);
            this.pnlPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPagamento.ForeColor = System.Drawing.Color.White;
            this.pnlPagamento.Location = new System.Drawing.Point(12, 453);
            this.pnlPagamento.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPagamento.Name = "pnlPagamento";
            this.pnlPagamento.Size = new System.Drawing.Size(245, 61);
            this.pnlPagamento.TabIndex = 60;
            this.pnlPagamento.TabStop = false;
            this.pnlPagamento.Text = "Forma de Pagamento";
            // 
            // rdbDinheiro
            // 
            this.rdbDinheiro.AutoSize = true;
            this.rdbDinheiro.Checked = true;
            this.rdbDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDinheiro.Location = new System.Drawing.Point(22, 23);
            this.rdbDinheiro.Name = "rdbDinheiro";
            this.rdbDinheiro.Size = new System.Drawing.Size(87, 21);
            this.rdbDinheiro.TabIndex = 58;
            this.rdbDinheiro.TabStop = true;
            this.rdbDinheiro.Text = "Dinheiro";
            this.rdbDinheiro.UseVisualStyleBackColor = true;
            // 
            // rdbCartao
            // 
            this.rdbCartao.AutoSize = true;
            this.rdbCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCartao.Location = new System.Drawing.Point(150, 23);
            this.rdbCartao.Name = "rdbCartao";
            this.rdbCartao.Size = new System.Drawing.Size(74, 21);
            this.rdbCartao.TabIndex = 59;
            this.rdbCartao.Text = "Cartão";
            this.rdbCartao.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "Observações :";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(0)))));
            this.txtObservacao.Location = new System.Drawing.Point(137, 414);
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(451, 30);
            this.txtObservacao.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Adicionar Item";
            // 
            // cmbItens
            // 
            this.cmbItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItens.FormattingEnabled = true;
            this.cmbItens.Location = new System.Drawing.Point(12, 365);
            this.cmbItens.Name = "cmbItens";
            this.cmbItens.Size = new System.Drawing.Size(472, 33);
            this.cmbItens.TabIndex = 54;
            // 
            // btnCancela
            // 
            this.btnCancela.BackColor = System.Drawing.Color.Transparent;
            this.btnCancela.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancela.BackgroundImage")));
            this.btnCancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancela.FlatAppearance.BorderSize = 0;
            this.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancela.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Location = new System.Drawing.Point(303, 519);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(138, 58);
            this.btnCancela.TabIndex = 53;
            this.btnCancela.Text = "Cancela";
            this.btnCancela.UseVisualStyleBackColor = false;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(159, 519);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(138, 58);
            this.btnOK.TabIndex = 52;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(504, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Entrega";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.BackColor = System.Drawing.Color.DarkGreen;
            this.lblLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel.Location = new System.Drawing.Point(12, 6);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(263, 41);
            this.lblLabel.TabIndex = 1;
            this.lblLabel.Text = "Realizar Pedido";
            // 
            // dgvPedido
            // 
            this.dgvPedido.AllowUserToAddRows = false;
            this.dgvPedido.AllowUserToOrderColumns = true;
            this.dgvPedido.AllowUserToResizeColumns = false;
            this.dgvPedido.AllowUserToResizeRows = false;
            this.dgvPedido.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.dgvPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPedido.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedido.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPedido.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPedido.GridColor = System.Drawing.Color.White;
            this.dgvPedido.Location = new System.Drawing.Point(12, 55);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.RowHeadersVisible = false;
            this.dgvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedido.Size = new System.Drawing.Size(576, 276);
            this.dgvPedido.TabIndex = 0;
            this.dgvPedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedido_CellContentClick);
            this.dgvPedido.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPedido_UserDeletedRow);
            // 
            // chkMeia
            // 
            this.chkMeia.AutoSize = true;
            this.chkMeia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.chkMeia.Location = new System.Drawing.Point(490, 369);
            this.chkMeia.Name = "chkMeia";
            this.chkMeia.Size = new System.Drawing.Size(62, 29);
            this.chkMeia.TabIndex = 64;
            this.chkMeia.Text = "1/2";
            this.chkMeia.UseVisualStyleBackColor = true;
            // 
            // RealizaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCopyright);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RealizaPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPagamento.ResumeLayout(false);
            this.pnlPagamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.ComboBox cmbItens;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox pnlPagamento;
        private System.Windows.Forms.RadioButton rdbDinheiro;
        private System.Windows.Forms.RadioButton rdbCartao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label txtVlPedidoAberto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.CheckBox chkMeia;
    }
}