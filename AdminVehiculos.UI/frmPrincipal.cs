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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void conductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmAdmConductor frm= new frmAdmConductor();
           // frm.MdiParent = this;
            frm.Show();
            
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.objDelegado += ActualizarPrincipal;
            frm.ShowDialog();
        }

        private void ActualizarPrincipal(frmLogin.TypeModo Modo, Login objUsuario)
        {
            if (Modo == frmLogin.TypeModo.Salir)
            {
                this.Close();
            }
            else if (Modo == frmLogin.TypeModo.Ingresar)
            {

            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmVehiculo frm = new frmAdmVehiculo();
            // frm.MdiParent = this;
            frm.Show();

        }
    }
}
