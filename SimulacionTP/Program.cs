using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;
using System.IO;

namespace SimulacionTP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> mediaMEdias = new List<double>();
            double contadorMedias = 0;
            double contadorDesvio = 0;
            double media = 0;
            double desvio = 0;
            double alfa = 1.65;
            double int_Valor_Min = 0;
            double int_Valor_Max = 0;
            double valor_Max_Estable = 0;
            double valor_Min_Estable = 0;
            List<double> valor_Min = new List<double>();
            List<double> valor_Max = new List<double>();
            List<DqTiempoIF> dqIF = new List<DqTiempoIF>();
            double IF_Min = 50;
            double IF_Max = 10000;
            double IF = 0;
            double totalDQ = 0;
            double acumMediaTiempo = 0;
            double acum = 0;
            double calculoDesvioTiempo = 0;
            StreamWriter swMediaDeMEdias = new StreamWriter("C:\\Valores\\Medias.txt");
            StreamWriter swDesvioReplicas = new StreamWriter("C:\\Valores\\DesvioM.txt");

            StreamWriter swMdMTiempo = new StreamWriter("C:\\Valores\\MediaTiempo.txt");


            StreamWriter swDTiempo = new StreamWriter("C:\\Valores\\DesvioTiempo.txt");
            int CantReplicas = 50;

            for (int replicas = 0; replicas < CantReplicas; replicas++)
            {
                
               

                Servidor servidor = new Servidor();
                Tiempo tiempo = Tiempo.instancia();
                Rutinas rutinas = new Rutinas();




                rutinas.Inicializar(servidor, tiempo);

                while (tiempo.Reloj <= 10000)
                {
                    if (rutinas.Tiempos(servidor, tiempo) == 'A')
                    {
                        rutinas.Arribo(servidor, tiempo);
                    }
                    else
                    {
                        rutinas.Partida(servidor, tiempo);
                    }

                }

                Console.WriteLine("Longitud promedio de clientes en cola"+(servidor.Acum_cola / tiempo.Reloj));
                Console.WriteLine("Demora promedio" + servidor.Acum_demora / servidor.Clientes_atendidos);
                Console.WriteLine("Utilizacion del servidor" + servidor.Acum_utilizacion / tiempo.Reloj);
                
                contadorMedias +=servidor.Acum_cola/tiempo.Reloj;
                contadorDesvio = Math.Pow((servidor.Acum_cola / tiempo.Reloj) - (servidor.Acum_cola / tiempo.Reloj) / (replicas + 1),2);
           
                media = contadorMedias/(replicas+1);
                desvio = contadorDesvio / (replicas);
                if (replicas <= 70)
                {
                    int_Valor_Min = media - ((desvio * alfa) / Math.Sqrt(CantReplicas));
                    int_Valor_Max = media + ((desvio * alfa) / Math.Sqrt(CantReplicas));

                }
                if(replicas == 70)
                {
                    valor_Max_Estable = int_Valor_Max ;
                    valor_Min_Estable = int_Valor_Min ;
                }
                if (replicas > 70)
                {
                    int_Valor_Max = valor_Max_Estable;
                    int_Valor_Min = valor_Min_Estable;
                }

                swMediaDeMEdias.WriteLine((replicas + 1) + " " + media + " " + int_Valor_Min + " " + int_Valor_Max);
                swDesvioReplicas.WriteLine((replicas + 1) + " " + desvio);
                if (replicas == 0)
                 {

                     // Todo son ejecuciones de archivos solo se ejecutaran 1 ves y nada mas.


                     double tiempo_acum = 0;
                     int contador = 0;
                     double demoratotal = 0;
                     double tiempototal = 0;


                     contador = 0;

                     StreamWriter swP0 = new StreamWriter("C:\\Valores\\P0.txt");

                     foreach (Momento i in servidor.Momento)
                     {
                         if ((i.Estado_servidor == 'D') && (i.Numero_cola == 0))
                             tiempototal += i.IntervaloTiempo;
                         swP0.WriteLine(tiempototal + " " + tiempototal / i.TiempoMomento);
                     }
                     swP0.Close();

                     Console.WriteLine("tiempo de 0 " + (tiempototal / tiempo.Reloj));






                     StreamWriter swDD = new StreamWriter("C:\\Valores\\DDTiempo.txt");
                     foreach (DDTiempo i in servidor.DDtiempo)
                     {
                         swDD.WriteLine(i.Atendidos_momento+" "+i.Acum_momento/i.Atendidos_momento);
                     }

                     swDD.Close();


                     // Varianza de la demora
                     double varianza = 0;
                     StreamWriter swDdDesviacion = new StreamWriter("C:\\Valores\\DesviacionDd.txt");
                     foreach (DDTiempo i in servidor.DDtiempo)
                     {
                         varianza += Math.Pow(i.Demora_simple,2)/(servidor.Clientes_atendidos);
                         
                     }


                     // Hago varia la media  en el tiempo en la desviacion a medida que se va a acercando
                     // a la media original se acerca a la varianza original
                     foreach(DDTiempo i in servidor.DDtiempo)
                     {
                      swDdDesviacion.WriteLine(i.Atendidos_momento+" "+(varianza -( Math.Pow(i.Acum_momento/i.Atendidos_momento,2))));
                     }
                     swDdDesviacion.Close();



                     StreamWriter swDBTiempo = new StreamWriter("C:\\Valores\\DBTiempo.txt");
                     foreach (DbTiempo i in servidor.DBtiempo)
                     {
                         swDBTiempo.WriteLine(i.TiempoMomento + " " + Math.Round(i.AcumMomento / i.TiempoMomento, 3));
                     }
                     swDBTiempo.Close();






                     StreamWriter swTiempo = new StreamWriter("C:\\Valores\\DQTiempo.txt");
                     foreach (DqTiempo i in servidor.DQtiempo)
                     {
                         swTiempo.WriteLine(i.RelojMomento + " " + i.IntervaloSimple + " " + Math.Round(i.AcumuladoActual / i.RelojMomento, 3) + " " + i.LongColaMomento);
                       
                     }

                    
                     swTiempo.Close();

                    
                 }

                IF = IF_Min;
                totalDQ = 0;
                do
                {
                    foreach (DqTiempo i in servidor.DQtiempo)
                    {

                        if (i.RelojMomento <= IF)
                        {
                            totalDQ = totalDQ + ((i.RelojMomento - i.TUE) * i.LongColaMomento);

                        }
                        else
                        {
                            totalDQ = totalDQ + ((IF - i.TUE) * i.LongColaMomento);
                            dqIF.Add(new DqTiempoIF(replicas, IF, totalDQ));
                            IF += IF_Min;
                        }
                        
                    }
                    IF = 30000;
                } while (IF <= IF_Max);

            }
            
            IF = IF_Min;
            do
            {
                acumMediaTiempo = 0;
                foreach (DqTiempoIF i in dqIF)
                {
                    if (i.It_Fija == IF)
                    {
                        acumMediaTiempo = acumMediaTiempo + (i.Acum_dq/50);
                    }

                   
                }
                
                swMdMTiempo.WriteLine(IF + " " + Math.Round(acumMediaTiempo / IF,5));
                calculoDesvioTiempo = Math.Pow((acumMediaTiempo/IF)/(IF+1),2) - Math.Pow((acumMediaTiempo/IF),2);
                swDTiempo.WriteLine(IF + " " + Math.Round(calculoDesvioTiempo/IF,5));
                IF += IF_Min;
                
                    
            } while (IF <= IF_Max);

            swMdMTiempo.Close();
            swDTiempo.Close();
            swMediaDeMEdias.Close();
            swDesvioReplicas.Close();


                Console.ReadKey();
            }
       


        
    }
}
