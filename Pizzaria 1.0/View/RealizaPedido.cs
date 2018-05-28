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
        static decimal vlAux;
        static decimal vlAux1;
        static decimal valor;
        List<int> listaPosicao = new List<int>();

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

            clientePed = new Cliente();
            form = new PDV();
            pedido = new Pedido();
            controle = new Controle();
            produto = new Produto();
            listaProdutos = new List<Produto>();
            produtosPedidos = new List<Produto>();
            codigoProduto = new int();
            vlAux = new decimal();
            vlAux1 = new decimal();
            valor = new decimal();
            listaPosicao = new List<int>();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pedido = new Pedido();
            controle.SalvaPedido(pedido);
            pedido.Id_Cliente = clientePed.Id;
            int pg;
            if (rdbDinheiro.Checked)
            {
                pg = 1;
            }
            else
            {
                pg = 2;
            }
            pedido.Id_Pagamento = pg;
            pedido.Observacao = txtObservacao.Text;
            pedido.Dt_Pedido = DateTime.Today;
            pedido.Valor_Pedido = Convert.ToDecimal(txtVlPedidoAberto.Text);

            controle.SalvaAlteracao();

            foreach (DataGridViewRow linha in dgvPedido.Rows)
            {
                bool inteiro = true;

                if (linha.Cells[1].Value.ToString().Contains("1/2"))
                {
                    inteiro = false;
                }
                
                Ped_Prod pedidoProduto = new Ped_Prod();
                controle.SalvaPedidoProduto(pedidoProduto);
                pedidoProduto.Id_Pedido = pedido.id;
                pedidoProduto.Id_Produto = controle.PesquisaProdutoByCodigo(Convert.ToInt32(linha.Cells[0].Value)).Id;
                pedidoProduto.ProdInteiro = inteiro; 
                controle.SalvaAlteracao();
            }


            PDV fecha = new PDV(/*clientePed, pedido*/);
            fecha.Show();
            
            form.Dispose();
            this.Dispose();
        }

        private void Adicionar_Pedido(List<Produto> listaProdutos)
        {
            valor = 0.00M;
            vlAux1 = 0.00M;
            int qntMeia = 0;

            for (int i = 0; i < listaProdutos.Count; i++)
            {

                vlAux = Convert.ToDecimal(listaProdutos[i].Valor_Produto);

                if (listaPosicao[i] == 1)
                {
                    qntMeia++;

                    if (qntMeia == 2)
                    {
                        qntMeia = 0;
                        if (vlAux > vlAux1)
                        {
                            vlAux1 = 0.00M;
                            valor = valor + vlAux;
                        }
                        else
                        {
                            vlAux = 0.00M;
                            valor = valor + vlAux1;
                        }
                    }
                    else
                    {
                        vlAux1 = Convert.ToDecimal(listaProdutos[i].Valor_Produto);
                    }
                }
                else
                {
                    valor = valor + Convert.ToDecimal(listaProdutos[i].Valor_Produto);
                }
            }
            txtVlPedidoAberto.Text = valor.ToString();

            DataTable dtListaProdutos = new DataTable();

            dtListaProdutos.Columns.Add("Código", typeof(string));
            dtListaProdutos.Columns.Add("Descrição", typeof(string));
            dtListaProdutos.Columns.Add("Valor", typeof(string));

            string meia = "";           

            for (int i = 0; i < listaProdutos.Count; i++)
            {
                meia = "";

                if (listaPosicao[i] == 1)
                {
                    meia = " 1/2";
                }

                dtListaProdutos.Rows.Add(listaProdutos[i].Cod_Produto.ToString(), listaProdutos[i].Desc_Produto.ToUpper() + meia, "R$" + listaProdutos[i].Valor_Produto.ToString());
            }

            dgvPedido.DataSource = dtListaProdutos;
            dgvPedido.Columns[0].Width = 105;
            dgvPedido.Columns[1].Width = 452;
            dgvPedido.Columns[2].Width = 120;

            dgvPedido.Columns[0].Visible = false;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (chkMeia.Checked)
            {
                listaPosicao.Add(1);
            }
            else
            {
                listaPosicao.Add(0);
            }

            produto = controle.PesquisaProdutoByID(Convert.ToInt32(cmbItens.SelectedValue));           
            produtosPedidos.Add(produto);                        
            
            Adicionar_Pedido(produtosPedidos);
        }

        private void dgvPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigoProduto = Convert.ToInt32(dgvPedido.SelectedCells[0].Value);
            produto = controle.PesquisaProdutoByCodigo(codigoProduto);
        }

        private void dgvPedido_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

            listaPosicao.RemoveAt(dgvPedido.SelectedRows[0].Index);
            produtosPedidos.RemoveAt(dgvPedido.SelectedRows[0].Index);

            Adicionar_Pedido(produtosPedidos);
        }
    }
}
