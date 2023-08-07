using System;

namespace desafioCriptografia
{
  class CifraDeCesar
  {
    static string Criptografar(string mensagem, int deslocamento)
    {
      var criptografada = "";

      foreach (char letra in mensagem)
      {
        if (char.IsLetter(letra))
        {
          char limiteAlfabeto = char.IsUpper(letra) ? 'Z' : 'z';
          char deslocada = (char)(letra + deslocamento);

          if (deslocada > limiteAlfabeto)
          {
            deslocada = (char)(deslocada - 26);
          }
          criptografada += deslocada;
        }
        else
        {
          criptografada += letra;
        }
      }

      return criptografada;
    }

    static string Descriptografar(string mensagem, int deslocamento)
    {
      return Criptografar(mensagem, -deslocamento);
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Escolha uma opção:");
      Console.WriteLine("1 - Criptografar");
      Console.WriteLine("2 - Descriptografar");

      char escolha = Console.ReadKey().KeyChar;
      Console.WriteLine();

      if (escolha != '1' && escolha != '2')
      {
        Console.WriteLine("Erro: Escolha inválida.");
        return;
      }

      Console.Write("Digite o caminho do arquivo de entrada: ");
      string arquivoEntrada = Console.ReadLine();

      if (!File.Exists(arquivoEntrada))
      {
        Console.WriteLine("Erro: O arquivo de entrada não existe.");
        return;
      }

      Console.Write("Digite o caminho do arquivo de saída: ");
      string arquivoSaida = Console.ReadLine();

      Console.Write("Digite um valor de deslocamento: ");
      int deslocamento = int.Parse(Console.ReadLine());

      string conteudo = File.ReadAllText(arquivoEntrada);
      string resultado = "";

      switch (escolha)
      {
        case '1':
          resultado = Criptografar(conteudo, deslocamento);
          break;

        case '2':
          resultado = Descriptografar(conteudo, deslocamento);
          break;
      }

      File.WriteAllText(arquivoSaida, resultado);
      Console.WriteLine("Resultado gravado no arquivo de saída.");
    }
  }
}

