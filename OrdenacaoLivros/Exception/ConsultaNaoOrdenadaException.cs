using System;

namespace OrdenacaoLivros.Exceptions;

public class ConsultaNaoOrdenadaException : Exception
{
    public ConsultaNaoOrdenadaException()
        : base("A consulta deve ser feita utilizando um método de ordenação explícita.") { }
}