using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Cadena de conexión a la base de datos SQL Server
        string connectionString = "Data Source=nombre_servidor;" +
            "Initial Catalog=nombre_base_datos;" +
            "User ID=nombre_usuario;" +
            "Password=contraseña;";

        // Consulta SQL a ejecutar
        string query = "SELECT * FROM tabla";

        // Crear una nueva conexión a la base de datos
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Crear un comando SQL y asignar la consulta y la conexión
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Ejecutar el comando y obtener un lector de datos
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Iterar a través de los registros devueltos
                    while (reader.Read())
                    {
                        // Acceder a los datos de cada columna
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);

                        // Hacer algo con los datos recuperados
                        Console.WriteLine($"ID: {id}, Nombre: {nombre}");
                    }
                }
            }
        }
    }
}
