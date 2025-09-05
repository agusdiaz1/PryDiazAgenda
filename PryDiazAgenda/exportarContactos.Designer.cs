namespace PryDiazAgenda
{
    partial class exportarContactos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(exportarContactos));
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.btnExportarVCard = new System.Windows.Forms.Button();
            this.btnExportarCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContactos
            // 
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Location = new System.Drawing.Point(12, 12);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.Size = new System.Drawing.Size(628, 352);
            this.dgvContactos.TabIndex = 17;
            // 
            // btnExportarVCard
            // 
            this.btnExportarVCard.BackColor = System.Drawing.Color.MistyRose;
            this.btnExportarVCard.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarVCard.Location = new System.Drawing.Point(422, 377);
            this.btnExportarVCard.Name = "btnExportarVCard";
            this.btnExportarVCard.Size = new System.Drawing.Size(218, 34);
            this.btnExportarVCard.TabIndex = 18;
            this.btnExportarVCard.Text = "Exportar contactos a VCard";
            this.btnExportarVCard.UseVisualStyleBackColor = false;
            this.btnExportarVCard.Click += new System.EventHandler(this.btnExportarVCard_Click);
            // 
            // btnExportarCSV
            // 
            this.btnExportarCSV.BackColor = System.Drawing.Color.MistyRose;
            this.btnExportarCSV.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCSV.Location = new System.Drawing.Point(12, 377);
            this.btnExportarCSV.Name = "btnExportarCSV";
            this.btnExportarCSV.Size = new System.Drawing.Size(217, 34);
            this.btnExportarCSV.TabIndex = 19;
            this.btnExportarCSV.Text = "Exportar contactos a CSV";
            this.btnExportarCSV.UseVisualStyleBackColor = false;
            this.btnExportarCSV.Click += new System.EventHandler(this.btnExportarCSV_Click);
            // 
            // exportarContactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(652, 423);
            this.Controls.Add(this.btnExportarCSV);
            this.Controls.Add(this.btnExportarVCard);
            this.Controls.Add(this.dgvContactos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "exportarContactos";
            this.Text = "Exportar Contactos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.Button btnExportarVCard;
        private System.Windows.Forms.Button btnExportarCSV;
    }
}