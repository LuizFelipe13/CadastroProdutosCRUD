using CadastroProdutosCRUD;
using System;

class Program
{
    static void Main(string[] args)
    {
        ProdutoRepositorio repo = new ProdutoRepositorio();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE CADASTRO DE PRODUTOS ===");
            Console.WriteLine("1 - Criar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Editar produto");
            Console.WriteLine("4 - Deletar produto");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarProduto(repo);
                    break;
                case "2":
                    ListarProdutos(repo);
                    break;
                case "3":
                    EditarProduto(repo);
                    break;
                case "4":
                    DeletarProduto(repo);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static void CriarProduto(ProdutoRepositorio repo)
    {
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        repo.Criar(new Produto { Nome = nome, Preco = preco });

        Console.WriteLine("Produto criado com sucesso!");
    }

    static void ListarProdutos(ProdutoRepositorio repo)
    {
        var produtos = repo.Listar();

        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        foreach (var p in produtos)
        {
            Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Preço: R$ {p.Preco}");
        }
    }

    static void EditarProduto(ProdutoRepositorio repo)
    {
        Console.Write("Informe o ID do produto a editar: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Novo nome: ");
        string novoNome = Console.ReadLine();

        Console.Write("Novo preço: ");
        decimal novoPreco = decimal.Parse(Console.ReadLine());

        if (repo.Editar(id, novoNome, novoPreco))
            Console.WriteLine("Produto editado com sucesso!");
        else
            Console.WriteLine("Produto não encontrado.");
    }

    static void DeletarProduto(ProdutoRepositorio repo)
    {
        Console.Write("ID do produto para deletar: ");
        int id = int.Parse(Console.ReadLine());

        if (repo.Deletar(id))
            Console.WriteLine("Produto deletado com sucesso!");
        else
            Console.WriteLine("Produto não encontrado.");
    }
}
