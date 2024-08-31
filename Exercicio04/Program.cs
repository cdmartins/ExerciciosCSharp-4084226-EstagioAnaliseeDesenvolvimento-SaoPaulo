/*4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
• SP – R$67.836,43
• RJ – R$36.678,66
• MG – R$29.229,88
• ES – R$27.165,48
• Outros – R$19.849,53

Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.  */

Dictionary<string, decimal> faturamentoPorEstados= new Dictionary<string, decimal>
        {
            { "SP", 67836.43m },
            { "RJ", 36678.66m },
            { "MG", 29229.88m },
            { "ES", 27165.48m },
            { "Outros", 19849.53m }
        };
decimal faturamentoTotalMensal = 0;

foreach (var item in faturamentoPorEstados)
{
    faturamentoTotalMensal += item.Value;
}
Console.WriteLine("Distribuição em porcentagens:");

foreach (var item in faturamentoPorEstados)
{
    decimal porcentagem = (item.Value / faturamentoTotalMensal) * 100;
    Console.WriteLine($"{item.Key} – R${item.Value:N2} ({porcentagem:N2}%)");
}
