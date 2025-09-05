using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryDiazAgenda
{
    public partial class eliminarContactos : Form
    {
        conexionBD conexion = new conexionBD();
        public eliminarContactos()
        {
            InitializeComponent();
            CargarTreeView();
            conexion.listarContactos(dgvContactos);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Por favor, ingrese un ID de Contacto válido.");
                return;
            }

            try
            {
                CargarTreeView();
                conexion.EliminarContacto(id);
                LimpiarCampos();
                conexion.listarContactos(dgvContactos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el Contacto: " + ex.Message);
            }
        }

        public void CargarTreeView()
        {
            trvContactos.Nodes.Clear();

            DataTable tablaContactos = conexion.ObtenerContactosPorCategoria();

            Dictionary<string, TreeNode> nodosPorCategoria = new Dictionary<string, TreeNode>();

            // Crear los nodos del TreeView
            foreach (DataRow row in tablaContactos.Rows)
            {
                string categoria = row["Categoria"].ToString();
                string nombre = row["Nombre"].ToString();
                string apellido = row["Apellido"].ToString();

                TreeNode nodoCategoria;
                if (!nodosPorCategoria.TryGetValue(categoria, out nodoCategoria))
                {
                    nodoCategoria = new TreeNode(categoria);
                    trvContactos.Nodes.Add(nodoCategoria);
                    nodosPorCategoria[categoria] = nodoCategoria;
                }

                TreeNode nodoContacto = new TreeNode($"{nombre}, {apellido}");
                nodoCategoria.Nodes.Add(nodoContacto);
            }

            trvContactos.ExpandAll();
        }

        public void LimpiarCampos()
        {
            txtId.Clear();
        }

    }
}
