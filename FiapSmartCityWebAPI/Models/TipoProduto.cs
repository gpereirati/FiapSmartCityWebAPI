using System;
using System.Collections.Generic;
using System.Linq;
namespace FiapSmartCityWebAPI.Models
{
    public class TipoProduto
    {
        public int IdTipo { get; set; }
        public String DescricaoTipo { get; set; }
        public bool Comercializado { get; set; }

        public List<Produto> Produtos { get; set; }

        public TipoProduto()
        {
            this.Produtos = new List<Produto>();
        }

        // MOCK - Método para adicionar um produto ao Tipo
        public void Adiciona(Produto produto)
        {
            this.Produtos.Add(produto);
        }

        // MOCK - Método para remover um produto do tipo
        public void Remove(long id)
        {
            Produto produto = Produtos.FirstOrDefault(p => p.IdProduto == id);

            Produtos.Remove(produto);
        }

        // MOCK - Método para alterar um produto do tipo
        public void Altera(Produto produto)
        {
            Remove(produto.IdProduto);
            Adiciona(produto);
        }
    }
}