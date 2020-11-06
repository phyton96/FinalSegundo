using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;

namespace linq.Torneo
{
    public class Equipo
    {
        #region Properties  
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public int Faltas { get; set; }
        public int TarjetasAmarillas { get; set; }
        public int TarjetasRojas { get; set; }
        public Seleccion Seleccion { get; set; }
        public bool EsLocal { get; set; }
        public List<string> JugadoresAmarilla = new List<string>();

        #endregion Properties

        #region Initialize
        public Equipo(Seleccion seleccion)
        {
            this.Seleccion = seleccion;
        }
        #endregion Initialize

        #region Methods
        public void ExpulsarJugador(string name)
        {
            try
            {
                Jugador jugadorExpulsado = Seleccion.Jugadores.First(j => j.Nombre == name);
                TarjetasRojas++;
                Console.WriteLine("El jugador expulsado fue {0}",jugadorExpulsado.Nombre);
                if (Seleccion.Jugadores.Count <= 6)
                {
                    LoseForWException ex = new LoseForWException(Seleccion.Nombre);
                    ex.NombreEquipo = Seleccion.Nombre;
                    throw ex;
                }
                Seleccion.Jugadores.Remove(jugadorExpulsado);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No existe ese jugador para expulsarlo del equipo " + Seleccion.Nombre);
            }
        }


        public void AmarillaJugador(string name)
        {
            try
            {
                Jugador jugadorAmarilla = Seleccion.Jugadores.First(j => j.Nombre == name);
                if( JugadoresAmarilla.Count == 0 )
                {
                    TarjetasAmarillas++;
                    Console.WriteLine("El jugador con amarilla fue {0}",jugadorAmarilla.Nombre);
                    JugadoresAmarilla.Add(name);
                }
                else
                {
                    for(int i = 0; i < JugadoresAmarilla.Count(); ++i){
                        if(JugadoresAmarilla[i] == name){
                            TarjetasAmarillas++;
                            Console.WriteLine("El jugador con amarilla fue {0}",jugadorAmarilla.Nombre);
                            JugadoresAmarilla.Remove(JugadoresAmarilla[i]);
                            ExpulsarJugador(name);
                        }
                        else{
                            return;
                        }
                    }
                }   
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Ha ocurrido un error comuniquese con el admin");
            }
        }
        #endregion Methods
    }
}