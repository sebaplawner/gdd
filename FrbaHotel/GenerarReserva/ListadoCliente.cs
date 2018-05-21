﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarReserva
{
    public partial class ListadoCliente : Form
    {
        public ListadoCliente()
        {
            InitializeComponent();
        }

        private void ListadoCliente_Load(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Eliminar fila?", "Eliminar", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {

            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Clear();
            apellido.Clear();
            nroIdentificacion.Clear();
            email.Clear();
        }
    }
}
