using System;

namespace SistemaGestaoEventos;

public class Palestrante : Pessoa
{
    public decimal ValorHora { get; set; }

    public override string ObterDescricao()
    {
        return $"{Nome} - {Email} - R$ {ValorHora}/hora";
    }
}