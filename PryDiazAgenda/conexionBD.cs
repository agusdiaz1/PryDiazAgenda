using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PryDiazAgenda
{
    public class conexionBD
    {
        OleDbConnection conexion;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;

        string cadena;

        public conexionBD()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0 ;Data Source= ../../../BD/Agenda.accdb";
        }
        public DataTable ObtenerContactosPorCategoria()
        {
            using (OleDbConnection conexion = new OleDbConnection(cadena))
            {
                using (OleDbCommand comando = new OleDbCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "SELECT * FROM Contacto ORDER BY Categoria"; 
                    using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }


        // Método para listar todos los contactos
        public void listarContactos(DataGridView dgvcontactos)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Contacto";

                DataTable tablaContactos = new DataTable(); 

                adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(tablaContactos); 

                dgvcontactos.DataSource = tablaContactos; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AgregarContactos(Contactos nuevoContacto)
        {
            using (OleDbConnection conexion = new OleDbConnection(cadena))
            {
                using (OleDbCommand comando = new OleDbCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO Contacto (Nombre, Apellido, Telefono,Correo, Categoria) " +
                               "VALUES (@Nombre, @Apellido, @Telefono, @Correo, @Categoria)";

                    comando.Parameters.AddWithValue("@Nombre", nuevoContacto.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", nuevoContacto.Apellido);
                    comando.Parameters.AddWithValue("@Telefono", nuevoContacto.Telefono);
                    comando.Parameters.AddWithValue("@Correo", nuevoContacto.Correo);
                    comando.Parameters.AddWithValue("@Categoria", nuevoContacto.Categoria);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepción (por ejemplo, mostrar un mensaje de error al usuario)
                        MessageBox.Show("Error al agregar el contacto: " + ex.Message);
                    }
                }
            }

        }

        public void ModificarContacto(Contactos contacto)
        {
           
            using (OleDbConnection conexion = new OleDbConnection(cadena))
            {
                using (OleDbCommand comando = new OleDbCommand())
                {
                    comando.Connection = conexion;            
                    comando.CommandType = CommandType.Text;
                    comando.CommandText
                         = @"UPDATE Contacto
                                 SET Nombre = @nuevoNombre,
                                     Apellido = @nuevoApellido,
                                     Telefono = @nuevoTelefono,
                                     Correo = @nuevoCorreo,
                                     Categoria = @nuevaCategoria
                                     WHERE Id = @id";
                   
                    comando.Parameters.AddWithValue("@nuevoNombre", contacto.Nombre);
                    comando.Parameters.AddWithValue("@nuevoApellido", contacto.Apellido);
                    comando.Parameters.AddWithValue("@nuevoTelefono", contacto.Telefono);
                    comando.Parameters.AddWithValue("@nuevoCorreo", contacto.Correo);
                    comando.Parameters.AddWithValue("@nuevaCategoria", contacto.Categoria);
                    comando.Parameters.AddWithValue("@id", contacto.id);

                    try
                    {
                        
                        conexion.Open();                       
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            
                            MessageBox.Show("Contacto modificado correctamente.");
                        }
                        else 
                        {
                            MessageBox.Show("No se encontró ningún producto con el ID especificado.");
                        }

                    }
                    catch (Exception ex)  
                    {
                        
                        MessageBox.Show("Error al modificar el producto: " + ex.Message);
                    }
                }
            }

        }

        public void EliminarContacto(int id)
        {
            using (OleDbConnection conexion = new OleDbConnection(cadena))
            {
                using (OleDbCommand comando = new OleDbCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = @"DELETE FROM Contacto WHERE Id = @id";

                    // Agregar el parámetro
                    comando.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Contacto eliminado correctamente.");

                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún producto con el ID especificado.");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                    }
                }
            }
        }

        //Exporta a CSV
        public void ExportarContactosCSV(string rutaArchivo)
        {
            try
            {
                string sql = "SELECT Nombre, Apellido, Telefono, Correo, Categoria FROM Contacto";
                comando = new OleDbCommand(sql, conexion);
                OleDbDataReader lector = comando.ExecuteReader();

                using (StreamWriter sw = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Nombre,Apellido,Telefono,Correo,Categoria");

                    while (lector.Read())
                    {
                        string linea = $"{lector["Nombre"]},{lector["Apellido"]},{lector["Telefono"]},{lector["Correo"]},{lector["Categoria"]}";
                        sw.WriteLine(linea);
                    }
                }

                MessageBox.Show("Contactos exportados a CSV correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar CSV: " + ex.Message);
            }
        }

        //Exportar a vCard
        public void ExportarContactosVCard(string rutaArchivo)
        {
            try
            {
                string sql = "SELECT Nombre, Apellido, Telefono, Correo, Categoria FROM Contacto";
                comando = new OleDbCommand(sql, conexion);
                OleDbDataReader lector = comando.ExecuteReader();

                using (StreamWriter sw = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
                {
                    while (lector.Read())
                    {
                        sw.WriteLine("BEGIN:VCARD");
                        sw.WriteLine("VERSION:3.0");
                        sw.WriteLine($"N:{lector["Apellido"]};{lector["Nombre"]};;;");
                        sw.WriteLine($"FN:{lector["Nombre"]} {lector["Apellido"]}");
                        sw.WriteLine($"TEL;TYPE=CELL:{lector["Telefono"]}");
                        sw.WriteLine($"EMAIL:{lector["Correo"]}");
                        sw.WriteLine($"CATEGORIES:{lector["Categoria"]}");
                        sw.WriteLine("END:VCARD");
                    }
                }

                MessageBox.Show("Contactos exportados a vCard correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar vCard: " + ex.Message);
            }
        }

        public List<string> ObtenerCategorias()
        {
            List<string> categorias = new List<string>();

            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadena))
                {
                    string sql = "SELECT DISTINCT Categoria FROM Contacto";
                    using (OleDbCommand comando = new OleDbCommand(sql, conexion))
                    {
                        conexion.Open();
                        OleDbDataReader lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            categorias.Add(lector["Categoria"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener categorías: " + ex.Message);
            }

            return categorias;
        }
    }
}


