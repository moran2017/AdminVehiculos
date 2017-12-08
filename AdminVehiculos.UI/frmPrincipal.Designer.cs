namespace AdminVehiculos.UI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conductorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conductorToolStripMenuItem,
            this.vehiculoToolStripMenuItem,
            this.marcaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conductorToolStripMenuItem
            // 
            this.conductorToolStripMenuItem.Image = global::AdminVehiculos.UI.Properties.Resources.if_driver_44758;
            this.conductorToolStripMenuItem.Name = "conductorToolStripMenuItem";
            this.conductorToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.conductorToolStripMenuItem.Text = "Conductor";
            this.conductorToolStripMenuItem.Click += new System.EventHandler(this.conductorToolStripMenuItem_Click);
            // 
            // vehiculoToolStripMenuItem
            // 
            this.vehiculoToolStripMenuItem.Image = global::AdminVehiculos.UI.Properties.Resources.if_Old_Car_2_379346;
            this.vehiculoToolStripMenuItem.Name = "vehiculoToolStripMenuItem";
            this.vehiculoToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.vehiculoToolStripMenuItem.Text = "Vehiculo";
            this.vehiculoToolStripMenuItem.Click += new System.EventHandler(this.vehiculoToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.marcaToolStripMenuItem.Text = "Marca";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::AdminVehiculos.UI.Properties.Resources.if_Cancel_1493282;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 309);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conductorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

