namespace CountryBank
{
    class Program
    {
        static string tipoCuenta = ""; 
        static string nombreCuentahabitante = "";
        static string DPI = "";
        static string direccion = "";
        static string numeroTelefono = "";
        static double saldoActualCuenta = 2500.00;
        static int abono = 0;
        static int tiempoSimulador = 0;
        static string opciones = "";
        static int transaccion = 0;
        static string servicioAgua = "Servicio de Agua";
        static string servicioTelefono = "Servicio de Teléfono";
        static string servicioElectrico="Servicio Eléctrico";
        static bool salidaOtrosMenus = false;
        static int NumeroArray = 0;
        static void Main(string[] args)
        {
            Program Banco = new Program();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Bienvenido a la banca virtual del Banco Country");
            Console.WriteLine("------------------------------------------------");
            bool Salir = false;
            Console.WriteLine("Ingrese su información");
            Console.WriteLine($"Ingrese su tipo de cuenta \n a. Monetaria en Q \n b. Ahorro en Q \n c. Monetaria en $ \n d. Ahorro en $");
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
                    Console.WriteLine("Porfavor elija una cuenta");
                    break;
            }
            if (tipoCuenta == "Monetaria en Q" || tipoCuenta == "Ahorro en Q" || tipoCuenta == "Monetaria en $" || tipoCuenta == "Ahorro en $")
            {
                Console.WriteLine("");
                Console.WriteLine("Ingrese su nombre");
                nombreCuentahabitante = Console.ReadLine();
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
                numeroTelefono = Console.ReadLine();
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("Seleccione el número de la opción que desea ejecutar");
                Console.WriteLine("1. Ingresar a cuenta");
                Console.WriteLine("2. Comprar Producto");
                Console.WriteLine("3. Vender Producto");
                Console.WriteLine("4. Abonar a cuenta");
                Console.WriteLine("5. Simular paso del tiempo");
                Console.WriteLine("6. Cuentas de terceros");
                switch (opciones)
                {
                    case "1":
                        {
                            Console.WriteLine($"Nombre: {nombreCuentahabitante}");
                            Console.WriteLine($"Tipo Cuenta: {tipoCuenta}");
                            Console.WriteLine($"DPI: {DPI}");
                            Console.WriteLine($"Número de telefono: {numeroTelefono}");
                            Console.WriteLine($"Dirección: {direccion}");
                            Console.WriteLine($"Saldo Actual: {saldoActualCuenta}");
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
                            Banco.CaseVI();
                            break;
                        }
                    case "8":
                        {
                            Banco.CaseVIII();
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
        public void CaseII()
        {
            saldoActualCuenta = saldoActualCuenta - (saldoActualCuenta * 0.1);
            Console.WriteLine ($"Su saldo actual es de: {saldoActualCuenta}");
        }
         public void CaseIII()
        {
            if( saldoActualCuenta > 500)
            {
                saldoActualCuenta = saldoActualCuenta + (saldoActualCuenta * 0.11);
                Console.WriteLine($"Su saldo actual es de: {saldoActualCuenta}");
            }
            else
            {
                double g = saldoActualCuenta/100;
                Console.WriteLine("Se recomienda no realizar la transacción debido a que el porcentaje de su saldo actual es " + g + "%");
            }
        }
        public void caseIV()
        {
            Console.WriteLine("");
            if (abono < 2 && saldoActualCuenta >  500)
            {
                saldoActualCuenta = saldoActualCuenta * 2;
                abono++;
                Console.WriteLine($"Abono realizado con exito, su saldo actual es {saldoActualCuenta}");
            }
            else
            {
                Console.WriteLine("Imposible realizar el abono");
            }
        }
        public void CaseV()
        {
            int simulador = 0;
            int suma = 0;
            Console.WriteLine("Simular el paso del tiempo");
            Console.WriteLine($"¿Cómo desea simular el tiempo? \n 1. En meses \n 2. En días");
            switch (opciones)
            {
                case "1":
                    Console.WriteLine("Ingrese su tiempo de simulación en meses");
                    tiempoSimulador = int.Parse(Console.ReadLine());
                    simulador = (int)(double)(saldoActualCuenta * 0.02 * tiempoSimulador)/12;
                    Console.WriteLine("El interés es de: " + simulador);
                    suma = (int)(simulador + saldoActualCuenta);
                    Console.WriteLine($"Su cuenta sería de {suma} con los meses ingresados");
                    break;

                case "2":
                    simulador = (int)(double)(saldoActualCuenta * 0.02 * tiempoSimulador)/360;
                    Console.WriteLine("El interés es de: " + simulador);
                    suma = (int)(simulador + saldoActualCuenta);
                    Console.WriteLine($"Su cuenta sería de {suma} con los días ingresados");
                    break;

                default:
                    Console.WriteLine("La opción que escogió, no existe");
                    break;
            }
        }
        public void CaseVI()
        {
            Console.WriteLine($"Bienvenido al menú de mantenimiento de cuentas de terceros");
            Console.WriteLine($"Indique la opción que desea realizar \n 1. Crear nueva cuenta tercera \n 2. Eliminar cuenta \n 3. Modificar cuenta");
            switch(opciones)
            {
                case "1":
                break;
                case "2":
                break;
                case "3":
                break;
                default:
                break;
            }
        }
        public void CaseVII()
        {
            Console.WriteLine("Transacciones");
        }
        public void CaseVIII()
        {
            Console.WriteLine("Pago de servicios");
            Console.WriteLine("Indique a cuál servicio desea pagar \n 1. Servicio agua \n 2. Servicio eléctrico \n 3. Servicio de teléfono");
            switch (opciones)
            {
                case "1":
                Console.WriteLine($"Ingresó al {servicioAgua}");
                Console.WriteLine("Ingrese el monto que quiera pagar");
                transaccion = int.Parse(Console.ReadLine());
                saldoActualCuenta = saldoActualCuenta - transaccion;
                Console.WriteLine($"Realizó una transacción de {transaccion}");
                Console.WriteLine($"Su saldo actual es de {saldoActualCuenta}");
                break;
                case "2":
                Console.WriteLine($"Ingresó al {servicioElectrico}");
                Console.WriteLine("Ingrese el monto que quiera pagar");
                transaccion = int.Parse(Console.ReadLine());
                saldoActualCuenta = saldoActualCuenta - transaccion;
                Console.WriteLine($"Realizó una transacción de {transaccion}");
                Console.WriteLine($"Su saldo actual es de {saldoActualCuenta}");
                break;
                case "3":
                Console.WriteLine($"Ingresó al {servicioTelefono}");
                Console.WriteLine("Ingrese el monto que quiera pagar");
                transaccion = int.Parse(Console.ReadLine());
                saldoActualCuenta = saldoActualCuenta - transaccion;
                Console.WriteLine($"Realizó una transacción de {transaccion}");
                Console.WriteLine($"Su saldo actual es de {saldoActualCuenta}");
                break;
                default:
                Console.WriteLine("La opción que ingresó no es válida, intente nuevamente");
                break;
            }
        }
    }
}