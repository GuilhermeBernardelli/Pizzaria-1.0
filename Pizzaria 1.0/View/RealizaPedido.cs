using Pizzaria_1._0.Control;
using Pizzaria_1._0.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Pizzaria_1._0.View
{
    public partial class RealizaPedido : Form
    {
        static Cliente clientePed;
        PDV form = new PDV();
        Pedido pedido = new Pedido();
        Controle controle = new Controle();
        static Produto produto = new Produto();
        List<Produto> listaProdutos = new List<Produto>();
        static List<Produto> produtosPedidos = new List<Produto>();
        int codigoProduto;

        public RealizaPedido(PDV pdv, Cliente cliente)
        {
            InitializeComponent();
            clientePed = cliente;
            form = pdv;
            Pesquisa_Produtos();
        }

        private void Pesquisa_Produtos()
        {            
            listaProdutos = controle.PesquisaGeralProdutos();
            cmbItens.DataSource = listaProdutos;
            cmbItens.DisplayMember = "Desc_Produto";
            cmbItens.ValueMember = "Id";
            cmbItens.SelectedIndex = -1;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            form.Enabled = true;
            form.Show();
            this.Dispose();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pedido = new Pedido();
            controle.SalvaPedido(pedido);
        }

        private void Adicionar_Pedido(List<Produto> listaProdutos)
        {                        
            DataTable dtListaProdutos = new DataTable();

            dtListaProdutos.Columns.Add("Código", typeof(string));
            dtListaProdutos.Columns.Add("Descrição", typeof(string));
            dtListaProdutos.Columns.Add("Valor", typeof(string));

            foreach (Produto value in listaProdutos)
            {
                CheckBox check = new CheckBox();
                dtListaProdutos.Rows.Add(value.Cod_Produto.ToString(), value.Desc_Produto.ToUpper(), "R$" + value.Valor_Produto.ToString());
            }

            dgvPedido.DataSource = dtListaProdutos;
            dgvPedido.Columns[0].Width = 105;
            dgvPedido.Columns[1].Width = 452;
            dgvPedido.Columns[2].Width = 120;

            dgvPedido.Columns[0].Visible = false;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            produto = controle.PesquisaProdutoByID(Convert.ToInt32(cmbItens.SelectedValue));
            produtosPedidos.Add(produto);
            txtVlPedidoAberto.Text = (Convert.ToDecimal(txtVlPedidoAberto.Text) + produto.Valor_Produto).ToString();
            Adicionar_Pedido(produtosPedidos);
        }

        private void dgvPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigoProduto = Convert.ToInt32(dgvPedido.SelectedCells[0].Value);
            produto = controle.PesquisaProdutoByCodigo(codigoProduto);
        }

        private void dgvPedido_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            txtVlPedidoAberto.Text = (Convert.ToDecimal(txtVlPedidoAberto.Text) - produto.Valor_Produto).ToString();
            produtosPedidos.Remove(produto);            
            Adicionar_Pedido(produtosPedidos);
        }
    }
}
