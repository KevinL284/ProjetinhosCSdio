using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstacionamento
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }

        public Veiculo(string placa, string modelo)
        {
            Placa = placa;
            Modelo = modelo;
        }

        public override string ToString()
        {
            return $"Placa: {Placa}, Modelo: {Modelo}";
        }
    }

    public class Estacionamento
    {
        private List<Veiculo> veiculos = new List<Veiculo>();

        public void CadastrarVeiculo(string placa, string modelo)
        {
            Veiculo veiculo = new Veiculo(placa, modelo);
            veiculos.Add(veiculo);
            Console.WriteLine("Veículo cadastrado com sucesso!");
        }

        public void RemoverVeiculo(string placa)
        {
            Veiculo veiculo = veiculos.Find(v => v.Placa == placa);
            if (veiculo != null)
            {
                veiculos.Remove(veiculo);
                Console.WriteLine("Veículo removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado!");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Veículos cadastrados:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Nenhum veículo cadastrado.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Estacionamento estacionamento = new Estacionamento();
            bool entradaValida = true;

            while (entradaValida)
            {
                try
                {
                    Console.WriteLine("Bem vindo ao estacionamento. Escolha a operação. \n 1 - Cadastrar Veículo \n 2 - Remover Veículo \n 3 - Listar veículos \n 4 - Encerrar.\n ");
                    int escolha = int.Parse(Console.ReadLine());

                    switch (escolha)
                    {
                        case 1:
                            Console.WriteLine("Digite a placa do veículo:");
                            string placa = Console.ReadLine();
                            Console.WriteLine("Digite o modelo do veículo:");
                            string modelo = Console.ReadLine();
                            estacionamento.CadastrarVeiculo(placa, modelo);
                            break;
                        case 2:
                            Console.WriteLine("Digite a placa do veículo a ser removido:");
                            placa = Console.ReadLine();
                            estacionamento.RemoverVeiculo(placa);
                            break;
                        case 3:
                            estacionamento.ListarVeiculos();
                            break;
                        case 4:
                            entradaValida = false;
                            Console.WriteLine("Encerrando o sistema...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida, favor escolha outra.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valor inválido, tente novamente.");
                }
            }
        }
    }
}
