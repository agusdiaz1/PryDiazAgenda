using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryDiazAgenda
{
    public partial class exportarContactos : Form
    {
        conexionBD conexion = new conexionBD();
        public exportarContactos()
        {
            InitializeComponent();
            conexion.listarContactos(dgvContactos);
        }

        private void btnExportarVCard_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo vCard (*.vcf)|*.vcf";
            sfd.FileName = "contactos.vcf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                conexion.ExportarContactosVCard(sfd.FileName);
            }
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.FileName = "contactos.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                conexion.ExportarContactosCSV(sfd.FileName);
            }
        }
    }
}
