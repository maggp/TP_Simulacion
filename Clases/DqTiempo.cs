using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class DqTiempo
    {
        private double _acumuladoActual;
        private double _RelojMomento;
        private double _IntervaloSimple;
        private double _LongColaMomento;
        private double _TUE;
       

     

 

        public DqTiempo(double acumulado,double reloj,double intervalo,int lcola,double tue)
        {
            this.AcumuladoActual = Math.Round(acumulado,5);
            this.RelojMomento = Math.Round(reloj,5);
            this.IntervaloSimple =Math.Round(intervalo,5);
            this.LongColaMomento = lcola;
            this.TUE = Math.Round(tue,5);
        }



        public double LongColaMomento
        {
            get { return _LongColaMomento; }
            set { _LongColaMomento = value; }
        }

        public double IntervaloSimple
        {
            get { return _IntervaloSimple; }
            set { _IntervaloSimple = value; }
        }


        public double RelojMomento
        {
            get { return _RelojMomento; }
            set { _RelojMomento = value; }
        }

        public double AcumuladoActual
        {
            get { return _acumuladoActual; }
            set { _acumuladoActual = value; }
        }
        public double TUE
        {
            get { return _TUE; }
            set { _TUE = value; }
        }
        
    }
}
