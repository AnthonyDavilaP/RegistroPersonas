using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroAlumoProfesor
{
    public partial class Form1 : Form
    {
        // Lista que almacena las personas ingresadas
        private BindingList<Persona> personas = new BindingList<Persona>();
        // Persona que se selecciona en el DataGrid
        private Persona seleccionada = null;
        public Form1()
        {
            InitializeComponent();
        }
        // Formulario base al ejecutar
        private void Form1_Load(object sender, EventArgs e)
        {
            // Agregan las opciones al combobox
            cmbTipo.Items.AddRange(new[] { "ALUMNO", "PROFESOR" });
            cmbTipo.SelectedIndex = 0;
            // Configuraciones del DataGridView
            dgwPersonas.DataSource = personas;
            dgwPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgwPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwPersonas.SelectionChanged += dgwPersonas_SelectionChanged;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            //Llama al método para actualizar la etiqueta de carrera/materia
            ActualizarMaCa();

        }
        // Método para validar que los campos obligatorios no estén vacíos
        private bool validar()
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El Nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("El Apellido es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtMaCa.Text))
            {
                MessageBox.Show("La materia/carrera es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }
            return true;
        }
        // Método para limpiar los campos del formulario
        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            numEdad.Value = numEdad.Minimum;
            txtMaCa.Clear();
        }
        // Acción que se realiza cuando selecciona una fila en el DataGridView
        private void dgwPersonas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwPersonas.CurrentRow != null && dgwPersonas.CurrentRow.DataBoundItem is Persona persona)
            {
                seleccionada = persona;
                //Muestran los datos de la fila seleccionada
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                numEdad.Value = persona.Edad;
                txtMaCa.Text = persona.CarreraMateria;
                cmbTipo.SelectedItem = persona.Tipo;
                ActualizarMaCa();
            }
        }
        // Método para cuando se cambia el comboBox del tipo
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarMaCa();
        }
        // Método para cambiar la etiqueta cuando se cambie el comboBox
        private void ActualizarMaCa()
        {
            string tipo = cmbTipo.SelectedItem.ToString();
            if (tipo == "ALUMNO")
            {
                lblMaCa.Text = "Carrera:";
                txtMaCa.Enabled = true;
            }
            else 
            {
                lblMaCa.Text = "Materia:";
                txtMaCa.Enabled = true;
            }
        }
        // Agrega una nueva persona con el boton 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string nombre = txtNombre.Text.Trim().ToUpper();
                string apellido = txtApellido.Text.Trim().ToUpper();
                string maCa = txtMaCa.Text.Trim().ToUpper();
                string tipo = cmbTipo.SelectedItem.ToString();
                int edad = (int)numEdad.Value;

                Persona persona;
                if (tipo == "ALUMNO")
                    persona = new Alumno(nombre, apellido, edad, maCa);
                else
                    persona = new Profesor(nombre, apellido, edad, maCa);
                personas.Add(persona);
                Limpiar();
            }
        }
        // Modifica los datos de la persona con el boton 
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgwPersonas.CurrentRow != null)
            {
                int seleccion = dgwPersonas.CurrentRow.Index; 

                Persona nuevaPersona;
                string tipo = cmbTipo.SelectedItem.ToString();
                if (tipo == "ALUMNO")
                    nuevaPersona = new Alumno(
                        txtNombre.Text.Trim().ToUpper(),
                        txtApellido.Text.Trim().ToUpper(),
                        (int)numEdad.Value,
                        txtMaCa.Text.Trim().ToUpper()
                    );
                else
                    nuevaPersona = new Profesor(
                        txtNombre.Text.Trim().ToUpper(),
                        txtApellido.Text.Trim().ToUpper(),
                        (int)numEdad.Value,
                        txtMaCa.Text.Trim().ToUpper()
                    );

                personas[seleccion] = nuevaPersona;

                Limpiar();
            }
            else
            {
                MessageBox.Show("Seleccione una persona primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
