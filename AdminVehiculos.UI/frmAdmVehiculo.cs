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

namespace AdminVehiculos.UI
{
    public partial class frmAdmVehiculo : Form
    {
        public frmAdmVehiculo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmVehiculos frm = new frmVehiculos();
                frm.Modo = frmVehiculos.TypeModo.Registrar;
                frm.objDelegado += CargarDatos;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehiculo.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccionar el elemento.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int Id = Convert.ToInt32(dgvVehiculo.SelectedRows[0]
                    .Cells["VehiculoId"].Value);
                frmVehiculos frm = new frmVehiculos();
                frm.Modo = frmVehiculos.TypeModo.Editar;
                frm.Id = Id;
                frm.objDelegado += CargarDatos;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehiculo.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccionar el elemento.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int Id = Convert.ToInt32(dgvVehiculo.SelectedRows[0]
                    .Cells["VehiculoId"].Value);
                frmVehiculos frm = new frmVehiculos();
                frm.Modo = frmVehiculos.TypeModo.Eliminar;
                frm.Id = Id;
                frm.objDelegado += CargarDatos;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Estas seguro que deseas salir?.", this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            this.Close();
        }

        private void frmAdmVehiculo_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarComponentes();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            VehiculoBC objVehiculoBC = new VehiculoBC();
            dgvVehiculo.DataSource = objVehiculoBC.VehiculoListar(txtFiltro.Text);
            dgvVehiculoConfigurar();
        }

        private void dgvVehiculoConfigurar()
        {
            dgvVehiculo.Columns["Placa"].DisplayIndex = 0;
            dgvVehiculo.Columns["Placa"].Width = 150;
            dgvVehiculo.Columns["Kilomentraje"].DisplayIndex = 1;
            dgvVehiculo.Columns["Kilomentraje"].Width = 150;
            dgvVehiculo.Columns["Modelo"].DisplayIndex = 2;
            dgvVehiculo.Columns["Modelo"].Width = 150;
          
        }
        private void ConfigurarComponentes()
        {
            dgvVehiculo.MultiSelect = false;
            dgvVehiculo.AllowUserToAddRows = false;
            dgvVehiculo.AllowUserToDeleteRows = false;
            dgvVehiculo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

    }
}
