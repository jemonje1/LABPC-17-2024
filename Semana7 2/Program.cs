﻿namespace T1JM1260524 {
    //Laboraorio 1 - Javier Monje
class T1JM1260524 {
    static void Main(string[] args)
    {
   string sNombre;
   string sEdad;
   string sCarrera;
   string sCarne;

   Console.WriteLine("Ingrese su nombre");
   sNombre = Console.ReadLine();
   Console.WriteLine("Ingrese su edad");
   sEdad = Console.ReadLine();
   Console.WriteLine("Ingrese su carrera");
   sCarrera = Console.ReadLine();
   Console.WriteLine("Ingrese su carné");
   sCarne = Console.ReadLine();

Console.WriteLine("Mi segundo programa");
Console.WriteLine("Nombre: "+sNombre);
Console.WriteLine("Edad: "+sEdad);
Console.WriteLine("Carrera: "+sCarrera);
Console.WriteLine("Carné: "+sCarne);

Console.WriteLine("Soy "+sNombre+" tengo "+sEdad+" años y estudio la carrera de "+sCarrera);
Console.WriteLine("Mi número de carné es "+sCarne);

    }
}
}

