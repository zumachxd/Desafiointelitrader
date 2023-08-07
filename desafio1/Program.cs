using System;
using System.IO;

namespace IntersectFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o caminho do primeiro arquivo: ");
            string filePath1 = Console.ReadLine();
            Console.Write("Digite o caminho do segundo arquivo: ");
            string filePath2 = Console.ReadLine();
            Console.Write("Digite o nome do arquivo de saída (com extensão): ");
            string outputFileName = Console.ReadLine();

            try
            {
                string[] lines1 = File.ReadAllLines(filePath1);
                string[] lines2 = File.ReadAllLines(filePath2);

                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    foreach (string line1 in lines1)
                    {
                        foreach (string line2 in lines2)
                        {
                            if (line1 == line2)
                            {
                                writer.WriteLine(line1);
                                break;
                            }
                        }
                    }
                }

                Console.WriteLine("Interseção das linhas gravada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
            }
        }
    }
}
