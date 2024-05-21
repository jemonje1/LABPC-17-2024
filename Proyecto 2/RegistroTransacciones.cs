namespace CountryBank
{
    class RegistroTransacciones
    {
    #region Lista
        //creación de lista para ir registrando y guardando todas las transacciones
        List<string> transacciones;
        public RegistroTransacciones()
        {
            transacciones = new List<string>();
        }
        //Método para añadir transacciones
        public void AgregarTransaccion(string transaccion)
        {
            transacciones.Add(transaccion);
        }
        //Método con ciclo foreach para mostrar un registro de todas las transacciones añadidas
        public void MostrarRegistro()
        {
            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Registro de Transacciones:");
            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────────────────────");
            foreach (var transaccion in transacciones)
            {
                Console.WriteLine(transaccion);
            }
            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────────────────────");
        }
    #endregion
    }
}