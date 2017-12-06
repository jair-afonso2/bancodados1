using System;
using System.Collections.Generic;

namespace ExemploCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Papelaria");
            int opcao = 0;

            do
            {
                Console.WriteLine("\nDigite a opção:\n");
                System.Console.WriteLine("1 - Adicionar Categoria.");
                System.Console.WriteLine("2 - Atualizar Categoria.");
                System.Console.WriteLine("3 - Apagar Categoria.");
                System.Console.WriteLine("4 - Listar Categoria ID.");
                System.Console.WriteLine("5 - Listar Categoria Nome.");
                System.Console.WriteLine("6 - Adicionar Cliente.");
                System.Console.WriteLine("9 - Sair\n");

                opcao = Convert.ToInt16(Console.ReadLine());

                Categoria categoria = new Categoria();
                BancoDados bd = new BancoDados();
                Cliente cliente = new Cliente();
                List <Categoria> lista;

                switch (opcao)
                {
                    case 1:
                    
                        System.Console.Write("\nTítulo: ");
                        categoria.Titulo = Console.ReadLine();

                        if(bd.Adicionar(categoria))
                            System.Console.WriteLine("Adicionado com sucesso.");

                        break;

                    case 2:
                        System.Console.Write("\nAtualizar Categoria ID: ");
                        int atualizar = Convert.ToInt32(Console.ReadLine());

                        System.Console.Write("Novo Nome: ");
                        string NovoNome = Console.ReadLine();

                        categoria.IdCategoria = atualizar;
                        categoria.Titulo = NovoNome;

                        if(bd.Atualizar(categoria))
                            System.Console.WriteLine("Atualizado com sucesso.");

                        break;

                    case 3:
                        System.Console.Write("Apagar Categoria ID: ");
                        int deletar = Convert.ToInt32(Console.ReadLine());

                        categoria.IdCategoria = deletar;

                        if(bd.Apagar(categoria))
                            System.Console.WriteLine("Apagado com sucesso.");

                        break;

                    case 4:
                        System.Console.Write("Listar Categoria ID: ");
                        int IdCategoria = Convert.ToInt32(Console.ReadLine());

                        categoria.IdCategoria = IdCategoria;

                        lista = bd.ListarCategorias(IdCategoria);

                        foreach (Categoria x in lista)
                        {
                            System.Console.WriteLine("ID: " + x.IdCategoria + "\nNome: " + x.Titulo);
                        }

                        break;

                    case 5:
                        System.Console.Write("Listar Categoria Nome: ");
                        string NomeCategoria = Console.ReadLine();

                        categoria.Titulo = NomeCategoria;

                        lista = bd.ListarCategorias(NomeCategoria);

                        foreach (Categoria x in lista)
                        {
                            System.Console.WriteLine("\nID: " + x.IdCategoria + "\nNome: " + x.Titulo);
                        }
                        break;

                    case 6:
                        System.Console.Write("Cliente Nome: ");
                        cliente.NomeCliente = Console.ReadLine();

                        System.Console.Write("Email: ");
                        cliente.Email = Console.ReadLine();

                        System.Console.Write("Cpf: ");
                        cliente.Cpf = Console.ReadLine();

                        if(bd.AdicionarCliente(cliente))
                            System.Console.WriteLine("Adicionado com sucesso.");

                        break;

                    case 9:
                        break;

                    default:
                        System.Console.WriteLine("Opção inválida.\n");
                        break;
                }
            } while (opcao != 9);

        }
    }
}
