using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;
using Newtonsoft.Json;
using System.IO;

namespace linq.Torneo{
    public class Menu{
        public List<string> archivos = new List<string>();
        public void menu1(){
            Console.WriteLine("\n------------Bienvenido------------");
            Console.WriteLine("---------------Menu---------------");
            Console.WriteLine("1)Funcionalidad de crear selecciones con archivos Json");
            Console.WriteLine("2)Funcionalidad de crear y ejecutar partidos");
            Console.WriteLine("3)Salir");
            Console.Write("Digite la opcion: ");
            string entrada = Console.ReadLine();
            int opcion;
            if(!Int32.TryParse(entrada, out opcion)){
                Console.WriteLine("ERROR: El valor ingresado no corresponde a un entero.");
                menu1();
            }else{
                if(opcion > 0 && opcion <= 3){
                    switch (opcion)
                    {
                        case 1:
                        menu2();
                        break;
                        case 2:
                        menu3();
                        break;
                        case 3:
                        Console.WriteLine("\nGracias por utilizar el programa.\n");
                        return;
                    }
                }else{
                    Console.WriteLine("ERROR: El numero ingresado no corresponde a una opcion.");
                    menu1();
                }
            }
        }
        public void menu2(){
            archivos = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("./nombresEquipos.json"));
            Random random = new Random();
            List<Jugador> jugadoresL = new List<Jugador>();
            Seleccion nuevaSeleccion = new Seleccion();
            Console.Write("Digite el nombre de la seleccion: ");
            string nombresel = Console.ReadLine();
            try{
                for(int i = 0; i < archivos.Count; ++i){
                    if(nombresel == archivos[i]){
                        Exception ex = new Exception("Ya existe");
                        throw ex;
                    }
                    else{
                        nuevaSeleccion.Nombre = nombresel;
                        nuevaSeleccion.PuntosTotales = 0;
                        nuevaSeleccion.GolesTotales = 0;
                        nuevaSeleccion.AsistenciasTotales = 0;
                        for(int j = 0; i < 11; ++j){
                            Console.Write("Nombre del jugador: ");
                            string nombrej = Console.ReadLine();
                            int edad = random.Next(20, 40);
                            int pos = random.Next(1, 11);
                            double ataque = random.Next(1, 100);
                            double defensa = random.Next(1, 100);
                            int goles = random.Next(0, 20);
                            int asistencias = random.Next(0, 20);
                            Jugador jugadores = new Jugador(nombrej, edad, pos, ataque, defensa, goles, asistencias); 
                            jugadoresL.Add(jugadores);
                        }
                        nuevaSeleccion.Jugadores = jugadoresL;
                        var seleccionSerializada = JsonConvert.SerializeObject(nuevaSeleccion);
                        Console.Write("Digite el nombre del archivo: ");
                        string nombreArchivo = Console.ReadLine();
                        archivos.Add(nombreArchivo);
                        string json1 = ".json";
                        string final = nombreArchivo+json1;
                        Console.WriteLine(final);
                        File.WriteAllText(final, seleccionSerializada);
                        Console.Write("\n");
                        Console.Write("Guardando en la lista");
                        var nombresEquipos1 = JsonConvert.SerializeObject(archivos);
                        File.WriteAllText("./nombresEquipos.json", nombresEquipos1);
                        Console.Write("Creado y guardado satisfactoriamente\n");
                    }
                }
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            finally{
                menu1();
            }
        }

        public void menu3(){
            Console.WriteLine("\nEstos son las Selecciones existentes para poder jugar: ");
            archivos = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("./nombresEquipos.json"));
            for(int i = 0; i < archivos.Count(); ++i){
                Console.WriteLine("-{0}", archivos[i]);
            }
            double cantidad = 0;
            if(archivos.Count % 2 == 0){
                cantidad = archivos.Count/2;
            }
            else if(archivos.Count % 2 != 0){
                cantidad = archivos.Count/2;
                cantidad = Math.Floor(cantidad);
            }
            else{
                Console.WriteLine("No es posible esa opcion, será devuelto al menu");
                menu3();
            }
            Console.WriteLine("\nLa cantidad de partidos disponible que puede ejecutar es: {0}", cantidad);
            Console.Write("Digite la cantidad de partidos que desea: ");
            string entrada = Console.ReadLine();
            int opcion;
            if(!Int32.TryParse(entrada, out opcion)){
                Console.WriteLine("ERROR: El valor ingresado no corresponde a un entero.");
                menu3();
            }
            List<string> guardar = new List<string>();
            string completar = ".json";
            string total, total1;
            if(opcion > 0 && opcion <= cantidad){
                for(int i = 0; i < opcion; ++i){
                    Console.Write("Equipo 1: ");
                    string primerEquipo = Console.ReadLine();
                    string busqueda1 = archivos.First(s => s == primerEquipo).ToString();
                    total = busqueda1 + completar;
                    Console.Write("Equipo 2: ");
                    string segundoEquipo = Console.ReadLine();
                    string busqueda2 = archivos.First(s => s == primerEquipo).ToString();
                    try{
                        if(primerEquipo == segundoEquipo){
                            Exception ex = new Exception("No puede jugar contra el mismo");
                            throw ex;
                        }
                        else{
                            total1 = busqueda2 + completar;
                            Seleccion seleccion1 = JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText(total));
                            Seleccion seleccion2 = JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText(total1));
                            Partido partido = new Partido(seleccion1, seleccion2);
                            Console.WriteLine(partido.Resultado());
                        }
                    }
                    catch(Exception ex){
                        Console.WriteLine(ex.Message);
                    }
                    finally{
                        menu1();
                    }
                }
            }
            else{
                Console.WriteLine("No selecciono un valor valido");
                Console.WriteLine("Será devuelto al menu principal\n");
                menu1();
            }
        }
    }
}