using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
   public class DqTiempoIF
    {
        private int _Replica;
        private double _It_Fija;
        private double _Acum_dq;

        public DqTiempoIF(int nroReplica, double IF, double acumulado)
        {
            this.Acum_dq = Math.Round(acumulado, 5);
            this.It_Fija = IF;
            this.Replica = nroReplica;
        }



        public double Acum_dq
        {
            get { return _Acum_dq; }
            set { _Acum_dq = value; }
        }

        public double It_Fija
        {
            get { return _It_Fija; }
            set { _It_Fija = value; }
        }

        public int Replica
        {
            get { return _Replica; }
            set { _Replica = value; }
        }
    }
}
