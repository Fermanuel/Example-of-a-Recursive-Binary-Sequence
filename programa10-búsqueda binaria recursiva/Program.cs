using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace programa10_búsqueda_binaria_recursiva
{
    internal class Program
    {
        public class Recursividad
        {
            public int[] A = new int[10];
            public void OrdenarArreglo()
            {
                Random rnd = new Random();

                for (int i = 0; i < A.Length; i++)
                {
                    A[i] = rnd.Next(10,99);
                }
                
                Array.Sort(A);

                for (int i = 0;i < A.Length; i++)
                {
                    Console.WriteLine(i + 1 + "). " + A[i]);
                }
            }
            public int BusquedaBinaria(int Key, int Low, int High)
            {
                int mid;
                
                if (Low > High)
                {
                    return -1;
                }   
                else
                {
                    mid = (Low + High) / 2;

                    if (Key == A[mid])
                    {
                        return (mid);
                    }
                    else
                    {
                        if (Key < A[mid])
                        {
                            return BusquedaBinaria(Key,Low,mid - 1);
                        }
                        else
                        {
                            return BusquedaBinaria(Key,mid + 1,High);
                        }    
                    }
                }
            }
            ~Recursividad()
            {
                Console.WriteLine("\nMemoria liberada Clase Recursividad");
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "BUSQUEDA BINARIA RECURSIVA";
           
            Stopwatch stopWatch = new Stopwatch();
            Recursividad n = new Recursividad();

            long totalInicio = System.GC.GetTotalMemory(true);
            stopWatch.Start();

            int op = 8,key=0,bajo=0,alto=9;
            
            
            do
            {
                Console.Clear();
                
                Console.WriteLine("\tMENU");
                Console.WriteLine("\n[1] Generar y Ordenar un Arreglo de 10 numeros.");
                Console.WriteLine("[2] Buscar un Elemento en Particular.");
                Console.WriteLine("[3] Salir del Programa.");
                
                Console.Write("\nOPCION: ");
               
                try
                {
                    op = Int16.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            Console.Clear();

                            Console.WriteLine("Arreglo \n");

                            n.OrdenarArreglo();


                            break;
                        case 2:

                            Console.Clear();

                            Console.Write("Numero a Buscar: ");
                            key = Int16.Parse(Console.ReadLine());

                            int Index = n.BusquedaBinaria(key,bajo,alto);

                            if (Index == -1)
                            {
                                Console.WriteLine("\nEl numero {0} NO esta en el Arreglo.",key);
                            }
                            else
                            {
                                Console.WriteLine("\nEl numero {0} Esta en la Posicion {1}", key, Index + 1);
                            }

                            break;
                        case 3:
                            stopWatch.Stop();

                            TimeSpan ts = stopWatch.Elapsed;

                            string elapsedTime = string.Format("\n{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                            Console.WriteLine("\nRun Time" + elapsedTime + " Milisegundos");
                            
                            long totalFin = System.GC.GetTotalMemory(true);
                            
                            Console.WriteLine("\nLa Cantidad de memoria en bytes utilizada es de: {0}",totalFin - totalInicio);
                            
                            stopWatch.Restart();

                            break;
                        default:

                            Console.WriteLine("\nOpcion NO valida...");
                            Console.ReadKey(true);

                            break;
                    }
                }
                catch (FormatException a)
                {
                    Console.WriteLine("\n{0}",a.Message);
                    Console.ReadKey(false);
                }
                finally
                {
                    Console.WriteLine("\nPresione <ENTER> para Continuar...");
                    Console.ReadKey();
                }
            } while (op!=3);
        }
    }
}
