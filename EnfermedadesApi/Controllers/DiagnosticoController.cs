using Microsoft.AspNetCore.Mvc;
using EnfermedadesApi.Models;

namespace EnfermedadesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticoController : ControllerBase
    {
        private readonly List<Enfermedad> enfermedades = new()
        {
            new Enfermedad
            {
                Nombre = "Parvovirus Canino",
                Descripcion = "Enfermedad viral grave que afecta el tracto gastrointestinal, muy contagiosa.",
                Sintomas = new() { "vómito", "diarrea con sangre", "fiebre", "letargo", "deshidratación" },
                Tratamiento = "Fluidoterapia intensiva, antibióticos, antieméticos y hospitalización.",
                Especies = new() { "perro" },
                Contagiosa = true,
                Urgente = "alta"
            },
            new Enfermedad
            {
                Nombre = "Moquillo Canino",
                Descripcion = "Virus que afecta el sistema respiratorio, digestivo y nervioso en perros.",
                Sintomas = new() { "tos", "fiebre", "secreción ocular", "convulsiones", "diarrea" },
                Tratamiento = "Tratamiento sintomático, aislamiento y cuidados de soporte.",
                Especies = new() { "perro" },
                Contagiosa = true,
                Urgente = "alta"
            },
            new Enfermedad
            {
                Nombre = "Gastroenteritis",
                Descripcion = "Inflamación del tracto digestivo, puede deberse a infecciones o intoxicación.",
                Sintomas = new() { "vómito", "dolor abdominal", "diarrea" },
                Tratamiento = "Reposo, hidratación, dieta blanda.",
                Especies = new() { "perro", "gato" },
                Contagiosa = false,
                Urgente = "media"
            },
            new Enfermedad
            {
                Nombre = "Toxoplasmosis",
                Descripcion = "Infección parasitaria que afecta a gatos y puede transmitirse a humanos.",
                Sintomas = new() { "diarrea", "fiebre", "letargo" },
                Tratamiento = "Clindamicina y cuidados generales.",
                Especies = new() { "gato" },
                Contagiosa = true,
                Urgente = "media"
            },
            new Enfermedad
            {
                Nombre = "Filariasis",
                Descripcion = "Infección causada por gusanos que afectan el corazón y pulmones.",
                Sintomas = new() { "tos", "fatiga", "dificultad para respirar" },
                Tratamiento = "Melarsomina y reposo.",
                Especies = new() { "perro" },
                Contagiosa = false,
                Urgente = "alta"
            }
        };

        [HttpGet("{sintoma}")]
        public IActionResult GetPorSintoma(string sintoma)
        {
            var resultado = enfermedades
                .Where(e => e.Sintomas.Any(s => s.Contains(sintoma.ToLower())))
                .ToList();

            if (!resultado.Any())
                return NotFound("No se encontraron enfermedades con ese síntoma.");

            return Ok(resultado);
        }
    }
}
