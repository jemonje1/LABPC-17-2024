using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main(string[] args)
    {
        Nombres();
        Notas();
        Menu();
    }

    static string[] nombres = new string[10];
    public static void Nombres()
    {
        for (int i = 0; i < nombres.Length; i++)
        {
            System.Console.WriteLine("\n______________________");
            System.Console.WriteLine("Ingrese un nombre");
            string name = Console.ReadLine();
            nombres[i] = name;
        }
    }

    static int[] notas = new int[10];
    public static void Notas()
    {
        for (int i = 0; i < notas.Length; i++)
        {
            bool validacion = false;
            do
            {
                try
                {
                    System.Console.WriteLine("\n______________________");
                    System.Console.WriteLine($"Ingrese nota {i}");
                    int nota = Int32.Parse(Console.ReadLine());
                    notas[i] = nota;
                    validacion = false;
                }
                catch (FormatException e)
                {
                    System.Console.WriteLine("Error! dato ingresado no valido\nINTENTELO DE NUEVO");
                    System.Console.WriteLine(e.Message);
                    validacion = true;
                }
            } while (validacion);
        }
    }

    public static void Menu()
    {
        bool validacion = true;
        do
        {
            System.Console.WriteLine("\n___________MENU___________");
            System.Console.WriteLine("1.Mostrar nombre y nota de alumnos que aprobaron el curso.\n2.Mostrar nombre y nota de alumnos que No aprobaron el curso.\n3.Mostrar el promedio de notas del grupo.\n4.Salir del programa");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    {
                        System.Console.WriteLine("\n--------------------");
                        System.Console.WriteLine("Las notas que aprobaron son:");
                        Ganadores();
                        System.Console.WriteLine("--------------------");
                        break;
                    }
                case "2":
                    {
                        System.Console.WriteLine("\n--------------------");
                        System.Console.WriteLine("Las notas que aprobaron son:");
                        Perdedores();
                        System.Console.WriteLine("--------------------");
                        break;
                    }
                case "3":
                    {
                        System.Console.WriteLine("\n--------------------");
                        System.Console.WriteLine("El promedio es " + Promedio());
                        System.Console.WriteLine("--------------------");
                        break;
                    }
                case "4":
                    {
                        validacion = false;
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Opcion no valida intentelo de nuevo");
                        break;
                    }
            }
        } while (validacion);
    }

    public static int Promedio()
    {
        int promedio = 0;
        for (int i = 0; i < notas.Length; i++)
        {
            promedio = promedio + notas[i];
        }
        promedio = promedio / notas.Length;
        return promedio;
    }

    public static void Ganadores(){
        for (int i = 0; i < notas.Length; i++)
        {
            if (notas[i] >= 65)
            {
                System.Console.WriteLine(notas[i]);
            }
        }
    }
    public static void Perdedores(){
        for (int i = 0; i < notas.Length; i++)
        {
            if (notas[i] < 65)
            {
                System.Console.WriteLine(notas[i]);
            }
        }
    }
}