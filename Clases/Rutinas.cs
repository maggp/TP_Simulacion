using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Rutinas
    {
       public void Inicializar(Servidor servidor,Tiempo tiempo)
        {
            tiempo.Reloj = 0;
            tiempo.TIOS = 0;
            tiempo.TUE = 0;
            servidor.Clientes_encola = 0;
            servidor.Clientes_atendidos = 0;
            tiempo.TIDS = 0;
            servidor.Estado_servidor = 'D';
            servidor.LEV[0] = new Evento('A', Tiempo.instancia().generarTiempo(0.5));
            servidor.LEV[1] = new Evento('P', Double.MaxValue);
            servidor.Acum_demora = 0;

        }



        public char Tiempos(Servidor servidor,Tiempo tiempo)
       {
           char eventosiguiente;
                if(servidor.LEV[0].Tiempo_evento<servidor.LEV[1].Tiempo_evento)
                {
                    tiempo.Reloj = servidor.LEV[0].Tiempo_evento;
                    eventosiguiente = 'A';
                }
                else
                {
                    tiempo.Reloj = servidor.LEV[1].Tiempo_evento;
                    eventosiguiente = 'P';
                }
                return eventosiguiente;
       }




        public void Arribo(Servidor servidor,Tiempo tiempo)
        {
            if(servidor.Estado_servidor=='O')
            {
                servidor.Momento.Add(new Momento(tiempo.Reloj - tiempo.TUE, servidor.Clientes_encola, 'O',tiempo.Reloj));
                servidor.Acum_cola += ((tiempo.Reloj - tiempo.TUE) * servidor.Clientes_encola);
                servidor.DQtiempo.Add(new DqTiempo(servidor.Acum_cola, tiempo.Reloj, tiempo.Reloj - tiempo.TUE,servidor.Clientes_encola,tiempo.TUE));
                ++servidor.Clientes_encola;
                servidor.Momento.Add(new Momento(tiempo.Reloj - tiempo.TUE, servidor.Clientes_encola, 'O',tiempo.Reloj));
       
                tiempo.VTA.Add(tiempo.Reloj);
            }
            else
            {
                servidor.Estado_servidor = 'O';
                tiempo.TIOS = tiempo.Reloj;
                servidor.Momento.Add(new Momento(tiempo.TIOS-tiempo.TIDS,0,'D',tiempo.Reloj));
                
                servidor.Clientes_atendidos++;
                servidor.LEV[1].Tiempo_evento = (tiempo.Reloj + Tiempo.instancia().generarTiempo(1));

            }
            servidor.LEV[0].Tiempo_evento = (tiempo.Reloj + Tiempo.instancia().generarTiempo(0.5));
            tiempo.TUE = tiempo.Reloj;
        }


        public void Partida(Servidor servidor, Tiempo tiempo)
        {
            if(servidor.Clientes_encola==0)
            {
                servidor.Estado_servidor = 'D';
                servidor.Acum_utilizacion += (tiempo.Reloj - tiempo.TIOS);
                servidor.DBtiempo.Add(new DbTiempo(servidor.Acum_utilizacion, tiempo.Reloj));
                servidor.Momento.Add(new Momento(tiempo.Reloj - tiempo.TUE,0, 'O',tiempo.Reloj));
                servidor.LEV[1].Tiempo_evento = Double.MaxValue;
                tiempo.TIDS = tiempo.Reloj;
      
            }
            else
            {
                servidor.Acum_cola += ((tiempo.Reloj - tiempo.TUE) * servidor.Clientes_encola);
                servidor.DQtiempo.Add(new DqTiempo(servidor.Acum_cola, tiempo.Reloj, tiempo.Reloj - tiempo.TUE, servidor.Clientes_encola, tiempo.TUE));
                --servidor.Clientes_encola;
                servidor.Acum_demora += tiempo.Reloj - tiempo.VTA.First();
                servidor.DDtiempo.Add(new DDTiempo(servidor.Acum_demora, servidor.Clientes_atendidos,(tiempo.Reloj-tiempo.VTA.First())));
  
                tiempo.VTA.Remove(tiempo.VTA.First());
                servidor.Clientes_atendidos++;
                servidor.LEV[1].Tiempo_evento = (tiempo.Reloj + Tiempo.instancia().generarTiempo(1));

            }
            tiempo.TUE = tiempo.Reloj;

        }












    }
}
