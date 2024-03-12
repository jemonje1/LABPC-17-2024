/*
Javier Enrique Monje Pérez
126024
Proyecto de Fibonacci
*/
using System;
using System.ComponentModel;
namespace L4JEMP1260524
{
    class L4JEMP1260524
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("Ingrese un número");
            n = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 1;
            int c = 0;
            int i = 2;
            string resultado = " ";
            if (n>0)
            {
                resultado +=a;
                if (n>1)
                {
                    resultado += ","+b;
                    while (i<n)
                    {
                        c = a + b;
                        resultado += ","+c;
                        a = b;
                        b = c;
                        i = i + 1;
                    }
                    Console.WriteLine($"El resultado es {resultado}");
                }

            }
            else
            {
                Console.WriteLine($"El resultado es {resultado}");
            return;
            }
        }
    }
}