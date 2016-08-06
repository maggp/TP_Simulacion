using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class DbTiempo
    {
        private double acumMomento;

    
        private double tiempoMomento;


        public DbTiempo(double acum,double tiempo)
        {
            this.AcumMomento = Math.Round(acum, 3);
            this.TiempoMomento = Math.Round(tiempo, 3);
        }


        public double AcumMomento
        {
            get { return acumMomento; }
            set { acumMomento = value; }
        }

        public double TiempoMomento
        {
            get { return tiempoMomento; }
            set { tiempoMomento = value; }
        }
        
    }
}
