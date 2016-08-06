using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases

   // Contexto :El unico fin de esta clase es la de aportar los metodos extras ademas del pseudocodigo
    // EJ: probabilidad de 0 clientes
    // Media de las medias etc
{
    public class Momento
    {
        private char estado_servidor;

   
        private int numero_cola;

    
        private double intervaloTiempo;

        private double tiempoMomento;

    
        public Momento(double intervalo,int ncola,char estado,double tiempoMomento)
        {
            this.IntervaloTiempo = intervalo; // Intervalo del tiempo Tk+1 - TK
            this.Numero_cola = ncola; //Longitud de la cola en este momento
            this.Estado_servidor = estado; // Estado del servidor en ese momento 
            this.TiempoMomento = tiempoMomento; // El reloj en ese momento

        }









        public double TiempoMomento
        {
            get { return tiempoMomento; }
            set { tiempoMomento = value; }
        }


        public char Estado_servidor
        {
            get { return estado_servidor; }
            set { estado_servidor = value; }
        }


        public int Numero_cola
        {
            get { return numero_cola; }
            set { numero_cola = value; }
        }
        public double IntervaloTiempo
        {
            get { return intervaloTiempo; }
            set { intervaloTiempo = value; }
        }
    }
}
