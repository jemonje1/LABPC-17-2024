/*
Javier Enrique Monje Pérez
Carnet: 1260524
*/
namespace CountryBank
{
    class Program
    {
        #region Método principal
        static void Main(string[] args)
        {
            #region Ingreso de datos
            Console.WriteLine("╭─────────────────────────────────────────────────╮");
            Console.WriteLine("│ Bienvenido a la banca virtual del Banco Country │");
            Console.WriteLine("╰─────────────────────────────────────────────────╯");
            Console.WriteLine("Presione ENTER para iniciar");
            Console.ReadKey();
            Console.WriteLine("Para iniciar el programa, por favor, ingrese su información");
            Console.WriteLine("╭───────────────────────────────────────────────────╮");
            Console.WriteLine("│ Ingrese el número según su tipo de cuenta:        │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 1. Monetaria en Q                                 │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 2. Ahorro en Q                                    │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 3. Monetaria en $                                 │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 4. Ahorro en $                                    │");
            Console.WriteLine("╰───────────────────────────────────────────────────╯");

            string opciones = Console.ReadLine();
            string tipoCuenta = "";
            switch (opciones)
            {
                case "1":
                    tipoCuenta = "Monetaria en Q";
                    break;
                case "2":
                    tipoCuenta = "Ahorro en Q";
                    break;
                case "3":
                    tipoCuenta = "Monetaria en $";
                    break;
                case "4":
                    tipoCuenta = "Ahorro en $";
                    break;
                default:
                    Console.WriteLine("Por favor entre al programa nuevamente y elija una cuenta válida");
                    return;
            }
            string nombre;
            do
            {
                Console.WriteLine("╭──────────────────────────────────────────────╮");
                Console.WriteLine("│ Ingrese su nombre (solamente ingrese letras) │");
                Console.WriteLine("╰──────────────────────────────────────────────╯");
                nombre = Console.ReadLine();
            }
            while (!ValidarNombre(nombre));
            string dpi;
            do
            {
                do
                {
                    Console.WriteLine("╭─────────────────────────────────────────╮");
                    Console.WriteLine("│ Por favor ingrese su DPI (5 caracteres) │");
                    Console.WriteLine("╰─────────────────────────────────────────╯");
                    dpi = Console.ReadLine();
                }
                while (!ValidarDPI(dpi));
            }
            while (dpi.Length != 5);

            Console.WriteLine("╭────────────────────────────╮");
            Console.WriteLine("│ Ingrese su dirección       │");
            Console.WriteLine("╰────────────────────────────╯");
            string direccion = Console.ReadLine();
            string numeroTelefono;
            do
            {
                Console.WriteLine("╭───────────────────────────────╮");
                Console.WriteLine("│ Ingrese su número de teléfono │");
                Console.WriteLine("╰───────────────────────────────╯");
                numeroTelefono = Console.ReadLine();
            }
            while (!ValidarNumeroTelefono(numeroTelefono));
            double saldoInicial = 2500.00;
            #endregion

            CuentaBancaria cuenta = new CuentaBancaria(tipoCuenta, nombre, dpi, direccion, numeroTelefono, saldoInicial);
            #region menú de opciones
            bool salir = false;
            do
            {
                Console.WriteLine("╭───────────────────────────────────────────────────╮");
                Console.WriteLine("│                  MENÚ PRINCIPAL                   │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ Seleccione el número de la opción que desea       │");
                Console.WriteLine("│ ejecutar:                                         │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 1. Ingresar a cuenta                              │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 2. Comprar Producto                               │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 3. Vender Producto                                │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 4. Abonar a cuenta                                │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 5. Simular paso del tiempo                        │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 6. Mantenimiento de cuentas                       │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 7. Transferencias                                 │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 8. Pago de servicios                              │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 9. Mostrar historial                              │");
                Console.WriteLine("├───────────────────────────────────────────────────┤");
                Console.WriteLine("│ 10. Cerrrar programa                              │");
                Console.WriteLine("╰───────────────────────────────────────────────────╯");

                opciones = Console.ReadLine();
                switch (opciones)
                {
                    case "1":
                        cuenta.MostrarInformacion();
                        break;
                    case "2":
                        cuenta.RealizarCompra();
                        break;
                    case "3":
                        cuenta.RealizarVenta();
                        break;
                    case "4":
                        cuenta.RealizarAbono();
                        break;
                    case "5":
                        string tiempo;
                        Console.WriteLine("Para iniciar, ingrese el tiempo de la simulación (solamente números)");
                        do
                        {
                            tiempo = Console.ReadLine();
                            int tiempoSimulacion = int.Parse(tiempo);
                            cuenta.SimularTiempo(tiempoSimulacion);
                        }
                        while (ValidarTiempo(tiempo));
                        break;
                    case "6":
                        cuenta.TercerasCuentas();
                        break;
                    case "7":
                        cuenta.TransferirACuentaTercero();
                        break;
                    case "8":
                        cuenta.PagoServicio();
                        break;
                    case "9":
                        cuenta.RegistroHistorial();
                        break;
                    case "10":
                        Console.WriteLine("Gracias por usar el servicio");
                        Console.WriteLine("Cerrando sesión . . .");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, seleccionar otra opción");
                        break;
                }
                #endregion
            }
            while (!salir);
        }
        #endregion
        #region validaciones
        static bool ValidarNombre(string nombre)
        {
            // Itera sobre cada carácter del nombre
            foreach (char c in nombre)
            {
                // Verifica si alguno de los caracteres ingresados no sea un caracter
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Error encontrado: El nombre solo puede contener letras.");
                    return false; // Nombre inválido
                }
            }

            return true; // Nombre válido
        }
        static bool ValidarDPI(string numeros)
        {
            // Convertir la cadena en números
            if (int.TryParse(numeros, out _))
            {
                return true; // Número válido si el intento sale correctamente
            }
            else
            {
                Console.WriteLine("Error: El DPI solo puede contener números.");
                return false; // Número inválido con error si la cadena contiene un caracter no numérico
            }
        }
        static bool ValidarNumeroTelefono(string numero)
        {
            // Esta validación usa la misma que la del DPI
            // Intenta convertir la cadena en un número entero
            if (int.TryParse(numero, out _))
            {
                return true; // Número válido
            }
            else
            {
                Console.WriteLine("Error: El número de teléfono solo puede contener números.");
                return false; // Número inválido
            }
        }
        static bool ValidarTiempo(string cantidadTiempo)
        {
            if (int.TryParse(cantidadTiempo, out _))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error: Ingrse solamente un número");
                return false;
            }
        }
        #endregion
    }
}