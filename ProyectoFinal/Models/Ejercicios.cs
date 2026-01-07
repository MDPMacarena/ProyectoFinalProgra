using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models;

public partial class Ejercicios
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Nivel { get; set; } = null!;

    public string? CodigoInicial { get; set; }

    public string CodigoEsperado { get; set; } = null!;

    public string? Pista { get; set; }

    public string? ImagenReferencia { get; set; }
}
