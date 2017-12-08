using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AdminVehiculos.BC.BL;
using AdminVehiculos.DL.DataModel;

namespace AdminVehiculos.UI
{
    public partial class frmVehiculos : Form
    {

        public int Id { get; set; }
        public enum TypeModo { Registrar, Editar, Eliminar }
        public TypeModo Modo { get; set; }
        public delegate void ActualizarDatos();
        public ActualizarDatos objDelegado;
        private String MensajePregunta;
        private String MensajeRespuesta;

        public frmVehiculos()
        {
            InitializeComponent();
        }

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            try
            {
                if (Modo == TypeModo.Registrar)
                {
                    lblTitulo.Text = "REGISTRAR VEHICULO";
                    MensajePregunta = "¿Está seguro de registrar el vehiculo?";
                    MensajeRespuesta = "El vehiculo se registró satisfactoriamente";

                }
                else if (Modo == TypeModo.Editar)
                {
                    lblTitulo.Text = "REGISTRAR VEHICULO";
                    MensajePregunta = "¿Está seguro de registrar el vehiculo?";
                    MensajeRespuesta = "El vehiculo se registró satisfactoriamente"; ;

                    VehiculoBC objVehiculorBC = new VehiculoBC();
                    Vehiculos objVehiculo = objVehiculorBC.VehiculoObtener(Id);
                    txtPlaca.Text = objVehiculo.Placa;
                    nudKilometraje.Value = (int)nudKilometraje.Value;
                   // txtModelo.Text = objVehiculo.Modelo;
                   
                }
                else if (Modo == TypeModo.Eliminar)
                {
                    lblTitulo.Text = "REGISTRAR VEHICULO";
                    MensajePregunta = "¿Está seguro de registrar el vehiculo?";
                    MensajeRespuesta = "El vehiculo se registró satisfactoriamente";
                    VehiculoBC objVehiculorBC = new VehiculoBC();
                    Vehiculos objVehiculo = objVehiculorBC.VehiculoObtener(Id);
                    nudKilometraje.Value = (int)nudKilometraje.Value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ValidarControles()
        {
            lblPlaca.Visible = txtPlaca.Text.Length == 0;
          //  lblKilometraje.Visible = nudKilometraje.Value== 0;
            lblModelo.Visible = txtModelo.Text.Length == 0;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidarControles();

            if (lblPlaca.Visible || lblKilometraje.Visible || lblModelo.Visible)
                return;

            if (MessageBox.Show(MensajePregunta, this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            VehiculoBC objVehiculoBC = new VehiculoBC();
            Vehiculos objVehiculo = new Vehiculos();
            objVehiculo.Placa = txtPlaca.Text;
            objVehiculo.kilometraje = (int)nudKilometraje.Value;
            //objVehiculo.MarcaId = txtModelo.Text;
            

            if (Modo == TypeModo.Editar)
            {
                objVehiculo.VehiculoId = Id;
                objVehiculoBC.VehiculoEditar(objVehiculo);
            }
            else if (Modo == TypeModo.Registrar)
            {
                objVehiculoBC.VehiculoRegistrar(objVehiculo);
            }
            else if (Modo == TypeModo.Eliminar)
            {
                objVehiculo.VehiculoId = Id;
                objVehiculoBC.VehiculoEliminar(Id);
            }
            objDelegado();
            MessageBox.Show(MensajeRespuesta, this.Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Estas seguro que deseas salir?", this.Text,
      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Close();
        }
    }
}
