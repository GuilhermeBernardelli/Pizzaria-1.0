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
