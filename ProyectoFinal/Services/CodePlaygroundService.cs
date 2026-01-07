using ProyectoFinal.Models.DTOs;
using ProyectoFinal.Models;
using ProyectoFinal.Repositories;
using System.Text.RegularExpressions;

namespace ProyectoFinal.Services
{
    public class CodePlaygroundService
    {
        public Repository<Ejercicios> EjerciciosRepository { get; }

        public CodePlaygroundService(Repository<Ejercicios> ejerciciosRepository)
        {
            EjerciciosRepository = ejerciciosRepository;
        }
        public EjerciciosResponseDto GetEjerciciosPorTipo(string tipo)
        {
            var ejercicios = EjerciciosRepository.GetAll()
                .Where(e => e.Tipo.ToLower() == tipo.ToLower())
                .OrderBy(e => e.Id)
                .Select(e => new EjercicioDto
                {
                    Id = e.Id,
                    Titulo = e.Titulo,
                    Descripcion = e.Descripcion,
                    Tipo = e.Tipo,
                    Nivel = e.Nivel,
                    CodigoInicial = e.CodigoInicial,
                    Pista = e.Pista,
                    ImagenReferencia = e.ImagenReferencia
                })
                .ToList();

            return new EjerciciosResponseDto
            {
                Tipo = tipo,
                Ejercicios = ejercicios
            };
        }

        // Validar código del usuario
        public ResultadoValidacionDto ValidarCodigo(ValidarCodigoDto validacion)
        {
            var ejercicio = EjerciciosRepository.Get(validacion.EjercicioId);

            if (ejercicio == null)
            {
                return new ResultadoValidacionDto
                {
                    EsCorrecto = false,
                    Mensaje = "Ejercicio no encontrado",
                    Similitud = 0
                };
            }

            // Normalizar código para comparación (quita espacios extra y saltos de línea)
            string codigoUsuario = NormalizarCodigo(validacion.Codigo);
            string codigoEsperado = NormalizarCodigo(ejercicio.CodigoEsperado);

            // Comparar si son iguales
            bool esCorrecto = codigoUsuario == codigoEsperado;

            // Calcular similitud simple
            int similitud = esCorrecto ? 100 : 0;

            return new ResultadoValidacionDto
            {
                EsCorrecto = esCorrecto,
                Mensaje = esCorrecto ? "¡Correcto! 🎉" : "Intenta de nuevo 💡",
                Similitud = similitud
            };
        }

        // Normalizar código: quita espacios múltiples, saltos de línea y convierte a minúsculas
        private string NormalizarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return string.Empty;

            // Quitar todos los espacios en blanco y saltos de línea
            codigo = Regex.Replace(codigo, @"\s+", "");

            // Convertir a minúsculas
            return codigo.ToLower();
        }
    }
}