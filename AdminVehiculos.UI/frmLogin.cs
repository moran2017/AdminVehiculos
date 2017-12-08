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
    public partial class frmLogin : Form
    {

        public enum TypeModo { Salir, Ingresar }
        public delegate void dlgActualizarPrincipal(TypeModo Modo, Login objUsuario);
        public dlgActualizarPrincipal objDelegado;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ValidarComponentes()
        {
            lblUsuario.Visible = txtUsuario.Text.Length == 0;
            lblPassword.Visible = txtPassword.Text.Length == 0;
        }

        private void btnIngresarLogin_Click(object sender, EventArgs e)
        {
            ValidarComponentes();

            if (lblUsuario.Visible || lblPassword.Visible)
                return;

            LoginBC objLoginBC = new LoginBC();
            Login objUsuario = objLoginBC.LoginValidar(txtUsuario.Text,txtPassword.Text);

            if (objUsuario == null)
            {
                MessageBox.Show("Usuario y/o contraseña incorrectas",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            objDelegado(TypeModo.Ingresar, objUsuario);
            this.Close();
        }

      
    }
}
