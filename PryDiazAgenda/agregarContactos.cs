using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PryDiazAgenda
{
    public partial class agregarContactos : Form
    {
        conexionBD conexion = new conexionBD();
        Dictionary<int, TreeNode> nodosPorId = new Dictionary<int, TreeNode>();
        Dictionary<string, TreeNode> nodosPorCategoria = new Dictionary<string, TreeNode>();
        public agregarContactos()
        {
            InitializeComponent();
            CargarTreeView();
        }

        private void agregarContactos_Load(object sender, EventArgs e)
        {
            cboCategoria.Items.Clear();
            List<string> listaCategorias = conexion.ObtenerCategorias();

            foreach (var cat in listaCategorias)
            {
                cboCategoria.Items.Add(cat);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Contactos nuevoContacto = new Contactos();

            nuevoContacto.id = int.Parse(txtId.Text);
            nuevoContacto.Nombre = txtNombre.Text;
            nuevoContacto.Apellido = txtApellido.Text;
            nuevoContacto.Telefono = txtTelefono.Text;
            nuevoContacto.Correo = txtCorreo.Text;
            nuevoContacto.Categoria = cboCategoria.Text;

            try
            {
                conexion.AgregarContactos(nuevoContacto);
                LimpiarCampos();
                CargarTreeView();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el contacto: " + ex.Message);
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
            cboCategoria.Items.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
        }
    }
}
