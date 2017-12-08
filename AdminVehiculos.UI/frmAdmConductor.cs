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
    public partial class frmAdmConductor : Form
    {
        public frmAdmConductor()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            ConductorBC objConductorjeBC = new ConductorBC();
            dgvConductor.DataSource = objConductorjeBC.ConductorListar(txtFiltro.Text);
            dgvConductorConfigurar();
        }
        private void ConfigurarComponentes()
        {
            dgvConductor.MultiSelect = false;
            dgvConductor.AllowUserToAddRows = false;
            dgvConductor.AllowUserToDeleteRows = false;
            dgvConductor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvConductorConfigurar()
        {
            dgvConductor.Columns["DNI"].DisplayIndex = 0;
            dgvConductor.Columns["DNI"].Width = 150;
            dgvConductor.Columns["Nombre"].DisplayIndex = 1;
            dgvConductor.Columns["Nombre"].Width = 150;
            dgvConductor.Columns["Apellidos"].DisplayIndex = 2;
            dgvConductor.Columns["Apellidos"].Width = 150;
            dgvConductor.Columns["Tipo"].DisplayIndex = 3;
            dgvConductor.Columns["Tipo"].Width = 150;
            dgvConductor.Columns["Estado"].DisplayIndex = 4;
            dgvConductor.Columns["Estado"].Width = 150;
           // dgvConductor.Columns["MarcaId"].DisplayIndex = 5;
           //dgvConductor.Columns["MarcaId"].Width = 150;
         //   dgvConductor.Columns["VehiculoId"].DisplayIndex = 6;
          //  dgvConductor.Columns["VehiculoId"].Width = 150;
        }
        private void frmAdmConductor_Load(object sender, EventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmConductor frm = new frmConductor();
                frm.Modo = frmConductor.TypeModo.Registrar;
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
                if (dgvConductor.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccionar el elemento.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int Id = Convert.ToInt32(dgvConductor.SelectedRows[0]
                    .Cells["ConductorId"].Value);
                frmConductor frm = new frmConductor();
                frm.Modo = frmConductor.TypeModo.Editar;
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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
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
                if (dgvConductor.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccionar el elemento.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int Id = Convert.ToInt32(dgvConductor.SelectedRows[0]
                    .Cells["ConductorId"].Value);
                frmConductor frm = new frmConductor();
                frm.Modo = frmConductor.TypeModo.Eliminar;
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

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Estas seguro que deseas salir?.", this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            this.Close();
        }
    }
}
