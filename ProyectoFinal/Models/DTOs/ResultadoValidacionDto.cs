namespace ProyectoFinal.Models.DTOs
{
    public class ResultadoValidacionDto
    {
        public bool EsCorrecto { get; set; }
        public string Mensaje { get; set; } = null!;
        public int Similitud { get; set; } 

    }
}
