using System.ComponentModel;
using System.Diagnostics;

namespace CountryBank
{
    class CuentaBancaria
    {
        #region propiedades
        public string TipoCuenta { get; set; }
        public string Nombre { get; set; }
        public string DPI { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }
        public double Saldo { get; set; }
        //instancias
        public Terceros terceros { get; set; } = new Terceros();
        public RegistroTransacciones registro = new RegistroTransacciones();
        #endregion
        #region constructor
        public CuentaBancaria(string tipoCuenta, string nombre, string dpi, string direccion, string numeroTelefono, double saldoInicial)
        {
            TipoCuenta = tipoCuenta;
            Nombre = nombre;
            DPI = dpi;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            Saldo = saldoInicial;
        }
        #endregion
        #region Métodos para el funcionamiento del banco
        //Método para mostrar la información de cuenta
        #region De Info hasta simulador
        public void MostrarInformacion()
        {
            Console.WriteLine("──────────────────────────────────────────────────");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Tipo Cuenta: {TipoCuenta}");
            Console.WriteLine($"DPI: {DPI}");
            Console.WriteLine($"Número de teléfono: {NumeroTelefono}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Saldo Actual: {Saldo.ToString("0.00")}");
            Console.WriteLine("──────────────────────────────────────────────────");
        }
        //Método para Comprar Producto Financiero
        public void RealizarCompra()
        {
            double compra = Saldo * 0.1;
            if (compra < Saldo)
            {
                Saldo -= Saldo * 0.1;
                Console.WriteLine("----------COMPRA DE PRODUCTO FINANCIERO----------");
                Console.WriteLine("╭───────────────────────────────────────────────╮");
                Console.WriteLine($"Su saldo actual es de: {Saldo.ToString("0.00")}");
                Console.WriteLine("╰───────────────────────────────────────────────╯");
                //Apartados con registroTransaccion, para agregar al método AgregarTransaccion de la clase RegistroTransacciones para agregar elementos al historial
                string registroTransaccion = $"Fecha de transacción: {DateTime.Now}, Pago de producto financiero con un débito de {compra.ToString("0.00")}";
                registro.AgregarTransaccion(registroTransaccion);
            }
            else
            {
                Console.WriteLine("No se puede comprar debido a la falta de saldo");
            }
        }
        //Método para vender producto financiero
        public void RealizarVenta()
        {
            //validación
            if (Saldo > 500)
            {
                double venta = Saldo * 0.11;
                Saldo += Saldo * 0.11;
                Console.WriteLine("----------VENTA DE PRODUCTO FINANCIERO----------");
                Console.WriteLine("╭───────────────────────────────────────────────╮");
                Console.WriteLine($"Su saldo actual es de: {Saldo.ToString("0.00")}");
                Console.WriteLine("╰───────────────────────────────────────────────╯");
                string registroTransaccion = $"Fecha de transacción: {DateTime.Now}, Venta de producto financiero con un crédito de {venta.ToString("0.00")}";
                registro.AgregarTransaccion(registroTransaccion);
            }
            else
            {
                double porcentaje = Saldo / 100;
                Console.WriteLine("Se recomienda no realizar la transacción debido a que el porcentaje de su saldo actual es " + porcentaje.ToString("0.00") + "%");
            }
        }
        //Método para hacer abonos
        public void RealizarAbono()
        {
            //validación
            if (Saldo > 500)
            {
                double abono = Saldo * 2;
                Saldo *= 2;
                Console.WriteLine("----------------------REALIZAR ABONOS-----------------------");
                Console.WriteLine("╭───────────────────────────────────────────────────────────╮");
                Console.WriteLine($"Abono exitoso, su saldo actual es de: {Saldo.ToString("0.00")}");
                Console.WriteLine("╰───────────────────────────────────────────────────────────╯");
                string registroTransaccion = $"Fecha de transacción: {DateTime.Now}, Pago de producto financiero con un débito de {abono.ToString("0.00")}";
                registro.AgregarTransaccion(registroTransaccion);
            }
            else
            {
                Console.WriteLine("No se puede realizar el abono, debido a que el saldo es menor a 500");
            }
        }
        //método para el simulador
        public void SimularTiempo(int tiempoSimulador)
        {
            Console.WriteLine("----------------SIMULADOR DE INTERÉS----------------");
            Console.WriteLine("╭───────────────────────────────────────────────────╮");
            Console.WriteLine("│ ¿Cómo desea ingresar su tiempo?                   │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 1. Meses                                          │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 2. Días                                           │");
            Console.WriteLine("╰───────────────────────────────────────────────────╯");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    double interes = Saldo * 0.02 * tiempoSimulador / 12;
                    double suma = Saldo + interes;
                    Console.WriteLine($"El interés es de: {interes.ToString("0.00")}");
                    Console.WriteLine($"Su cuenta sería de {suma.ToString("0.00")} con los meses ingresados");
                    break;
                case "2":
                    interes = Saldo * 0.02 * tiempoSimulador / 360;
                    suma = Saldo + interes;
                    Console.WriteLine($"El interés es de: {interes.ToString("0.00")}");
                    Console.WriteLine($"Su cuenta sería de {suma.ToString("0.00")} con los meses ingresados");
                    break;
                default:
                    Console.WriteLine("La opción que elijió no existe");
                    break;
            }
        }
        #endregion
        #region De servicios hasta Transferencias
        //método para pagar servicios
        public void PagoServicio()
        {
            Console.WriteLine("-----------------PAGO DE SERVICIOS------------------");
            Console.WriteLine("╭───────────────────────────────────────────────────╮");
            Console.WriteLine("│ Indique a cuál servicio desea pagar:              │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 1. Servicio de agua                               │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 2. Servicio eléctrico                             │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 3. Servicio de teléfono                           │");
            Console.WriteLine("╰───────────────────────────────────────────────────╯");
            string opciones = Console.ReadLine();
            string servicio = "";
            string cantidadMonto;
            double monto = 0;
            switch (opciones)
            {
                case "1":
                    servicio = "Servicio de Agua";
                    break;
                case "2":
                    servicio = "Servicio Eléctrico";
                    break;
                case "3":
                    servicio = "Servicio de Teléfono";
                    break;
                default:
                    Console.WriteLine("La opción que ingresó no es válida, intente nuevamente");
                    break;
            }
            Console.WriteLine("");
            do
            {
                Console.WriteLine($"Ingrese el monto que quiere pagar para {servicio}");
                cantidadMonto = (Console.ReadLine());
                monto = double.Parse(cantidadMonto);
                //llamar a método PagarServicio
                PagarServicio(servicio, monto);
                Console.WriteLine($"Transacción realizada, su saldo actual es de {Saldo}");
                string registroTransaccion = $"Fecha de transacción: {DateTime.Now}, Pago de {servicio} con un débito de {monto.ToString("0.00")}";
                registro.AgregarTransaccion(registroTransaccion);
            }
            while (!ValidarPagoServicio(cantidadMonto));
        }
        //Método para realizar el pago al servicio y guarde la variable de servicio
        public void PagarServicio(string servicio, double monto)
        {
            Console.WriteLine($"Ingresó al {servicio}");
            Saldo -= monto;
            Console.WriteLine($"Realizó una transacción de {monto.ToString("0.00")}");
            Console.WriteLine($"Su saldo actual es de {Saldo.ToString("0.00")}");
        }
        //Método para llamar historial
        public void RegistroHistorial()
        {
            //Llamada al método en la clase RegistroTransacciones
            registro.MostrarRegistro();
        }
        //Método para mantenimiento de cuentas
        #region Cuentas de Terceros
        public void TercerasCuentas()
        {
            Console.WriteLine("--------MANTENIMIENTO DE CUENTAS DE TERCEROS--------");
            Console.WriteLine("╭───────────────────────────────────────────────────╮"); ;
            Console.WriteLine("│ Seleccione la opción que desea realizar:          │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 1. Crear cuenta de terceros                       │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 2. Eliminar cuenta de terceros                    │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 3. Actualizar datos de una cuenta                 │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 4. Mostrar Cuentas                                │");
            Console.WriteLine("╰───────────────────────────────────────────────────╯");

            string opciones = Console.ReadLine();
            switch (opciones)
            {
                case "1":
                    CreacionCuentaTercero();
                    break;
                case "2":
                    EliminarCuentaTercero();
                    break;
                case "3":
                    EditarCuentaTercero();
                    break;
                case "4":
                    terceros.MostrarCuentasTerceros();
                    break;
                default:
                    Console.WriteLine("El valor ingresado no es aceptado, entre nuevamente");
                    break;
            }
        }
        //Método para crear cuentas
        public void CreacionCuentaTercero()
        {
            //variables string para validación de datos
            string nombreTercero;
            string numeroCuenta;
            string transferencia;
            int Identificador = terceros.IDdeCuenta + 1;
            string ID = Identificador.ToString();
            int i = 0;
            //arreglo encargado de almacenar los datos
            string[] cuentas = new string[5];
            cuentas[i] = ID;
            i++;
            //Formulario de datos, con validaciones
            do
            {
                Console.WriteLine("Ingrese el nombre del cuentahabitante");
                nombreTercero = Console.ReadLine();
                cuentas[i] = nombreTercero;
            }
            while (!ValidarNombreTercero(nombreTercero));
            i++;
            Console.WriteLine("Ingrese el nombre del banco");
            cuentas[i] = Console.ReadLine();
            i++;
            do
            {
                Console.WriteLine("Ingrese el número de cuenta del cuentahabitante");
                numeroCuenta = Console.ReadLine();
                cuentas[i] = numeroCuenta;
            }
            while (!ValidarNumeroCuentaTercero(numeroCuenta));
            i++;
            do
            {
                Console.WriteLine("Ingrese la primer cantidad a transferir");
                transferencia = Console.ReadLine();
                cuentas[i] = transferencia.ToString();
                double operacionTransferencia = double.Parse(transferencia);
                Saldo -= operacionTransferencia;
                string registroTransaccion = $"Creación de cuenta tercera, Fecha de creación: {DateTime.Now}, con un débito de {operacionTransferencia.ToString("0.00")}";
                registro.AgregarTransaccion(registroTransaccion);
                string[] cuentaTercera = cuentas;
                terceros.agregarCuenta(cuentaTercera);
            }
            while (!ValidarTransaccion(transferencia));
        }
        //método que elimina cuentas de terceros
        public void EliminarCuentaTercero()
        {
            int ID;
            Console.WriteLine("Ingrese el ID de la cuenta que desee eliminar");
            string IDEliminar = Console.ReadLine();
            ID = int.Parse(IDEliminar) - 1;
            //El -1 es para que busque correctamente la posición del arreglo en la lista
            if (ID >= 0 && ID < terceros.CantidadCuentas())
            {
                terceros.EliminarCuenta(ID);
                Console.WriteLine("La cuenta ha sido eliminada exitosamente.");
                string registroTransaccion = $"Fecha: {DateTime.Now}, Cuenta de ID: {ID + 1} eliminada";
                //+1 agregado para mostrar el ID correcto
                registro.AgregarTransaccion(registroTransaccion);
            }
            else
            {
                Console.WriteLine("ID de cuenta inválido.");
            }
        }
        //Método para editar cuentas
        public void EditarCuentaTercero()
        {
            Console.WriteLine("Ingrese el ID de la cuenta que desea editar:");
            int id = int.Parse(Console.ReadLine()) - 1;
            //ID con validación
            if (id >= 0 && id < terceros.CantidadCuentas())
            {
                string nuevoNombre;
                string nuevoNumeroCuenta;
                string nuevaCantidadTransferencia;
                //solicitud de datos para el arreglo según su ID con validaciones
                string[] cuenta = terceros.ObtenerCuenta(id);
                do
                {
                    Console.WriteLine("Ingrese el nuevo nombre del cuentahabitante:");
                    nuevoNombre = Console.ReadLine();
                    cuenta[1] = nuevoNombre;
                }
                while (!ValidarNombreTercero(nuevoNombre));
                Console.WriteLine("Ingrese el nuevo nombre del banco:");
                cuenta[2] = Console.ReadLine();
                do
                {
                    Console.WriteLine("Ingrese el nuevo número de cuenta del cuentahabitante:");
                    nuevoNumeroCuenta = Console.ReadLine();
                    cuenta[3] = nuevoNumeroCuenta;
                }
                while (!ValidarNumeroCuentaTercero(nuevoNumeroCuenta));
                Console.WriteLine("Ingrese la nueva cantidad a transferir:");
                do
                {
                    nuevaCantidadTransferencia = Console.ReadLine();
                    double nuevaTransferencia = double.Parse(nuevaCantidadTransferencia);
                    cuenta[4] = nuevaTransferencia.ToString();
                    terceros.EditarCuenta(id, cuenta);
                    Console.WriteLine("La cuenta ha sido editada exitosamente.");
                    string registroTransaccion = $"Fecha: {DateTime.Now}, Cuenta de ID: {id + 1} actualizada, debito de {nuevaTransferencia.ToString("0.00")}";
                    registro.AgregarTransaccion(registroTransaccion);
                }
                while (!ValidarTransaccion(nuevaCantidadTransferencia));
            }
            else
            {
                Console.WriteLine("ID de cuenta inválido.");
            }
        }
        #endregion
        //Método para trasferir a las cuentas
        public void TransferirACuentaTercero()
        {
            //prueba de ID
            Console.WriteLine("--------TRANSFERENCIAS A CUENTAS DE TERCEROS---------");
            Console.WriteLine("╭───────────────────────────────────────────────────╮"); ;
            Console.WriteLine("│ Seleccione la opción que desea realizar:          │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 1. Transferencia en Q.                            │");
            Console.WriteLine("├───────────────────────────────────────────────────┤");
            Console.WriteLine("│ 2. Transferencia en $                             │");
            Console.WriteLine("╰───────────────────────────────────────────────────╯");
            string opciones = Console.ReadLine();
            switch (opciones)
            {
                case "1":
                    CasoTransferenciaQ();
                    break;
                case "2":
                    CasoTransferenciaDolar();
                    break;
                default:
                    Console.WriteLine("La opción que eligió no se puede hacer");
                    break;
            }
        }
        public void CasoTransferenciaQ()
        {
            //según el tipo de cuenta elegida al inicio, el cómo se hará la transferencia
            string identificadorTransferencia;
            if (TipoCuenta == "Monetaria en Q" || TipoCuenta == "Ahorro en Q")
            {
                do
                {
                    Console.WriteLine("Ingrese el ID de la cuenta a la que desea transferir:");
                    identificadorTransferencia = Console.ReadLine();
                    int id = int.Parse(identificadorTransferencia) - 1;
                    if (id >= 0 && id < terceros.CantidadCuentas())
                    {
                        Console.WriteLine("Ingrese la cantidad a transferir:");
                        double cantidad = double.Parse(Console.ReadLine());

                        if (Saldo >= cantidad)
                        {
                            //llamada al array en la lista
                            string[] cuenta = terceros.ObtenerCuenta(id);
                            double saldoTercero = double.Parse(cuenta[4]);
                            saldoTercero += cantidad;
                            cuenta[4] = saldoTercero.ToString();
                            Saldo -= cantidad;

                            terceros.EditarCuenta(id, cuenta);
                            Console.WriteLine($"Se ha transferido en Q. {cantidad.ToString("0.00")} a la cuenta de tercero con ID {id + 1}.");
                            //Este apartado guarda en el historial
                            string registroTransaccion = $"Fecha: {DateTime.Now}, Transferencia a cuenta tercera, ID: {id} Monto Q.: {cantidad.ToString("0.00")}";
                            registro.AgregarTransaccion(registroTransaccion);
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de cuenta inválido.");
                    }
                }
                while (!ValidarNumeroCuentaTercero(identificadorTransferencia));
            }
            else
            {
                do
                {
                    Console.WriteLine("Ingrese el ID de la cuenta a la que desea transferir:");
                    identificadorTransferencia = Console.ReadLine();
                    int id = int.Parse(identificadorTransferencia) - 1;
                    if (id >= 0 && id < terceros.CantidadCuentas())
                    {
                        Console.WriteLine("Ingrese la cantidad a transferir en quetzales, se hará la conversión a dólares:");
                        double cantidad = double.Parse(Console.ReadLine());
                        //la variable quetzal, realiza la conversión del dinero
                        double quetzal = cantidad/0.13;
                        if (Saldo >= cantidad)
                        {
                            //llamado al array de la cuenta en la lista
                            string[] cuenta = terceros.ObtenerCuenta(id);
                            double saldoTercero = double.Parse(cuenta[4]);
                            saldoTercero += quetzal;
                            cuenta[4] = saldoTercero.ToString();
                            Saldo -= cantidad;

                            terceros.EditarCuenta(id, cuenta);
                            Console.WriteLine($"Se ha transferido en $ {quetzal.ToString("0.00")} a la cuenta de tercero con ID {id + 1}.");
                            string registroTransaccion = $"Fecha: {DateTime.Now}, Transferencia a cuenta tercera, ID: {id} Monto $.: {quetzal.ToString("0.00")}";
                            registro.AgregarTransaccion(registroTransaccion);
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de cuenta inválido.");
                    }
                }
                while (!ValidarNumeroCuentaTercero(identificadorTransferencia));
            }
        }
        public void CasoTransferenciaDolar()
        {
            string identificadorTransferencia;
            if (TipoCuenta == "Monetaria en $" || TipoCuenta == "Ahorro en $")
            {
                do
                {
                    Console.WriteLine("Ingrese el ID de la cuenta a la que desea transferir:");
                    identificadorTransferencia = Console.ReadLine();
                    int id = int.Parse(identificadorTransferencia) - 1;
                    if (id >= 0 && id < terceros.CantidadCuentas())
                    {
                        Console.WriteLine("Ingrese la cantidad a transferir:");
                        double cantidad = double.Parse(Console.ReadLine());

                        if (Saldo >= cantidad)
                        {
                            string[] cuenta = terceros.ObtenerCuenta(id);
                            double saldoTercero = double.Parse(cuenta[4]);
                            saldoTercero += cantidad;
                            cuenta[4] = saldoTercero.ToString();
                            Saldo -= cantidad;

                            terceros.EditarCuenta(id, cuenta);
                            Console.WriteLine($"Se ha transferido en $. {cantidad.ToString("0.00")} a la cuenta de tercero con ID {id + 1}.");
                            string registroTransaccion = $"Fecha: {DateTime.Now}, Transferencia a cuenta tercera, ID: {id} Monto $.: {cantidad.ToString("0.00")}";
                            registro.AgregarTransaccion(registroTransaccion);
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de cuenta inválido.");
                    }
                }
                while (!ValidarNumeroCuentaTercero(identificadorTransferencia));
            }
            else
            {
                do
                {
                    Console.WriteLine("Ingrese el ID de la cuenta a la que desea transferir:");
                    identificadorTransferencia = Console.ReadLine();
                    int id = int.Parse(identificadorTransferencia) - 1;
                    if (id >= 0 && id < terceros.CantidadCuentas())
                    {
                        Console.WriteLine("Ingrese la cantidad a transferir en dolares, se hará la conversión a quetzales:");
                        double cantidad = double.Parse(Console.ReadLine());
                        //La variable Dolar tiene la misma funcionalidad del quetzal
                        double Dolar = cantidad*7.5;
                        if (Saldo >= cantidad)
                        {
                            string[] cuenta = terceros.ObtenerCuenta(id);
                            double saldoTercero = double.Parse(cuenta[4]);
                            saldoTercero += Dolar;
                            cuenta[4] = saldoTercero.ToString();
                            //La razón de las conversiones es para restar al saldo la cantidad registrada en vez de la que se realiza en la conversión
                            Saldo -= cantidad;

                            terceros.EditarCuenta(id, cuenta);
                            Console.WriteLine($"Se ha transferido en Q. {Dolar.ToString("0.00")} a la cuenta de tercero con ID {id + 1}.");
                            string registroTransaccion = $"Fecha: {DateTime.Now}, Transferencia a cuenta tercera, ID: {id} Monto Q.: {cantidad.ToString("0.00")}";
                            registro.AgregarTransaccion(registroTransaccion);
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de cuenta inválido.");
                    }
                }
                while (!ValidarNumeroCuentaTercero(identificadorTransferencia));
            }
        }
        #endregion
        #endregion
        #region validaciones
        static bool ValidarNombreTercero(string nombreTercero)
        {
            //utilizando la misma lógica de las validaciones al ingresar datos
            //Itera sobre cada carácter del nombre del tercero
            foreach (char c in nombreTercero)
            {
                //Verifica si alguno de los caracteres ingresados no sea un caracter
                if (!char.IsLetter(c))
                {
                    Console.WriteLine("Error encontrado: El nombre solo puede contener letras.");
                    return false; //Nombre inválido
                }
            }

            return true; // Nombre válido
        }
        static bool ValidarNumeroCuentaTercero(string numeros)
        {
            //Utiliza la m misma lógica
            //Convertir la cadena en números 
            if (int.TryParse(numeros, out _))
            {
                return true; //Número válido si el intento sale correctamente
            }
            else
            {
                Console.WriteLine("Error: El número de cuenta del tercero solo puede contener números.");
                return false; //Número inválido con error si la cadena contiene un caracter no numérico
            }
        }
        static bool ValidarTransaccion(string numero)
        {
            // Esta validación usa la misma que la del DPI
            // Intenta convertir la cadena en un número entero
            if (double.TryParse(numero, out _))
            {
                return true; // Número válido
            }
            else
            {
                Console.WriteLine("Error: La transacción solo puede hacerse, ingresando números.");
                return false; // Número inválido
            }
        }
        //validaciones para transacciones
        static bool ValidarPagoServicio(string PagoServicio)
        {
            if (double.TryParse(PagoServicio, out _))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error: No puede realizar transaccion ingresando caracteres no numéricos");
                return false;
            }
        }
        //validación según saldo
        #endregion
    }
}