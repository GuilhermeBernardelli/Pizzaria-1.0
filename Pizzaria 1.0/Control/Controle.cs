using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzaria_1._0.Model;

namespace Pizzaria_1._0.Control
{
    class Controle
    {
        Repository entitie = new Repository();

        public void SalvaAlteracao()
        {
            entitie.SalvaAtualiza();
        }

        internal void SalvaCliente(Cliente cliente)
        {
            entitie.SalvaNovoCliente(cliente);
        }

        internal Cliente PesquisaClienteFone(string busca)
        {
            string telefone = busca;

            return entitie.PesquisaClienteByFone(telefone);
        }

        internal void SalvaPedido(Pedido pedido)
        {
            entitie.SalvaNovoPedido(pedido);
        }

        internal List<Produto> PesquisaGeralProdutos()
        {
            return entitie.PesquisaProdutosCompleta();
        }

        internal void SalvaProduto(Produto produto)
        {
            entitie.SalvaNovoProduto(produto);
        }

        internal Produto PesquisaProdutoByID(int pesquisa)
        {
            int id = pesquisa;

            return entitie.PesquisaProdutoId(id);
        }

        internal Produto PesquisaProdutoByCodigo(int codigoProduto)
        {
            int codigo = codigoProduto;

            return entitie.PesquisaProdutoCodigo(codigo);
        }

        internal void RemoveProduto(Produto produto)
        {
            entitie.RemoverProduto(produto);
        }

        internal void SalvaPedidoProduto(Ped_Prod pedidoProduto)
        {
            entitie.SalvaNovoPedidoProduto(pedidoProduto);
        }

        internal string pesquisaMaisPedida(int id_cliente)
        {
            int id = id_cliente;

            return entitie.PesquisaProdutoMaisPedido(id);
        }

        internal string pesquisaUltPedido(int id_cliente)
        {
            int id = id_cliente;

            return entitie.PesquisaProdutosUltimoPedido(id);
        }

        internal List<Pedido> PesquisaPedidosData(DateTime data)
        {
            return entitie.PesquisaPedidosByDate(data);
        }

        internal List<Ped_Prod> PesquisaProdutosByPedido(int id)
        {
            int id_pedido = id;

            return entitie.PesquisaProdutosPedidos(id_pedido);
        }

        internal List<Pedido> PesquisaPedidosCliente(int id)
        {
            int id_cliente = id;

            return entitie.PesquisaPedidosByClienteId(id_cliente);
        }
    }
}
