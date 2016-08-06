using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class DDTiempo
    {
        private int atendidos_momento;
        private double acum_momento;
        private double demora_simple;
        private double desviacion;

        public double Desviacion
        {
            get { return desviacion; }
            set { desviacion = value; }
        }

      
        public DDTiempo(double acum_momento,int atendidos_momento,double demora)
        {
            this.Acum_momento = Math.Round(acum_momento,3);
            this.Atendidos_momento = atendidos_momento;
            this.Demora_simple = Math.Round(demora,3);
        }




        


        public double Demora_simple
        {
            get { return demora_simple; }
            set { demora_simple = value; }
        }

        public double Acum_momento
        {
            get { return acum_momento; }
            set { acum_momento = value; }
        }

        public int Atendidos_momento
        {
            get { return atendidos_momento; }
            set { atendidos_momento = value; }
        }

    }
}
