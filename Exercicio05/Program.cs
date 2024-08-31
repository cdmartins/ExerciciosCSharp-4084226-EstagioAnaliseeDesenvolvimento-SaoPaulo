/*5) Escreva um programa que inverta os caracteres de um string.

IMPORTANTE:
a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
b) Evite usar funções prontas, como, por exemplo, reverse;*/


Console.Write("Escreva algo: ");
string input = Console.ReadLine()!;
if (input == string.Empty)
{
    Console.WriteLine("Você não digitou nada :(");
}
else
{

    char[] arrayInput = input.ToCharArray();
    char[] invertido = new char[arrayInput.Length];
    int contador = 0;
    for (int i = invertido.Length - 1; i >= 0; i--)
    {
        invertido[contador] = arrayInput[i];
        contador++;
    }

    
    Console.WriteLine("Voce digitou: ");    
    foreach (char letra in arrayInput)
    {
        Console.Write(letra);
    }

    Console.WriteLine("\nInvertido: ");
    foreach (char letra in invertido)
    {
        Console.Write(letra);
    }




}