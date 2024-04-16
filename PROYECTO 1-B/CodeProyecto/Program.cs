using System.Net.Security;
/*Realizado por:
 Javier Enrique Monje Perez 1260524
 Sophia Alejandra Corea Perdomo 1185324
 Gabriel Emilio Toyom Jimenez 1051524
 */
namespace proyecto1
{
    class proyecto1
    {
        //Variables a utilizar
        static string TC = ""; 
        static string nombre = "";
        static string DPI = "";
        static string direccion = "";
        static string ntel = "";
        static double tcuenta = 2500.00;
        static int abono = 0;
        //Main ----> Inicio del programa
        static void Main(string[] args)
        {
            proyecto1 Banco = new proyecto1();
            Console.WriteLine("Bienvenido a la banca virtual del Banco Country");
            bool Salir = false;
            Console.WriteLine("Ingrese su información");
            Console.WriteLine($"Ingrese su tipo de cuenta \n a. Monetaria en Q \n b. Ahorro en Q \n c. Monetaria en $ \n d. Ahorro en $");
            char tipocuenta = Console.ReadLine().ToLower()[0];
            switch (tipocuenta)
            {
                case 'a':
                    TC = "Monetaria en Q";
                    break;
                case 'b':
                    TC = "Ahorro en Q";
                    break;
                case 'c':
                    TC = "Monetaria en $";
                    break;
                case 'd':
                    TC = "Ahorro en $";
                    break;
                default:
                    Console.WriteLine(" ");
                    break;
            }
            if (TC == "Monetaria en Q" || TC == "Ahorro en Q" || TC == "Monetaria en $" || TC == "Ahorro en $")
            {
                Console.WriteLine("");
                Console.WriteLine("Ingrese su nombre");
                nombre = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Ingrese su DPI (5 caracteres)");
                DPI = Console.ReadLine();

                int leng = DPI.Length;
                do
                {
                    Console.WriteLine("Por favor ingrese su DPI (5 caracteres)");
                    DPI = Console.ReadLine();
                    leng = DPI.Length;
                }
                while (leng < 5 || leng > 5);
                Console.WriteLine("");
                Console.WriteLine("Ingrese su dirección");
                direccion = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Ingrese su número de teléfono");
                ntel = Console.ReadLine();
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Seleccione el número de la opción que desea ejecutar");
                Console.WriteLine("1. Ingresar a cuenta");
                Console.WriteLine("2. Comprar Producto");
                Console.WriteLine("3. Vender Producto");
                Console.WriteLine("4. Abonar a cuenta");
                Console.WriteLine("5. Simular paso del tiempo");
                Console.WriteLine("6. Salir");
                string opciones = Console.ReadLine();
                //Menú de opciones
                switch (opciones)
                {
                    case "1":
                        {
                            Console.WriteLine($"Nombre: {nombre}");
                            Console.WriteLine($"Tipo Cuenta: {TC}");
                            Console.WriteLine($"DPI: {DPI}");
                            Console.WriteLine($"Número de telefono: {ntel}");
                            Console.WriteLine($"Dirección: {direccion}");
                            Console.WriteLine($"Saldo Actual: {tcuenta}");
                            break;
                        }
                    case "2":
                        {
                            Banco.CaseII();
                            break;
                        }
                    case "3":
                        {
                            Banco.CaseIII();
                            break;
                        }
                    case "4":
                        {
                            Banco.caseIV();
                            break;
                        }
                    case "5":
                        {
                            Banco.CaseV();
                            break;
                        }
                    case "6":
                        {
                            Salir = true;
                            Console.WriteLine("Gracias por utilizar nuestros servicios");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opción no valida, seleccionar otra opción");
                            break;
                        }
                }
            }
            while (!Salir);
            }
            else
            {
                Console.WriteLine("Su tipo de cuenta no existe");
            }
        }
        //Recolección de datos cliente y menú
        //Comprar Producto
        public void CaseII()
        {
            tcuenta = tcuenta - (tcuenta * 0.1);
            Console.WriteLine ($"Su saldo actual es de: {tcuenta}");
        }

        //Vender Producto
         public void CaseIII()
        {
            if( tcuenta > 500)
            {
                tcuenta = tcuenta + (tcuenta * 0.11);
                Console.WriteLine($"Su saldo actual es de: {tcuenta}");
            }
            else
            {
                double g = tcuenta/100;
                Console.WriteLine("Se recomienda no realizar la transacción debido a que el porcentaje de su saldo actual es " + g + "%");
            }
        }

        //Abonar cuenta
        public void caseIV()
        {
            Console.WriteLine("");
            if (abono < 2 && tcuenta >  500)
            {
                tcuenta = tcuenta * 2;
                abono++;
                Console.WriteLine($"Abono realizado con exito, su saldo actual es {tcuenta}");
            }
            else
            {
                Console.WriteLine("Imposible realizar el abono");
            }
        }

        //Simulador paso del tiempo
        public void CaseV()
        {
            int simulador = 0;
            int suma = 0;
            Console.WriteLine("Simular el paso del tiempo");
            Console.WriteLine($"Cúanto tiempo desea simular \n a. 30 días \n b. 15 días");
            char sim = Console.ReadLine().ToLower()[0];
            switch (sim)
            {
                case 'a':
                    simulador = (int)(double)(tcuenta * 0.02 * 30);
                    Console.WriteLine("El interés es de: " + simulador);
                    suma = (int)(simulador + tcuenta);
                    Console.WriteLine($"Su cuenta sería de {suma} a los 30 días");
                    break;

                case 'b':
                    simulador = (int)(double)(tcuenta * 0.02 * 15);
                    Console.WriteLine("El interés es de: " + simulador);
                    suma = (int)(simulador + tcuenta);
                    Console.WriteLine($"Su cuenta sería de {suma} a los 15 días");
                    break;

                default:
                    Console.WriteLine("La opción que escogió, no existe");
                    break;
            }

        }
    }
}
//wazzaaaaa, Fin del code