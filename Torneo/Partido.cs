using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;
namespace linq.Torneo
{
    public class Partido
    {
        #region Properties  
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }

        #endregion Properties

        #region Initialize
        public Partido(Seleccion EquipoLocal, Seleccion EquipoVisitante) 
        {
            this.EquipoLocal = new Equipo(EquipoLocal);
            this.EquipoVisitante = new Equipo(EquipoVisitante);
        }
        #endregion Initialize
        #region Methods
        
        private void CalcularExpulsiones()
        {
            Random random = new Random();
            int tamRojas1 = random.Next(1,5);
            Console.WriteLine("Tarjetas Rojas Equipo Local: {0}", tamRojas1);
            while(tamRojas1 > 0){
                List<string> jugadoresVacios = Enumerable.Repeat(string.Empty, 50).ToList();
                List<String> JugadoresLocales = EquipoLocal.Seleccion.Jugadores.Select(j => j.Nombre).ToList().Concat(jugadoresVacios).ToList();
                int position = random.Next(JugadoresLocales.Count);
                String expulsadoLocal = JugadoresLocales[position];
                EquipoLocal.ExpulsarJugador(expulsadoLocal);
                tamRojas1--;
            }
            int tamRojas2 = random.Next(1,5);
            Console.WriteLine("Tarjetas Rojas Equipo Visitante: {0}", tamRojas2);
            while(tamRojas2 > 0){
                List<string> jugadoresVacios = Enumerable.Repeat(string.Empty, 50).ToList();
                List<String> JugadoresVisitantes = EquipoVisitante.Seleccion.Jugadores.Select(j => j.Nombre).ToList().Concat(jugadoresVacios).ToList();
                int position = random.Next(JugadoresVisitantes.Count);
                String expulsadoVisitante = JugadoresVisitantes[position];
                EquipoVisitante.ExpulsarJugador(expulsadoVisitante);
                tamRojas2--;
            }
        }
        

        private void CalcularTarjetasAmarillas()
        {
            Random random = new Random();
            int tamAmarillas1 = random.Next(0,8);
            Console.WriteLine("Tarjetas Amarillas Equipo Local : {0}",tamAmarillas1);
            while(tamAmarillas1 > 0){
                List<String> JugadoresLocales = EquipoLocal.Seleccion.Jugadores.Select(j => j.Nombre).ToList();
                int position = random.Next(JugadoresLocales.Count);
                String amarillolocal = JugadoresLocales[position];
                EquipoLocal.AmarillaJugador(amarillolocal);
                tamAmarillas1--;
            }
            int tamAmarillas2 = random.Next(0,5);
            Console.WriteLine("Tarjetas Amarillas Equipo Visitante: {0}",tamAmarillas2);
            while(tamAmarillas2 > 0){
                List<String> JugadoresVisitantes = EquipoVisitante.Seleccion.Jugadores.Select(j => j.Nombre).ToList();
                int position = random.Next(JugadoresVisitantes.Count);
                String amarilloVisitante = JugadoresVisitantes[position];
                EquipoVisitante.AmarillaJugador(amarilloVisitante);
                tamAmarillas2--;
            }
        }


        private void CalcularResultado()
        {
            Random random = new Random();
            EquipoLocal.Goles = random.Next(0,6);
            EquipoVisitante.Goles = random.Next(0,6);
        }

        public string Resultado()
        {
            string resultado = "0 - 0";
            try
            {
                Console.WriteLine("----Empieza el partido----\n");
                CalcularTarjetasAmarillas();
                CalcularExpulsiones();
                Console.WriteLine("Resultado del partido\n");
                CalcularResultado();
                resultado = EquipoLocal.Goles.ToString() + " - " + EquipoVisitante.Goles.ToString();
            }
            catch(LoseForWException ex)
            {
                Console.WriteLine(ex.Message);
                EquipoLocal.Goles -= EquipoLocal.Goles;
                EquipoVisitante.Goles -= EquipoVisitante.Goles;
                if (ex.NombreEquipo == EquipoLocal.Seleccion.Nombre)
                {
                    EquipoVisitante.Goles += 3;
                    resultado = "0 - 3";
                }
                else
                {
                    EquipoLocal.Goles += 3;
                    resultado = "3 - 0";
                }
            }
            return resultado;
        }
        #endregion Methods
    }
}