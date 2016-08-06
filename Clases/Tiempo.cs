using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Tiempo
    {

        private double _Reloj;
        private double _TUE;
        private double _TIOS;
        private double _TIDS;

  
        private List<double> _VTA = new List<double>();
        private Random ran;

        private static Tiempo _instancia { get; set; }

        private Tiempo() {
            ran = new Random();
        }

        public static Tiempo instancia(){
            if (_instancia == null){
                _instancia=new Tiempo();
            }
            return _instancia;
        }

        public static void reset() {
            _instancia = null;
        }


        public double generarTiempo(double media)
        {
            double u = ran.NextDouble();
            return -(1/media)*Math.Log(u);
        }





        public double generarArribo(double lambda)  // Generar arribo con 3 decimales redondeado
        {
            double num = ran.NextDouble();
            double aleatorio = (-2) * Math.Log(num);
            return Math.Round(aleatorio,6);
            
        }


        public double generarPartida(double mu) // Generar partida con 3 decimales redondeado
        {
            double num = ran.NextDouble();
            double aleatorio = (-1 / mu) * Math.Log(num);
            return Math.Round(aleatorio, 6);

        }








        //Seccion propiedades

        public double TIDS
        {
            get { return _TIDS; }
            set { _TIDS = value; }
        }

        public List<double> VTA
        {
            get { return _VTA; }
            set { _VTA = value; }
        }

        public double TIOS
        {
            get { return _TIOS; }
            set { _TIOS = value; }
        }

        public double TUE
        {
            get { return _TUE; }
            set { _TUE = value; }
        }

        public double Reloj
        {
            get { return _Reloj; }
            set { _Reloj = value; }
        }
    }
}
