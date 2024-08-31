using System.Xml.Serialization;
using static Program;

/*3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
• O menor valor de faturamento ocorrido em um dia do mês;
• O maior valor de faturamento ocorrido em um dia do mês;
• Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.*/

public class Program
{
    [XmlRoot("FaturamentoMensal")]
    public class FaturamentoMensal
    {
        [XmlArray("Faturamentos")]
        [XmlArrayItem("Faturamento")]
        public Faturamento[]? Faturamentos { get; set; }
    }

    public class Faturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    static void Main()
    {
        try
        {

            string caminhoArquivo = @"C:\Users\User\source\repos\ExerciciosCSharp - 4084226 - Estágio Análise e Desenvolvimento - São Paulo\Exercicio03\faturamento.xml";


            XmlSerializer serializer = new XmlSerializer(typeof(FaturamentoMensal));
            using (FileStream fileStream = new FileStream(caminhoArquivo, FileMode.Open))
            {
                FaturamentoMensal faturamentoMensal = (FaturamentoMensal)serializer.Deserialize(fileStream)!;


                Faturamento[] faturamentos = faturamentoMensal.Faturamentos!;


                var faturamentosValidos = faturamentos.Where(f => f.Valor > 0).ToArray();

                if (faturamentosValidos.Length == 0)
                {
                    Console.WriteLine("Não há faturamento registrado no mês.");
                    return;
                }

                double menorFaturamento = faturamentosValidos.Min(f => f.Valor);
                double maiorFaturamento = faturamentosValidos.Max(f => f.Valor);


                double soma = faturamentosValidos.Sum(f => f.Valor);
                double mediaMensal = soma / faturamentosValidos.Length;


                int diasAcimaDaMedia = faturamentosValidos.Count(f => f.Valor > mediaMensal);

                Console.WriteLine($"O menor valor de faturamento: {menorFaturamento:C}");
                Console.WriteLine($"O maior valor de faturamento: {maiorFaturamento:C}");
                Console.WriteLine($"Número de dias no mês em que o valor de faturamento diário foi superior à média mensal: {diasAcimaDaMedia}\nMédia mensal: {mediaMensal}");

            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Arquivo de faturamento não encontrado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}