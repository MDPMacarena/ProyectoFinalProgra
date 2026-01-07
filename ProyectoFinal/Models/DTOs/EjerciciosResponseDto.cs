namespace ProyectoFinal.Models.DTOs
{
    public class EjerciciosResponseDto
    {
        public IEnumerable<EjercicioDto> Ejercicios { get; set; } = null!;
        public string Tipo { get; set; } = null!;
    }
}
public class EjercicioDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public string Nivel { get; set; } = null!;
    public string? CodigoInicial { get; set; }
    public string? Pista { get; set; }
    public string? ImagenReferencia { get; set; }
}
