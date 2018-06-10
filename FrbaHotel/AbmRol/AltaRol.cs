﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            llenarListaFuncionalidades();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idRol = crearRol();

                funcionalidades.CheckedItems.Cast<Funcionalidad>().ToList().ForEach(f =>
                {
                    asignarFuncionalidad(idRol, f.id);
                });

                Close();
            }
        }

        private Boolean validar()
        {
            Boolean esValido = true;
            if (String.IsNullOrEmpty(nombre.Text))
                esValido = false;
            else
                MessageBox.Show("Campo NOMBRE es obligatorio");

            if (funcionalidades.SelectedItems.Count == 0)
                esValido = false;
            else
                MessageBox.Show("Seleccione una funcionalidad");

            return esValido;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            funcionalidades.ClearSelected();
        }

        private void llenarListaFuncionalidades()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM FUNCIONALIDADES";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    funcionalidades.Items.Add(new Funcionalidad(reader));
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        private int crearRol()
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "ROL_Crear";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombreRol", SqlDbType.VarChar).Value = nombre.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            reader.Read();
            int idRol = reader.GetInt32(0);

            reader.Close();
            sqlConnection.Close();

            return idRol;
        }

        private void asignarFuncionalidad(int idRol, int idFuncionalidad)
        {
            SqlConnection sqlConnection = Conexion.getSqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "ROL_Asignar_Funcionalidad";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idRol", SqlDbType.Int).Value = idRol;
            cmd.Parameters.Add("@idFuncionalidad", SqlDbType.Int).Value = idFuncionalidad;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
