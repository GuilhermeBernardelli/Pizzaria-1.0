using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Pizzaria_1._0.Control;
using Pizzaria_1._0.Model;

namespace Pizzaria_1._0.View
{
    public partial class PDV : Form
    {
        Controle controle = new Controle();
        static Cliente cliente = new Cliente();
        List<Produto> listaProdutos = new List<Produto>();       
        Produto produto = new Produto();
        bool alteracao = false;
        int codigoProduto;
        static bool cadastrado;

        #region Gererica

        public PDV()
        {
            InitializeComponent();

            btnPDV.PerformClick();

            this.txtMaisPedida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtUltPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));

            Desabilita_Campos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPDV_Click(object sender, EventArgs e)
        {
            AcceptButton = btnPedir;
            CancelButton = btnLimpar;
            txtBusca.Focus();
            pnlPDV.Visible = true;
            pnlProdutos.Visible = false;
            pnlPedidos.Visible = false;
            Desabilita_Campos();            
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            AcceptButton = btnProdutos;
            CancelButton = btnLimpaProd;
            txtCodProd.Focus();
            pnlPDV.Visible = false;
            pnlProdutos.Visible = true;
            pnlPedidos.Visible = false;
            Pesquisa_Produtos();            
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            pnlPDV.Visible = false;
            pnlProdutos.Visible = false;
            pnlPedidos.Visible = true;

            Exibe_Pedidos(DateTime.Today);
        }

        private void btnGerencia_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region PDV

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (controle.PesquisaClienteFone(txtBusca.Text) != null)
            {
                cadastrado = true;
            }
            else
            {
                cadastrado = false;
            }

            if (!txtNome.Text.Equals(""))
            {
                RealizaPedido form = new RealizaPedido(this,cliente);
                form.Show();
                this.Enabled = false;
                btnPedir.Visible = true;
                btnSalvarCliente.Visible = false;
                btnAlterar.Visible = true;
                AcceptButton = btnPedir;
            }

            if (cadastrado)
            {
                btnAlterar.Visible = true;

                cliente = controle.PesquisaClienteFone(txtBusca.Text);

                txtNome.Text = cliente.Nome;
                txtEndereço.Text = cliente.End_Rua;
                txtNum.Text = cliente.End_Num;
                txtBairro.Text = cliente.End_Bairro;
                txtComplemento.Text = cliente.End_Complemento;
                txtReferencia.Text = cliente.End_Refer;
                txtDDD1.Text = cliente.DDD_1.ToString();
                txtTel1.Text = cliente.Tel_1;
                txtDDD2.Text = cliente.DDD_2.ToString();
                txtTel2.Text = cliente.Tel_2;
                txtDDD3.Text = cliente.DDD_3.ToString();
                txtTel3.Text = cliente.Tel_3;
                txtDDD4.Text = cliente.DDD_4.ToString();
                txtTel4.Text = cliente.Tel_4;
                if (controle.PesquisaPedidosCliente(cliente.Id).Count() > 0)
                {
                    txtMaisPedida.Text = controle.pesquisaMaisPedida(cliente.Id);
                    txtUltPedido.Text = controle.pesquisaUltPedido(cliente.Id);
                }
            }
            else
            {
                Habilita_Campos();
                txtTel1.Text = txtBusca.Text;
                btnSalvarCliente.Visible = true;
                btnPedir.Visible = false;
                AcceptButton = btnSalvarCliente;
            }

            txtBusca.Text = txtTel1.Text;
        }

        private bool Campos_Preenchidos()
        {
            bool valido = true;

            if (txtNome.Text.Trim().Equals("") || txtEndereço.Text.Trim().Equals("") || txtNum.Text.Trim().Equals("") || txtBairro.Text.Trim().Equals("")
                || ((txtDDD1.Text.Trim().Equals("") || txtTel1.Text.Trim().Equals("")) && (txtDDD2.Text.Trim().Equals("") && txtTel2.Text.Trim().Equals(""))
                && (txtDDD3.Text.Trim().Equals("") && txtTel3.Text.Trim().Equals("")) && (txtDDD4.Text.Trim().Equals("") && txtTel4.Text.Trim().Equals(""))))
            {
                valido = false;
            }
            else if (txtDDD1.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtDDD1.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtDDD1.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtDDD1.Text.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                valido = false;
            }
            else if (txtTel1.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtTel1.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtTel1.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtTel1.Text.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                valido = false;
            }
            else if (txtDDD2.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtDDD2.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtDDD2.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtDDD2.Text.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                valido = false;
            }
            else if (txtTel2.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtTel2.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtTel2.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtTel2.Text.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                valido = false;
            }
            else if (txtDDD3.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtDDD3.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtDDD3.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtDDD3.Text.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                valido = false;
            }
            else if (txtTel3.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtTel3.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtTel3.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtTel3.Text.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                valido = false;
            }
            else if (txtDDD4.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtDDD4.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtDDD4.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtDDD4.Text.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                valido = false;
            }
            else if (txtTel4.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtTel4.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtTel4.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtTel4.Text.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                valido = false;
            }

            return valido;
        }

        public void Habilita_Campos()
        {
            btnAlterar.Visible = false;
            txtBusca.Enabled = false;
            this.txtBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtNome.Enabled = true;
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtEndereço.Enabled = true;
            this.txtEndereço.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtNum.Enabled = true;
            this.txtNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtBairro.Enabled = true;
            this.txtBairro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtComplemento.Enabled = true;
            this.txtComplemento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtDDD1.Enabled = true;
            this.txtDDD1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtTel1.Enabled = true;
            this.txtTel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtDDD2.Enabled = true;
            this.txtDDD2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtTel2.Enabled = true;
            this.txtTel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtDDD3.Enabled = true;
            this.txtDDD3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtTel3.Enabled = true;
            this.txtTel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtDDD4.Enabled = true;
            this.txtDDD4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtTel4.Enabled = true;
            this.txtTel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtReferencia.Enabled = true;
            this.txtReferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        }

        public void Desabilita_Campos()
        {
            btnSalvarCliente.Visible = false;
            txtBusca.Enabled = true;
            this.txtBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            txtNome.Enabled = false;
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtEndereço.Enabled = false;
            this.txtEndereço.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtNum.Enabled = false;
            this.txtNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtBairro.Enabled = false;
            this.txtBairro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtComplemento.Enabled = false;
            this.txtComplemento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtDDD1.Enabled = false;
            this.txtDDD1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtTel1.Enabled = false;
            this.txtTel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtDDD2.Enabled = false;
            this.txtDDD2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtTel2.Enabled = false;
            this.txtTel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtDDD3.Enabled = false;
            this.txtDDD3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtTel3.Enabled = false;
            this.txtTel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtDDD4.Enabled = false;
            this.txtDDD4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtTel4.Enabled = false;
            this.txtTel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            txtReferencia.Enabled = false;
            this.txtReferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Desabilita_Campos();
            txtBusca.Text = "";
            txtNome.Text = "";
            txtEndereço.Text = "";
            txtNum.Text = "";
            txtBairro.Text = "";
            txtComplemento.Text = "";
            txtReferencia.Text = "";
            txtDDD1.Text = "";
            txtDDD2.Text = "";
            txtDDD3.Text = "";
            txtDDD4.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            txtTel3.Text = "";
            txtTel4.Text = "";
            txtUltPedido.Text = "";
            txtMaisPedida.Text = "";
            btnPedir.Visible = true;
            btnSalvarCliente.Visible = false;
            btnAlterar.Visible = false;
            AcceptButton = btnPedir;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Habilita_Campos();
            btnPedir.Visible = false;
            btnSalvarCliente.Visible = true;
            AcceptButton = btnPedir;
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            Desabilita_Campos();
            try
            {                                
                if (txtBusca.Enabled && (txtBusca.Text.Length < 4 || txtBusca.Text.Where(c => char.IsLetter(c)).Count() > 0 || txtBusca.Text.Where(c => char.IsPunctuation(c)).Count() > 0
                    || txtBusca.Text.Where(c => char.IsSeparator(c)).Count() > 0 || txtBusca.Text.Where(c => char.IsSymbol(c)).Count() > 0))
                {
                    MessageBox.Show("O Campo de busca (Telefone) deve ser preenchido somente com números e por ao menos 4 digitos.");
                }
                else if (cadastrado)
                {                    

                    btnPedir.Visible = true;
                    AcceptButton = btnSalvarCliente;

                    btnAlterar.Visible = true;                   

                    cliente.Nome = txtNome.Text.Trim().ToUpper();
                    cliente.End_Rua = txtEndereço.Text.Trim().ToUpper();
                    cliente.End_Num = txtNum.Text.Trim().ToUpper();
                    cliente.End_Bairro = txtBairro.Text.Trim().ToUpper();
                    cliente.End_Complemento = txtComplemento.Text.Trim().ToUpper();
                    cliente.End_Refer = txtReferencia.Text.Trim().ToUpper();

                    if (!txtTel1.Text.Equals(""))
                    {
                        cliente.DDD_1 = Convert.ToInt32(txtDDD1.Text);
                        cliente.Tel_1 = txtTel1.Text.Trim();
                    }
                    if (!txtTel2.Text.Equals(""))
                    {
                        cliente.DDD_2 = Convert.ToInt32(txtDDD2.Text);
                        cliente.Tel_2 = txtTel2.Text.Trim();
                    }
                    if (!txtTel3.Text.Equals(""))
                    {
                        cliente.DDD_3 = Convert.ToInt32(txtDDD3.Text);
                        cliente.Tel_3 = txtTel3.Text.Trim();
                    }
                    if (!txtTel4.Text.Equals(""))
                    {
                        cliente.DDD_4 = Convert.ToInt32(txtDDD4.Text);
                        cliente.Tel_4 = txtTel4.Text.Trim();
                    }

                    controle.SalvaAlteracao();

                }
                else if (controle.PesquisaClienteFone(txtBusca.Text) == null && !cadastrado)
                {
                    btnAlterar.Visible = true;
                    btnPedir.Visible = true;
                    cadastrado = true;
                    if (Campos_Preenchidos())
                    {
                        cliente = new Cliente();
                        controle.SalvaCliente(cliente);
                        cliente.Nome = txtNome.Text.Trim().ToUpper();
                        cliente.End_Rua = txtEndereço.Text.Trim().ToUpper();
                        cliente.End_Num = txtNum.Text.Trim().ToUpper();
                        cliente.End_Bairro = txtBairro.Text.Trim().ToUpper();
                        cliente.End_Complemento = txtComplemento.Text.Trim().ToUpper();
                        cliente.End_Refer = txtReferencia.Text.Trim().ToUpper();
                        if (!txtTel1.Text.Equals(""))
                        {
                            cliente.DDD_1 = Convert.ToInt32(txtDDD1.Text);
                            cliente.Tel_1 = txtTel1.Text.Trim();
                        }
                        if (!txtTel2.Text.Equals(""))
                        {
                            cliente.DDD_2 = Convert.ToInt32(txtDDD2.Text);
                            cliente.Tel_2 = txtTel2.Text.Trim();
                        }
                        if (!txtTel3.Text.Equals(""))
                        {
                            cliente.DDD_3 = Convert.ToInt32(txtDDD3.Text);
                            cliente.Tel_3 = txtTel3.Text.Trim();
                        }
                        if (!txtTel4.Text.Equals(""))
                        {
                            cliente.DDD_4 = Convert.ToInt32(txtDDD4.Text);
                            cliente.Tel_4 = txtTel4.Text.Trim();
                        }
                        controle.SalvaAlteracao();
                    }
                    else if (txtBusca.Enabled)
                    {
                        txtTel1.Text = txtBusca.Text;
                        txtBusca.Enabled = false;
                        Habilita_Campos();
                    }
                    else
                    {
                        MessageBox.Show("Os campos Nome, Endereço, Nº, Bairro e ao menos um telefone deve ser preenchido.");
                    }
                }
                else
                {
                    cliente = controle.PesquisaClienteFone(txtBusca.Text);
                    txtNome.Text = cliente.Nome;
                    txtEndereço.Text = cliente.End_Rua;
                    txtNum.Text = cliente.End_Num;
                    txtBairro.Text = cliente.End_Bairro;
                    txtComplemento.Text = cliente.End_Complemento;
                    txtReferencia.Text = cliente.End_Refer;
                    txtDDD1.Text = cliente.DDD_1.ToString();
                    txtTel1.Text = cliente.Tel_1;
                    txtDDD2.Text = cliente.DDD_2.ToString();
                    txtTel2.Text = cliente.Tel_2;
                    txtDDD3.Text = cliente.DDD_3.ToString();
                    txtTel3.Text = cliente.Tel_3;
                    txtDDD4.Text = cliente.DDD_4.ToString();
                    txtTel4.Text = cliente.Tel_4;

                    btnAlterar.Visible = true;
                    btnPedir.Visible = false;
                    btnSalvarCliente.Visible = true;
                    AcceptButton = btnSalvarCliente;
                }
            }
            catch
            {

            }

        }

        #endregion

        #region Produtos

        private void Pesquisa_Produtos()
        {
            DataTable dtListaProdutos = new DataTable();
            listaProdutos = controle.PesquisaGeralProdutos();

            dtListaProdutos.Columns.Add("Código", typeof(string));
            dtListaProdutos.Columns.Add("Descrição", typeof(string));
            dtListaProdutos.Columns.Add("Valor", typeof(string));

            foreach (Produto value in listaProdutos)
            {
                dtListaProdutos.Rows.Add(value.Cod_Produto.ToString(), value.Desc_Produto.ToUpper(), "R$" + value.Valor_Produto.ToString());
            }

            dgvProdutos.DataSource = dtListaProdutos;
            dgvProdutos.Columns[0].Width = 105;
            dgvProdutos.Columns[1].Width = 362;
            dgvProdutos.Columns[2].Width = 105;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCodProd.Text.Equals("") || txtDescProd.Text.Equals("") || txtValorProd.Text.Equals(""))
            {
                MessageBox.Show("Todos os campos são de preenchimento obrigatório.");
            }
            else
            {
                if (!alteracao)
                {
                    produto = new Produto();
                    controle.SalvaProduto(produto);
                    produto.Cod_Produto = Convert.ToInt32(txtCodProd.Text);
                    produto.Desc_Produto = txtDescProd.Text;
                    produto.Valor_Produto = Convert.ToDecimal(txtValorProd.Text);
                }
                else
                {
                    produto.Cod_Produto = Convert.ToInt32(txtCodProd.Text);
                    produto.Desc_Produto = txtDescProd.Text;
                    produto.Valor_Produto = Convert.ToDecimal(txtValorProd.Text);
                }
                controle.SalvaAlteracao();
                btnLimpaProd.PerformClick();
            }
        }
        

        private void btnLimpaProd_Click(object sender, EventArgs e)
        {
            Pesquisa_Produtos();
            txtCodProd.Text = "";
            txtDescProd.Text = "";
            txtValorProd.Text = "";
            alteracao = false;
        }       

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            alteracao = true;
            codigoProduto = Convert.ToInt32(dgvProdutos.SelectedCells[0].Value);
            produto = controle.PesquisaProdutoByCodigo(codigoProduto);
            txtCodProd.Text = produto.Cod_Produto.ToString();
            txtDescProd.Text = produto.Desc_Produto;
            txtValorProd.Text = produto.Valor_Produto.ToString();
        }

        private void dgvProdutos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            alteracao = false;
            produto = controle.PesquisaProdutoByCodigo(codigoProduto);
            controle.RemoveProduto(produto);
            controle.SalvaAlteracao();
            Pesquisa_Produtos();
        }

        #endregion

        #region Pedidos

        public void Exibe_Pedidos(DateTime data)
        {
            lblPeriodoPedido.Text = "Pedidos do dia " + data.ToShortDateString();

            List<Pedido> listaPedidos = controle.PesquisaPedidosData(data);

            txtPedidoDia.Text = "";

            foreach (Pedido value in listaPedidos)
            {
                bool primeiro = true;

                List<Ped_Prod> prodPedidos = controle.PesquisaProdutosByPedido(value.id);

                foreach (Ped_Prod prod in prodPedidos)
                {
                    string meia = "";
                    if (Convert.ToInt32(prod.ProdInteiro) == 0)
                    {
                        meia = " 1/2";
                    }
                    Produto produto = controle.PesquisaProdutoByID(prod.Id_Produto);
                    if (primeiro)
                    {
                        primeiro = false;
                        txtPedidoDia.Text = string.Format(txtPedidoDia.Text + "=> " + value.Cliente.End_Rua + "," + value.Cliente.End_Num + "    " + value.Observacao + "{0}\t" + prod.Produto.Desc_Produto + meia + " - " + prod.Produto.Valor_Produto, Environment.NewLine);
                    }
                    else
                    {
                        txtPedidoDia.Text = string.Format(txtPedidoDia.Text + " {0}\t" + prod.Produto.Desc_Produto + meia + " - " + prod.Produto.Valor_Produto, Environment.NewLine);
                    }
                }
                if (!primeiro)
                {
                    txtPedidoDia.Text = string.Format(txtPedidoDia.Text + "{0}{0}", Environment.NewLine);
                }
            }
        }

        private void Calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            Exibe_Pedidos(e.Start);
        }


        #endregion
        
    }
}
