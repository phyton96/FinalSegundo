using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones.CustomExceptions;
using Parcial.Torneo;
using Newtonsoft.Json;
using System.IO;
using linq.Torneo;
namespace Parcial.Torneo
{
    public class ObserverGoles:Observer
    {
        public void update(string nombre, int goles){
            string sum = ".json";
            string total = nombre + sum;
            Seleccion actualizar = JsonConvert.DeserializeObject<Seleccion>(File.ReadAllText(total));
            actualizar.GolesTotales += goles;
            var guardado = JsonConvert.SerializeObject(actualizar);
            File.WriteAllText(total, guardado);
        }
    }
}