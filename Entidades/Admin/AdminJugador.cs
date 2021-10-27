using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Models;
using System.Data.SqlClient;
using Datos.Servidor;
using System.Data;

namespace Entidades.Admin
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
    }
}
