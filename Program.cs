using System;
using System.Collections.Generic;

class Program
{
    static List<Produto> listaProdutos = new List<Produto>();
    static int proximoID = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Adicionar Produto");
            Console.WriteLine("2 - Remover Produto pelo ID");
            Console.WriteLine("3 - Editar Produto pelo ID");
            Console.WriteLine("4 - Visualizar todos os Produtos");
            Console.WriteLine("5 - Sair");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        AdicionarProduto();
                        break;
                    case 2:
                        RemoverProduto();
                        break;
                    case 3:
                        EditarProduto();
                        break;
                    case 4:
                        VisualizarProdutos();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

    static void AdicionarProduto()
    {
        Console.WriteLine("Digite o nome do produto:");
        string nome = Console.ReadLine();
        Produto produto = new Produto { ID = proximoID++, Nome = nome };
        listaProdutos.Add(produto);
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void RemoverProduto()
    {
        Console.WriteLine("Digite o ID do produto a ser removido:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Produto produto = listaProdutos.Find(p => p.ID == id);
            if (produto != null)
            {
                listaProdutos.Remove(produto);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void EditarProduto()
    {
        Console.WriteLine("Digite o ID do produto a ser editado:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Produto produto = listaProdutos.Find(p => p.ID == id);
            if (produto != null)
            {
                Console.WriteLine("Digite o novo nome do produto:");
                string novoNome = Console.ReadLine();
                produto.Nome = novoNome;
                Console.WriteLine("Produto editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void VisualizarProdutos()
    {
        Console.WriteLine("Lista de Produtos:");
        foreach (Produto produto in listaProdutos)
        {
            Console.WriteLine($"ID: {produto.ID}, Nome: {produto.Nome}");
        }
    }
}

class Produto
{
    public int ID { get; set; }
    public string Nome { get; set; }
}

