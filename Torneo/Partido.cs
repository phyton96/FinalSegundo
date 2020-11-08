using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;
using System.IO;
using Parcial.Torneo;
namespace linq.Torneo
{
    public class Partido
    {
        #region Properties  
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        public List<Observer> Observadores = new List<Observer>();

        #endregion Properties

        #region Initialize
        public Partido(Seleccion EquipoLocal, Seleccion EquipoVisitante) 
        {
            this.EquipoLocal = new Equipo(EquipoLocal);
            this.EquipoVisitante = new Equipo(EquipoVisitante);
        }
        #endregion Initialize
        #region Methods

        public void RegisterObserver(Observer observador){
            Observadores.Add(observador);
        }
        public void UnregisterObserver(Observer observador){
                for(int i = 0; i < Observadores.Count(); ++i){
                    if(observador == Observadores[i]){
                        Observadores.Remove(observador);
                    }
                    else{
                        Console.WriteLine("No existe ese observador en la lista");
                    }
                }
        }
        public void NotifyObservers(){
            foreach (var Observer in Observadores)
            {
                Observer.update();
            }
        }
        
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
            ObserverGoles oPuntosLocal = new ObserverGoles();
            ObserverGoles oPuntosVisitante = new ObserverGoles();
            RegisterObserver(oPuntosLocal);
            RegisterObserver(oPuntosVisitante);
            string nombreEquipoLocal = EquipoLocal.Seleccion.Nombre;
            string nombreEquipoVisitante = EquipoVisitante.Seleccion.Nombre;
            Random random = new Random();
            int i = random.Next(0,6);
            EquipoLocal.Goles = i;
            int j = random.Next(0,6);
            EquipoVisitante.Goles = j;
            oPuntosLocal.update(nombreEquipoLocal, i);
            oPuntosVisitante.update(nombreEquipoVisitante, j);
            UnregisterObserver(oPuntosLocal);
            UnregisterObserver(oPuntosVisitante);
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
                if(EquipoLocal.Goles > EquipoVisitante.Goles){
                    ObserverPuntos oPuntosLocal = new ObserverPuntos();
                    RegisterObserver(oPuntosLocal);
                    int ganador = 3;
                    string nombreEquipoLocal = EquipoLocal.Seleccion.Nombre;
                    oPuntosLocal.update(nombreEquipoLocal, ganador);
                    UnregisterObserver(oPuntosLocal);
                }
                if(EquipoLocal.Goles < EquipoVisitante.Goles){
                    ObserverPuntos oPuntosVisitante = new ObserverPuntos();
                    RegisterObserver(oPuntosVisitante);
                    int ganador = 3;
                    string nombreEquipoVisitante = EquipoVisitante.Seleccion.Nombre;
                    oPuntosVisitante.update(nombreEquipoVisitante, ganador);
                    UnregisterObserver(oPuntosVisitante);
                }
                if(EquipoLocal.Goles == EquipoVisitante.Goles){
                    ObserverPuntos oPuntosLocal = new ObserverPuntos();
                    RegisterObserver(oPuntosLocal);
                    int ganador = 1;
                    string nombreEquipoLocal = EquipoLocal.Seleccion.Nombre;
                    oPuntosLocal.update(nombreEquipoLocal, ganador);
                    UnregisterObserver(oPuntosLocal);
                    ObserverPuntos oPuntosVisitante = new ObserverPuntos();
                    RegisterObserver(oPuntosVisitante);
                    int ganador1 = 1;
                    string nombreEquipoVisitante = EquipoVisitante.Seleccion.Nombre;
                    oPuntosVisitante.update(nombreEquipoVisitante, ganador1);
                    UnregisterObserver(oPuntosVisitante);
                }    
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
                    ObserverPuntos oPuntosVisitante = new ObserverPuntos();
                    RegisterObserver(oPuntosVisitante);
                    int ganador = 3;
                    string nombreEquipoVisitante = EquipoVisitante.Seleccion.Nombre;
                    oPuntosVisitante.update(nombreEquipoVisitante, ganador);
                    UnregisterObserver(oPuntosVisitante);
                }
                else
                {
                    EquipoLocal.Goles += 3;
                    resultado = "3 - 0";
                    ObserverPuntos oPuntosLocal = new ObserverPuntos();
                    RegisterObserver(oPuntosLocal);
                    int ganador = 3;
                    string nombreEquipoLocal = EquipoLocal.Seleccion.Nombre;
                    oPuntosLocal.update(nombreEquipoLocal, ganador);
                    UnregisterObserver(oPuntosLocal);
                }
            }
            return resultado;
        }
        #endregion Methods
    }
}