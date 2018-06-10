﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Objetos;

namespace FrbaHotel.AbmHotel
{
    public partial class AltaHotel : Form
    {
        private List<Estrella> estrellas;
        private List<Pais> paises;
        private List<Ciudad> ciudades;

        public AltaHotel(List<Estrella> estrellas, List<Pais> paises, List<Ciudad> ciudades)
        {
            this.estrellas = estrellas;
            this.paises = paises;
            this.ciudades = ciudades;
            InitializeComponent();
        }

        private void AltaHotel_Load(object sender, EventArgs e)
        {
            estrellas2.Items.AddRange(estrellas.ToArray());
            pais.Items.AddRange(paises.ToArray());
            ciudad.Items.AddRange(ciudades.ToArray());

            obtenerRegimenes();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idHotel = crearHotel();

                regimenesList.CheckedItems.Cast<Regimen>().ToList().ForEach(r =>
                {
                    asignarRegimen(idHotel, r.id);
                });

                Close();
            }
        }

        private Boolean validar()
        {
            Control[] controles = { nombre, email, telefono, direccion, ciudad, pais, fechaCreacion, estrellas2 };

            Boolean esValido = true;
            String errores = "";
            foreach (Control control in controles.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                errores += "El campo " + control.Name.ToUpper() + " es obligatorio.\n";
                esValido = false;
            }

            if (!esValido)
                MessageBox.Show(errores, "ERROR");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            email.Clear();
            telefono.Clear();
            direccion.Clear();
            ciudad.SelectedIndex = 0;
            pais.SelectedIndex = 0;
            estrellas2.SelectedIndex = 0;
            fechaCreacion.Clear();
        }

        private int crearHotel()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            
            cmd.CommandText = "HOTEL_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono.Text;
            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar).Value = direccion.Text;
            cmd.Parameters.Add("@pais", SqlDbType.Int).Value = nombre.Text;
            cmd.Parameters.Add("@ciudad", SqlDbType.Int).Value = nombre.Text;
            cmd.Parameters.Add("@estrellas", SqlDbType.Int).Value = nombre.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            reader.Read();
            int idHotel = reader.GetInt32(0);

            reader.Close();
            sqlConnection.Close();

            return idHotel;
        }

        private void obtenerRegimenes()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM REGIMEN WHERE regi_habilitado = 1";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    regimenesList.Items.Add(new Regimen(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private void asignarRegimen(int idHotel, int idRegimen)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "HOTEL_Asignar_Regimen";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idHotel", SqlDbType.Int).Value = idHotel;
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = idRegimen;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
