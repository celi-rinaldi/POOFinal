using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Data.Servidor;
using Data.Models;


namespace Data.Admin
{
    public static class AdminJugador
    {
        public static int Insertar(Jugador jugador)
        {
            string insert = "INSERT dbo.Jugador (Nombre, Apellido, FechaNacimiento, Puesto) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Puesto)";
            SqlCommand comando = new SqlCommand(insert, AdminDB.ConectarBase());
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = jugador.Nombre;
            comando.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = jugador.Apellido;
            comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = jugador.FechaNacimiento;
            comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = jugador.Puesto;
            int filasAfectadas = comando.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;

        }
        public static DataTable Listar(string puesto)
        {
            string consulta = "SELECT Id, Nombre, Apellido, FechaNacimiento, Puesto from dbo.Jugador WHERE Puesto=@Puesto";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());
            adapter.SelectCommand.Parameters.Add("@Puesto", SqlDbType.VarChar, 50).Value = puesto;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Puesto"); 
            return ds.Tables["Puesto"];

        }
        public static List<Jugador> Listar()
        {
            string consulta = "SELECT Id, Nombre, Apellido, FechaNacimiento, Puesto from dbo.Jugador";
            SqlCommand comando = new SqlCommand(consulta, AdminDB.ConectarBase());
            SqlDataReader reader;
            reader = comando.ExecuteReader();
            List<Jugador> lista = new List<Jugador>();
            while (reader.Read())
            {
                lista.Add(
                    new Jugador()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                        Puesto = reader["Puesto"].ToString()
                    });
            }
            AdminDB.ConectarBase().Close();
            reader.Close();
            return lista;
        }
        public static DataTable listarPuestos()
        {
            string consulta = "SELECT DISTINCT Puesto from dbo.Jugador";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Puesto");
            return ds.Tables["Puesto"];
        }
        public static int Modificar(Jugador jugador)
        {
                string update = "UPDATE dbo.Jugador SET Nombre=@Nombre, Apellido=@Apellido, FechaNacimiento=@FechaNacimiento, Puesto=@Puesto WHERE Id=@Id";
                SqlCommand comando = new SqlCommand(update, AdminDB.ConectarBase());
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = jugador.Nombre;
                comando.Parameters.Add("@Apellido", SqlDbType.Char, 50).Value = jugador.Apellido;
                comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = jugador.FechaNacimiento;
                comando.Parameters.Add("@Puesto", SqlDbType.VarChar,50).Value = jugador.Puesto;
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = jugador.Id;
                int filasAfectadas = comando.ExecuteNonQuery();
                AdminDB.ConectarBase().Close();
                return filasAfectadas;
            
        }
        public static int Eliminar(int id)
        {
            string delete = "DELETE FROM dbo.Jugador WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(delete, AdminDB.ConectarBase());
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            int filasAfectadas = comando.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
    }
}
