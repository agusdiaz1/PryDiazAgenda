namespace PryDiazAgenda
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuContactos = new System.Windows.Forms.MenuStrip();
            this.contactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picAgenda = new System.Windows.Forms.PictureBox();
            this.mnuContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuContactos
            // 
            this.mnuContactos.BackColor = System.Drawing.Color.MistyRose;
            this.mnuContactos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactosToolStripMenuItem});
            this.mnuContactos.Location = new System.Drawing.Point(0, 0);
            this.mnuContactos.Name = "mnuContactos";
            this.mnuContactos.Size = new System.Drawing.Size(510, 24);
            this.mnuContactos.TabIndex = 1;
            this.mnuContactos.Text = "menuStrip1";
            // 
            // contactosToolStripMenuItem
            // 
            this.contactosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.contactosToolStripMenuItem.Name = "contactosToolStripMenuItem";
            this.contactosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.contactosToolStripMenuItem.Text = "Contactos";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportarToolStripMenuItem.Text = "Exportar";
            // 
            // picAgenda
            // 
            this.picAgenda.Image = global::PryDiazAgenda.Properties.Resources.agenda;
            this.picAgenda.Location = new System.Drawing.Point(0, 27);
            this.picAgenda.Name = "picAgenda";
            this.picAgenda.Size = new System.Drawing.Size(506, 523);
            this.picAgenda.TabIndex = 2;
            this.picAgenda.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(510, 551);
            this.Controls.Add(this.picAgenda);
            this.Controls.Add(this.mnuContactos);
            this.Name = "frmPrincipal";
            this.Text = "Inicio";
            this.mnuContactos.ResumeLayout(false);
            this.mnuContactos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAgenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuContactos;
        private System.Windows.Forms.ToolStripMenuItem contactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.PictureBox picAgenda;
    }
}