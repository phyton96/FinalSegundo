using Newtonsoft.Json;

namespace linq.Torneo
{
    public class Jugador
    {
        #region Properties  
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("edad")]
        public int Edad { get; set; }
        
        [JsonIgnore]
        public int Posicion { get; set; }

        [JsonProperty("ataque")]
        public double Ataque { get; set; }

        [JsonProperty("defensa")]
        public double Defensa { get; set; }

        [JsonProperty("goles")]
        public double Goles { get; set; }

        [JsonProperty("asistencias")]
        public double Asistencias { get; set; }

        #endregion Properties

        #region Initialize
        public Jugador(string n, int e, int p, double a, double d, int g, int s) 
        {
            this.Nombre = n;
            this.Edad = e;
            this.Posicion = p;
            this.Ataque = a;
            this.Defensa = d;
            this.Goles = g;
            this.Asistencias = s;
        }
        #endregion Initialize

    }
}