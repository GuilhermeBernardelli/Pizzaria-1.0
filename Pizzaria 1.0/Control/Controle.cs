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
    }
}
