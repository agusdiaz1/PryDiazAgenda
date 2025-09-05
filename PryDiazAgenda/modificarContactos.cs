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
    public partial class modificarContactos : Form
    {
        conexionBD conexion = new conexionBD();
        public modificarContactos()
        {
            InitializeComponent();
            CargarTreeView();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Contactos ContactoModificado = new Contactos();

            int codigo;
            if (!int.TryParse(txtId.Text, out codigo))
            {
                MessageBox.Show("Por favor, ingrese un ID de producto válido.");
                return;
            }

            ContactoModificado.id = int.Parse(txtId.Text);
            ContactoModificado.Nombre = txtNombre.Text;
            ContactoModificado.Apellido = txtApellido.Text;
            ContactoModificado.Telefono = txtTelefono.Text;  
            ContactoModificado.Correo = txtCorreo.Text;
            ContactoModificado.Categoria = cboCategoria.Text;

            try
            {
                conexion.ModificarContacto(ContactoModificado);
                LimpiarCampos();
                CargarTreeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el Contacto: " + ex.Message);
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

        private void modificarContactos_Load(object sender, EventArgs e)
        {
            cboCategoria.Items.Clear();
            List<string> listaCategorias = conexion.ObtenerCategorias();

            foreach (var cat in listaCategorias)
            {
                cboCategoria.Items.Add(cat);
            }
        }
    }
}
