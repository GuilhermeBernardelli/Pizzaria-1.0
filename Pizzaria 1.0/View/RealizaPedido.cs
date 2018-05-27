using Pizzaria_1._0.Control;
using Pizzaria_1._0.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzaria_1._0.View
{
    public partial class RealizaPedido : Form
    {
        static Cliente clientePed;
        PDV form = new PDV();
        Pedido pedido = new Pedido();
        Controle controle = new Controle();
        Produto produto = new Produto();
        List<Produto> listaProdutos = new List<Produto>();

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

            dtListaProdutos.Columns.Add("Selecionar", typeof(CheckBox));
            dtListaProdutos.Columns.Add("Descrição", typeof(string));
            dtListaProdutos.Columns.Add("Valor", typeof(string));

            foreach (Produto value in listaProdutos)
            {
                CheckBox check = new CheckBox();
                dtListaProdutos.Rows.Add(check, value.Desc_Produto.ToUpper(), "R$" + value.Valor_Produto.ToString());
            }

            dgvPedido.DataSource = dtListaProdutos;
            dgvPedido.Columns[0].Width = 105;
            dgvPedido.Columns[1].Width = 362;
            dgvPedido.Columns[2].Width = 105;

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            listaProdutos.Add(controle.PesquisaProdutoByID(Convert.ToInt32(cmbItens.SelectedValue)));
            Adicionar_Pedido(listaProdutos);
        }
    }
}
