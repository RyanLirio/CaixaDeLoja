using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace CaixaDeLoja
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fazer um programa para ler o código de uma peça 1, o número
            // de peças 1, o valor unitário de cada peça 1, o
            //código de uma peça 2, o número de peças 2 e o valor unitário
            // de cada peça 2. Calcule e mostre o valor a ser pago
            Caixa();
        }

        static public void Caixa()
        {
            int codigo = 0, quantidade = 0;
            double valor = 0;
            Console.Clear();
            Console.WriteLine("Informe o código do produto:");
            try
            {
                codigo = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Opção inválida! O código é caracterizado por numeros (Reinicie o programa)");
                Thread.Sleep(1500);
                Console.WriteLine("");
            }

            Console.WriteLine("Informe quantas peças do produto:");
            try
            {
                quantidade = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Opção inválida! A quantidade deve ser descrita por numeros (Reinicie o programa)");
                Thread.Sleep(1500);
                Console.WriteLine("");
            }

            Console.WriteLine("Informe o valor da unidade do produto:");
            try
            {
                valor = double.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Opção inválida! O valor deve ser descrito por numeros (Reinicie o programa)");
                Thread.Sleep(15000);
            }

            double item1 = quantidade * valor;
            Console.Clear();

            Console.WriteLine("Deseja adicionar mais peças?");
            Console.WriteLine("1 - Adicionar mais peças");
            Console.WriteLine("2 - Finalizar a compra");
            Console.WriteLine("0 - Cancelar a compra");
            int resposta = int.Parse(Console.ReadLine());
            Adicionar(((int)resposta), ((int)item1), ((int)codigo));
        }

        static public void Adicionar(int resposta, int item1, int codigo)
        {
            switch (((int)resposta))
            {
                case 1: SomaProdutos((int)item1, ((int)codigo)); break;
                case 2: Console.WriteLine($"Valor final: {item1}"); break;
                case 0: Console.WriteLine("Compra cancelada"); break;
                default: Environment.Exit(0); break;
            }
        }
        static void SomaProdutos(int item1, int codigo)
        {
            Console.Clear();
            int[] somaDosProdutos = new int[100];
            somaDosProdutos[0] = ((int)item1);
            int indice = 1;
            
            int[] codigos = new int[100];
            codigos[0] = codigo;
            int indiceCod = 1;
            int codigo1 = 0;

            do
            {
                Console.WriteLine("Informe o código do produto:");
                codigo1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe quantas peças do produto:");
                int quantidade1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o valor da unidade do produto:");
                double valor1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Pressione ENTER para adicionar outra peça, se quiser finalizar a compra, pressione ESC");

                codigos[indiceCod] = codigo1;
                indiceCod++;

                double item = quantidade1 * valor1;
                somaDosProdutos[indice] = ((int)item);
                indice++;
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.Clear();

            for(int i = 0; i < indiceCod;i++)
            {
                Console.Write($"Valor do produto {codigos[i]}: ");
                Console.WriteLine($"{somaDosProdutos[i]}");
                
            }
        }

    }
}