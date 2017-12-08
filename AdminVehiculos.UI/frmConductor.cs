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
    public partial class frmConductor : Form
    {

        public int Id { get; set; }
        public enum TypeModo { Registrar, Editar, Eliminar }
        public TypeModo Modo { get; set; }
        public delegate void ActualizarDatos();
        public ActualizarDatos objDelegado;
        private String MensajePregunta;
        private String MensajeRespuesta;
      //  private String MensajeAdvertencia = "¿Esta seguro que desea salir?";
        public frmConductor()
        {
            InitializeComponent();
        }

        private void frmConductor_Load(object sender, EventArgs e)
        {
            try
            {
                if (Modo == TypeModo.Registrar)
                {
                    lblTitulo.Text = "REGISTRAR CONDUCTOR";
                    MensajePregunta = "¿Está seguro de registrar el personaje?";
                    MensajeRespuesta = "El personaje se registró satisfactoriamente";

                }
                else if (Modo == TypeModo.Editar)
                {
                    lblTitulo.Text = "EDITAR CONDUCTOR";
                    MensajePregunta = "¿Está seguro de editar el personaje?";
                    MensajeRespuesta = "El personaje se actualizó satisfactoriamente";

                    ConductorBC objConductorBC = new ConductorBC();
                    Conductor objConductor = objConductorBC.ConductorObtener(Id);
                    txtDNI.Text = objConductor.Nombre;
                    txtNombre.Text = objConductor.Nombre;
                    txtApellidos.Text = objConductor.Apellido;
                    txtTipo.Text = objConductor.Tipo;
                  
                }
                else if (Modo == TypeModo.Eliminar)
                {
                    lblTitulo.Text = "ELIMINAR CONDUCTOR";
                    MensajePregunta = "¿Esta seguro que desea eliminar el Conductor?";
                    MensajeRespuesta = "El personaje se Elimino satisfactoriamente";
                    ConductorBC objConductorBC = new ConductorBC();
                    Conductor objConductor = objConductorBC.ConductorObtener(Id);
                    
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
            lblDNI.Visible = txtDNI.Text.Length == 0;
            lblNombre.Visible = txtNombre.Text.Length == 0;
            lblApellidos.Visible = txtApellidos.Text.Length == 0;
            lblTipo.Visible = txtTipo.Text.Length == 0;
            lblEstado.Visible = txtEstado.Text.Length == 0;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidarControles();

            if (lblDNI.Visible || lblNombre.Visible || lblApellidos.Visible || lblTipo.Visible || lblEstado.Visible)
                return;

            if (MessageBox.Show(MensajePregunta, this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            ConductorBC objConductorBC = new ConductorBC();
            Conductor objConductor = new Conductor();
            objConductor.DNI = txtDNI.Text;
            objConductor.Nombre = txtNombre.Text;
            objConductor.Apellido = txtApellidos.Text;
            objConductor.Tipo = txtTipo.Text;
          

            if (Modo == TypeModo.Editar)
            {
                objConductor.ConductorId = Id;
                objConductorBC.ConductorEditar(objConductor);
            }
            else if (Modo == TypeModo.Registrar)
            {
                objConductorBC.ConductorRegistrar(objConductor);
            }
            else if (Modo == TypeModo.Eliminar)
            {
                objConductor.ConductorId = Id;
                objConductorBC.ConductorEliminar(Id);
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
