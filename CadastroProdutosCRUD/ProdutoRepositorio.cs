using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutosCRUD
{
    public class ProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();
        private int proximoId = 1;

        public void Criar(Produto produto)
        {
            produto.Id = proximoId++;
            produtos.Add(produto);
        }

        public List<Produto> Listar()
        {
                       return produtos;
        }

        public Produto BuscarPorId(int id)
        {
            return produtos.FirstOrDefault(p => p.Id == id);
        }

        public bool Editar (int id, string novoNome, decimal novoPreco)
        {
            var produto = BuscarPorId(id);
            if (produto == null) return false;

            produto.Nome = novoNome;
            produto.Preco = novoPreco;

            return true;

        }

        public bool Deletar(int id)
        {
            var produto = BuscarPorId(id);
            return produtos.Remove(produto);
        }
    }
}
