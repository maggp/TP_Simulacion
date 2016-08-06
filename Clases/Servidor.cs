using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Servidor
    {
    //    private char _EstadoServidor;
        private int _Clientes_atendidos;
        private char _Estado_servidor;
        private int _Clientes_encola;
        private Evento[] _LEV = new Evento[2];  // Posicion 0(arribo) - 1(partida)
        private List<DqTiempo> _DQtiempo = new List<DqTiempo>();
        private List<DbTiempo> _DBtiempo = new List<DbTiempo>();
        private List<DDTiempo> _DDtiempo = new List<DDTiempo>();
        private List<Momento> _momento = new List<Momento>();
        
           

        // variables de rendimiento
        private double acum_cola;
        private double acum_utilizacion;
        private double acum_demora;

       

    

       





        //seccion propiedades


    

        public List<Momento> Momento
        {
            get { return _momento; }
            set { _momento = value; }
        }


        public List<DDTiempo> DDtiempo
        {
            get { return _DDtiempo; }
            set { _DDtiempo = value; }
        }

        public List<DbTiempo> DBtiempo
        {
            get { return _DBtiempo; }
            set { _DBtiempo = value; }
        }
        public List<DqTiempo> DQtiempo
        {
            get { return _DQtiempo; }
            set { _DQtiempo = value; }
        }
        public Evento[] LEV
        {
            get { return _LEV; }
            set { _LEV = value; }
        }
        /*public char EstadoServidor
        {
            get { return _EstadoServidor; }
            set { _EstadoServidor = value; }
        }*/
        public double Acum_demora
        {
            get { return acum_demora; }
            set { acum_demora = value; }
        }
        public double Acum_utilizacion
        {
            get { return acum_utilizacion; }
            set { acum_utilizacion = value; }
        }
        public double Acum_cola
        {
            get { return acum_cola; }
            set { acum_cola = value; }
        }
        public int Clientes_atendidos
        {
            get { return _Clientes_atendidos; }
            set { _Clientes_atendidos = value; }
        }
        public int Clientes_encola
        {
            get { return _Clientes_encola; }
            set { _Clientes_encola = value; }
        }
        public char Estado_servidor
        {
            get { return _Estado_servidor; }
            set { _Estado_servidor = value; }
        }
    }
}
