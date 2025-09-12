using System;

public static class ConsoleHelper
{
    /// <summary>
    /// Imprime uma linha separadora no console.
    /// </summary>
    /// <param name="separatorChar">Caractere usado para a separação (ex: '-', '_', '=')</param>
    /// <param name="length">Comprimento da linha</param>
    /// <param name="addEmptyLines">Adiciona linhas em branco antes e depois?</param>
    public static void PrintSeparator(char separatorChar = '_', int length = 50, bool addEmptyLines = true)
    {
        if (addEmptyLines) Console.WriteLine();
        Console.WriteLine(new string(separatorChar, length));
        if (addEmptyLines) Console.WriteLine();
    }
}