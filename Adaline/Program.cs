using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adaline
{
    class Program
    {
        static double[][] setTable()
        {
            double[][] Array = new double[][] 
            {
                // new double[] {0,0,0},
                // new double[] {0,1,0},
                // new double[] {1,0,0},
                // new double[] {1,1,0}
                new double[] {0,0,0,0,0},
                new double[] {0,0,0,1,1},
                new double[] {0,0,1,0,2},
                new double[] {0,0,1,1,3},
                new double[] {0,1,0,0,4},
                new double[] {0,1,0,1,5},
                new double[] {0,1,1,0,6},
                new double[] {0,1,1,1,7},
                new double[] {1,0,0,0,8},
                new double[] {1,0,0,1,9}
            };
            return Array;        
        }

        static double getOutput(List<double> weights, double[] entryCase)
        {
            double res = 0;
            for(int i = 0; i<weights.Count(); i++)
            {
                res += weights[i] * entryCase[i];
            }
            return res;
        }

        static void Main(string[] args)
        {
            // declaracion de variables
            long contador = 1;
            double b;
            bool loop = false;
            Random rnd = new Random();
            double[][] table;
            double errTolerane = .3;
            double Err;
            int rows, colums;
            double output;
            double gradient, errTemp;
            double learningFactor;
            double sumErr;
            List<double> weights = new List<double>();
            List<double> tempWeights = new List<double>();
            // asigno valores iniciales
            table = setTable();
            b = 1;
            rows = table.Count();
            colums = table[0].Count();
            for(int i=0; i<colums-1; i++)
            {
                weights.Add(rnd.Next(1, 1000));
            }
           
            gradient = 0;
            Err = 1;
            learningFactor = 0.2;
            //ciclo de revision

            /*for(int i = 0; i<weights.Count();i++)
            {
                Console.WriteLine("Peso " + i.ToString() + ": " + weights[i].ToString());
            }
            Console.ReadLine();

            for(int i = 0; i<table.Length; i++)
            {
                for(int j = 0; j < table[0].Length; j++)
                {
                    Console.Write(table[i][j].ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();*/

            while (!loop)
            {
                sumErr = 0;
                for(int i = 0; i < rows; i++)
                {
                    errTemp = table[i][colums - 1] - getOutput(weights, table[i]);
                    sumErr += Math.Pow(errTemp, 2);
                }

                Err = sumErr / rows;

                if(Err< errTolerane)
                {
                    break;
                }


                
                for(int i=0; i<weights.Count();i++)
                {
                   gradient = 0;
                   for(int j=0; j<rows ; j++)
                   {
                       output = getOutput(weights, table[j]);
                       gradient += table[j][i] * (table[j][colums - 1] - getOutput(weights, table[j]));
                       Console.WriteLine("Gradient: " + gradient);
                   }
                   weights[i] += gradient * learningFactor;
                }

                gradient = 0;

                for(int i=0; i<rows; i++)
                {
                    gradient += 2 * learningFactor * (table[i][colums - 1] - getOutput(weights, table[i]));
                }

                b += gradient;
                contador++; 
            }

            Console.WriteLine("Los pesos son: ");
            for(int i = 0; i<weights.Count(); i++)
            {
                Console.WriteLine("Peso " + i + ": " + weights[i]);
            }
            Console.WriteLine("Numero de correciones: " + contador);
            Console.ReadLine();
            /* while (errTolerane > Err)
            {
                for(int i =0; i<rows; i++)
                {
                    output = getOutput(weights, table[i]);
                    delta = table[i][colums - 1] - output;
                    Err = 0.5 * delta * delta;
                    foreach(int j in weights)
                    {
                        
                    }
                }
            } */
        }
    }
}
