using System;

namespace Excepciones.CustomExceptions
{
    public class LoseForWException : Exception
    {
        public LoseForWException() { }
        public LoseForWException(string Message) : base(String.Format("El equipo {0} ha perdido por W", Message)) { }

        public string NombreEquipo { get; set; }
    }
}