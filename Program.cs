using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using linq.Torneo;
using Newtonsoft.Json;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.menu1();
            /*
            RepositorioDatos Datos = new RepositorioDatos();
            List<Seleccion> Selecciones = Datos.Selecciones;
            Seleccion Francia = Selecciones.First(s => s.Nombre == "Francia") as Seleccion;
            Seleccion Argentina = Selecciones.FirstOrDefault(s => s.Nombre == "Argentina") as Seleccion;
            Partido partido1 = new Partido(Francia, Argentina);
            Console.WriteLine(partido1.Resultado());*/


            // Seleccion FranciaDeserializada = JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText("./selecciones.json"));
            // var jugadoresFranciaSerializados = JsonConvert.SerializeObject(Francia.Jugadores);
            // File.WriteAllText("./jugadoresFrancia.json", jugadoresFranciaSerializados);

            // List<Jugador> jugadoresDeserializados = JsonConvert.DeserializeObject<List<Jugador>>(File.ReadAllText("./jugadoresFrancia.json"));

            // Seleccion Argentina = Selecciones.FirstOrDefault(s => s.Nombre == "Argentina") as Seleccion;

            // Partido partido1 = new Partido(Francia, Argentina);
            // // partido1.Resultado();
            // Jugador jugador = new Jugador("Cristiano", 35, 7, 98, 40, 25, 3);
            // var jugadorSerializado = JsonConvert.SerializeObject(jugador);

            // File.WriteAllText("./jugadores.json", jugadorSerializado);

            // using (StreamWriter file = File.CreateText("./jugadores.json"))
            // {
            //     JsonSerializer serializer = new JsonSerializer();
            //     serializer.Serialize(file, jugadorSerializado);
            // }

            // Jugador jugador2 = JsonConvert.DeserializeObject<Jugador>(File.ReadAllText("./jugadores.json"));

            // using (StreamReader file = File.OpenText("./jugadores.json"))
            // {
            //     JsonSerializer serializer = new JsonSerializer();
            //     Jugador jugador2  = (Jugador)serializer.Deserialize(file, typeof(Jugador));
            //     Console.WriteLine(jugador2.Nombre);
            // }

            // List<String> Nombres = new List<string>();

            // foreach (Seleccion seleccion in Selecciones)
            // {
            //     if (seleccion.Nombre == "Francia")
            //     {
            //         foreach(Jugador jugador in seleccion.Jugadores)
            //         {
            //             Nombres.Add(jugador.Nombre);
            //         }
            //     }
            // }


            

            // Seleccion s = Selecciones.Where(s => s.Nombre == "Francia").ToList<Seleccion>()[0];
            // Seleccion francia = Selecciones.First(s => s.Nombre == "Francia") as Seleccion;
            // List<String> nombres2 = francia.Jugadores.Select(jugador => jugador.Nombre).ToList();

            // List<String> nombres3 = Selecciones.First(s => s.Nombre == "Francia")
            //                                    .Jugadores.Select(jugador => jugador.Nombre).ToList();

            // Jugador últimoJugador = francia.Jugadores.First(j => j.Posicion == 11);

            // Jugador jugador33 = francia.Jugadores.FirstOrDefault(j => j.Edad == 33);
            // Jugador jugador332 = francia.Jugadores.LastOrDefault(j => j.Edad == 33);

            // Seleccion Colombia = Selecciones.FirstOrDefault(s => s.Nombre == "Colombia") as Seleccion;
            // List<Jugador> JugadoresViejos = Colombia.Jugadores.Where(j => (j.Edad >= 26 && j.Edad <= 34)).ToList<Jugador>();

            // List<Jugador> JugadoresViejos2 = Colombia.Jugadores.Where(j => j.Edad >= 26)
            //                                                    .Where(j => j.Edad <= 33).ToList<Jugador>();

            // Seleccion Argentina = Selecciones.FirstOrDefault(s => s.Nombre == "Argentina") as Seleccion;
            // bool HayJugadorPro = Argentina.Jugadores.Any(j => j.Goles > 30);

            // List<Jugador> EspañaOrdenados = Selecciones.FirstOrDefault(s => s.Nombre == "España") 
            //                                            .Jugadores.OrderBy(j => j.Edad).ToList<Jugador>();

            // List<Jugador> EspañaOrdenados2 = Selecciones.FirstOrDefault(s => s.Nombre == "España") 
            //                                            .Jugadores.OrderByDescending(j => j.Edad).ToList<Jugador>();    

            // var jugadorMax = francia.Jugadores.Max(j => j.Goles);
            // var jugadorMin = francia.Jugadores.Min(j => j.Goles);

            // List<Jugador> jugadoresCombinados = francia.Jugadores.Concat(Colombia.Jugadores).OrderBy(j => j.Ataque).ToList<Jugador>();
            // int CantidadJugadores = jugadoresCombinados.Count;

        }
    }
}
