namespace CountryBank
{
    class Terceros
    {
        #region ListaTerceros
        //lista para ir guardando las cuentas nuevas creadas
        List<string[]> cuentaTerceros;
        public Terceros()
        {
            cuentaTerceros = new List<string[]>();
        }
        #endregion OPeraciones de Cuentas
        #region 
        public void agregarCuenta(string[] cuentaTercera)
        {
            cuentaTerceros.Add(cuentaTercera);
        }
        public void EliminarCuenta(int id)
        {
            cuentaTerceros.RemoveAt(id);
        }
         // Nuevo método para obtener una cuenta específica por ID
        public string[] ObtenerCuenta(int id)
        {
            return cuentaTerceros[id];
        }
        // Nuevo método para editar una cuenta específica por ID
        public void EditarCuenta(int id, string[] nuevaCuenta)
        {
            cuentaTerceros[id] = nuevaCuenta;
        }
        #endregion
        #region Mostrar Cuentas
        //Ciclo foreach para mostrar las cuentas ingresadas
        public void MostrarCuentasTerceros()
        {
            Console.WriteLine("─────────────────────────────────────────────────");
            foreach (var cuenta in cuentaTerceros)
            {
                Console.WriteLine($"ID: {cuenta[0]}");
                Console.WriteLine($"Nombre del cuentahabitante: {cuenta[1]}");
                Console.WriteLine($"Nombre del banco: {cuenta[2]}");
                Console.WriteLine($"Número de cuenta: {cuenta[3]}");
                Console.WriteLine($"Primera cantidad transferida: {cuenta[4]}");
            }
            Console.WriteLine("─────────────────────────────────────────────────");
        }
        #endregion
        //Función para conseguir el tamaño de la lista, y así tener el ID en la otra clase
        public int IDdeCuenta
        {
            get { return cuentaTerceros.Count; }
        }
        //Método exclusivo del tamaño de lista
        public int CantidadCuentas()
        {
            return cuentaTerceros.Count;
        }
    }
}