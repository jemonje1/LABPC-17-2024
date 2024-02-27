using System.Timers;

namespace T2JM1260524{
class T2JM2160524{
    static void Main (string [] args)
    {
        //Laboratorio 2 - Problema 1//
        double vf = 0;
        double vo = 0;
        double a = 0;
        double t = 0;
        Console.WriteLine("Calcule su velocidad Final");
        Console.WriteLine("Ingrese Velocidad Inicial");
        vo = Double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese Aceleración");
        a = Double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese Tiempo");
        t = Double.Parse(Console.ReadLine());
        vf = vo+a*t;
        Console.WriteLine("La velocidad final es "+vf);
        Console.ReadKey();
        //Laboratorio 2 - Problema 2//
        Console.WriteLine("Precione ENTER para iniciar el Problema 2");
        Console.ReadKey();
        double ingresa = 0;
        Console.WriteLine("Ingrese un número menor a 1000");
        ingresa = Double.Parse(Console.ReadLine());
        if (ingresa >=1000 ){
            Console.WriteLine("no es válido");
        }
        else{
            int monecentavo =(int)(ingresa*100);
            int b100= monecentavo/10000;
            monecentavo %= 10000;
            int b50 = monecentavo/5000;
            monecentavo %= 5000;
            int b20 = monecentavo/2000;
            monecentavo %= 2000;
            int b10 = monecentavo/1000;
            monecentavo %= 1000;
            int b5 = monecentavo/500;
            monecentavo %= 500;
            int mon1 = monecentavo/100;
            Console.WriteLine("Javier Monje 1260524");
            Console.WriteLine("El dinero necesario es:");
            Console.WriteLine (b100+" billetes de 100");
            Console.WriteLine (b50+" billetes de 50");
            Console.WriteLine (b20+" billetes de 20");
            Console.WriteLine (b10+" billetes de 10");
            Console.WriteLine (b5+" billetes de 5");
            Console.WriteLine (mon1+" monedas de 1");
        }
        
    }
}
}
