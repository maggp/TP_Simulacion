using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Evento
    {
        private char _Tipo_evento;
        private double _Tiempo_evento;

        // Constructor para inicializar el vector LEV
        public Evento(char tipo_evento,double tiempo_evento) 
        {
            this.Tipo_evento = tipo_evento;
            this.Tiempo_evento = tiempo_evento;
        }









        public double Tiempo_evento
        {
            get { return _Tiempo_evento; }
            set { _Tiempo_evento = value; }
        }


        public char Tipo_evento
        {
            get { return _Tipo_evento; }
            set { _Tipo_evento = value; }
        }

    }
}
