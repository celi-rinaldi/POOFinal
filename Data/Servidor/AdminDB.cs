using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data.Servidor
{
    public static class AdminDB
    {
        public static SqlConnection ConectarBase()
        {
            string cadena =Data.Properties.Settings.Default.KeyClubDB;
            SqlConnection connection = new SqlConnection(cadena);
            connection.Open();
            return connection;
        }
    }
}
