/*Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores
(exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na linguagem que desejar onde, informado um número, 
ele calcule a sequência de Fibonacci e retorne uma mensagem avisando se o número informado pertence ou não a sequência.*/

Console.Write("Número: ");
if (int.TryParse(Console.ReadLine(), out int input))
{
    bool pertence = PertenceFibonacci(input);
    if (pertence)
    {
        Console.WriteLine($"{input} << Está na sequência de Fibonacci");
    }
    else
    {
        Console.WriteLine($"{input} << Não está na sequência de Fibonacci");
    }
}
else
{
    Console.WriteLine("Número inválido.");
}


bool PertenceFibonacci(int input)
{
    if(input < 0)
    {
        return false;
    }
    if(input == 0 || input == 1)
    {
        return true;
    }

    int primeiro_numero = 0, segundo_numero = 1, soma = 0;

    //Defino até onde percorrer para achar o numero digitado 
    while(soma < input)
    {
        /*Lógica para aplicar a sequência de Fibonacci somando os dois numeros anteriores*/
        soma = primeiro_numero + segundo_numero;
        primeiro_numero = segundo_numero;
        segundo_numero = soma;

    }
    return soma == input;
}