namespace EnfermedadesApi.Models
{
    public class Enfermedad
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public List<string> Sintomas { get; set; } = new();
        public string Tratamiento { get; set; } = string.Empty;
        public List<string> Especies { get; set; } = new();
        public bool Contagiosa { get; set; }
        public string Urgente { get; set; } = "media";
    }
}
