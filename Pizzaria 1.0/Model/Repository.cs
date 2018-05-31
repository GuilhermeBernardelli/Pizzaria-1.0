using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Pizzaria_1._0.Model
{
    class Repository : DbContext
    {
        ModelEntities entities = new ModelEntities();

        internal void SalvaAtualiza()
        {
            entities.SaveChanges();
        }

        internal void SalvaNovoCliente(Cliente cliente)
        {
            entities.Cliente.Add(cliente);
        }

        internal Cliente PesquisaClienteByFone(string telefone)
        {
            return (from cliente in entities.Cliente
                    where cliente.Tel_1.Equals(telefone)
                    || cliente.Tel_2.Equals(telefone)
                    || cliente.Tel_3.Equals(telefone)
                    || cliente.Tel_4.Equals(telefone)
                    select cliente).SingleOrDefault();
        }

        internal void SalvaNovoPedido(Pedido pedido)
        {
            entities.Pedido.Add(pedido);
        }

        internal List<Produto> PesquisaProdutosCompleta()
        {
            return (from produtos in entities.Produto
                    orderby produtos.Cod_Produto
                    select produtos).ToList();
        }

        internal Produto PesquisaProdutoId(int id)
        {
            return (from produtos in entities.Produto
                    where produtos.Id == id
                    select produtos).SingleOrDefault();
        }

        internal Produto PesquisaProdutoCodigo(int codigo)
        {
            return (from produtos in entities.Produto
                    where produtos.Cod_Produto == codigo
                    select produtos).SingleOrDefault();
        }

        internal void SalvaNovoPedidoProduto(Ped_Prod pedidoProduto)
        {
            entities.Ped_Prod.Add(pedidoProduto);
        }

        internal string PesquisaProdutoMaisPedido(int id_cliente)
        {
            var relProd = (from produto in entities.Ped_Prod
                        where produto.Pedido.Id_Cliente == id_cliente
                        group produto by produto.Id_Produto into grp
                        select new { key = grp.Key, cnt = grp.Count()});

            var maisPed = relProd.First();

            foreach (var prod in relProd)
            {
                if (prod.cnt > maisPed.cnt)
                {
                    maisPed = prod;
                }
            }

            return PesquisaProdutoId(Convert.ToInt32(maisPed.key)).Desc_Produto;
        }

        internal List<Pedido> PesquisaPedidosByClienteId(int id_cliente)
        {
            return (from pedido in entities.Pedido
                    where pedido.Id_Cliente == id_cliente
                    select pedido).ToList();
        }

        internal List<Ped_Prod> PesquisaProdutosPedidos(int id_pedido)
        {
            return (from pedido in entities.Ped_Prod
                    where pedido.Id_Pedido == id_pedido
                    select pedido).ToList();
        }

        internal List<Pedido> PesquisaPedidosByDate(DateTime data)
        {
            return (from pedido in entities.Pedido
                    where pedido.Dt_Pedido == data
                    orderby pedido.Dt_Pedido
                    select pedido).ToList();
        }

        internal string PesquisaProdutosUltimoPedido(int id)
        {
            List<Pedido> pedido = (from ped in entities.Pedido
                             where ped.Id_Cliente == id
                             orderby ped.Dt_Pedido
                             select ped).ToList();

            int idPedido = pedido[pedido.Count - 1].id;

            List<Ped_Prod> listaProd = (from pedProd in entities.Ped_Prod
                                        where pedProd.Id_Pedido == idPedido
                                        select pedProd).ToList();

            string textoPedido = "";

            foreach (Ped_Prod value in listaProd)
            {
                string meia = "";
                if (Convert.ToInt32(value.ProdInteiro) == 0)
                {
                    meia = "1/2";
                }
                textoPedido = string.Format(textoPedido + value.Produto.Desc_Produto + meia + "{0}", Environment.NewLine);
            }

            return textoPedido;
        }

        internal void RemoverProduto(Produto produto)
        {
            entities.Produto.Remove(produto);
        }

        internal void SalvaNovoProduto(Produto produto)
        {
            entities.Produto.Add(produto);
        }
    }
}
