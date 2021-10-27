using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data.Admin;
using Data.Models;

namespace AppWebClub
{
    public partial class WebClub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LlenarCombos();
                MostrarDatos();
            }
        }

        private void LlenarCombos()
        {
            DataTable dt = AdminJugador.listarPuestos();
            ddlPuesto.DataSource = dt;
            ddlPuesto.DataValueField = dt.Columns["Puesto"].ToString();
            ddlPuesto.DataTextField = dt.Columns["Puesto"].ToString();

            DataTable buscarPorPuesto = AdminJugador.listarPuestos();
            ddlBuscarPorPuesto.DataSource = buscarPorPuesto;
            ddlBuscarPorPuesto.DataValueField = buscarPorPuesto.Columns["Puesto"].ToString();
            ddlBuscarPorPuesto.DataTextField = buscarPorPuesto.Columns["Puesto"].ToString();
            DataRow fila = buscarPorPuesto.NewRow();
            fila["Puesto"] = 0;
            fila["Puesto"] = "[TODOS]";
            buscarPorPuesto.Rows.InsertAt(fila, 0);
            ddlBuscarPorPuesto.DataBind();
            ddlPuesto.DataBind();
        }
        private void MostrarDatos()
        {
            gridJugadores.DataSource = AdminJugador.Listar();
            gridJugadores.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Jugador j = new Jugador()
            {
                Puesto = ddlPuesto.SelectedValue.ToString(),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text)
            };
            int filasAfectadas = AdminJugador.Insertar(j);
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }
        }

        protected void ddlBuscarPorPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string puesto = ddlBuscarPorPuesto.SelectedValue.ToString();
            if (puesto == "[TODOS]")
            {
                MostrarDatos();
            }
            else
            {
                gridJugadores.DataSource = AdminJugador.Listar(puesto);
                gridJugadores.DataBind();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Jugador j = new Jugador()
            {
                Id = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Puesto = ddlPuesto.SelectedValue.ToString()
            };
            int filasAfectadas = AdminJugador.Modificar(j);
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasAfectadas = AdminJugador.Eliminar(id);
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }
        }
    }
}