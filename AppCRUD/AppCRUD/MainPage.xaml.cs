using AppCRUD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCRUD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LlenarDatos();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Pacientes pacient = new Pacientes
                {
                    Nom_pacie = txtNombre.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Nom_dueñ = txtNombreDueño.Text,
                    Direccion = txtDireccion.Text
                };
                await App.SQLiteDB.SavePacientesAsync(pacient);
               
                await DisplayAlert("Registro", "Se guardo de manera exitosa el Paciente", "Ok");
                LimpiarControles();
                LlenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok"); 
            }
        }
        public async void LlenarDatos()
        {
            var pacienteList = await App.SQLiteDB.GetPacientesAsync();
            if (pacienteList != null)
            {
                lstPacientes.ItemsSource = pacienteList;
            }
        }
        public bool ValidarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtNombreDueño.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta= true;
            }
            return respuesta;
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdPacientes.Text))
            {
                Pacientes paciente = new Pacientes()
                {
                    IdPaciente=Convert.ToInt32(txtIdPacientes.Text),
                    Nom_pacie=txtNombre.Text,
                    Edad=Convert.ToInt32(txtEdad.Text),
                    Nom_dueñ=txtNombreDueño.Text,
                    Direccion=txtDireccion.Text
                };
                await App.SQLiteDB.SavePacientesAsync(paciente);
                await DisplayAlert("Registro", "Se actualizó de manera exitosa el Paciente", "Ok");
                LimpiarControles(); 
                txtIdPacientes.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnRegistrar.IsVisible = true;
                LlenarDatos();
            }
        }

        private async void lstPacientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Pacientes)e.SelectedItem;
            btnRegistrar.IsVisible = false;
            txtIdPacientes.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;
            if (!string.IsNullOrEmpty(obj.IdPaciente.ToString()))
            {
                var paciente= await App.SQLiteDB.GetPacientesByIdAsync(obj.IdPaciente);
                if (paciente!=null)
                {
                    txtIdPacientes.Text = paciente.IdPaciente.ToString();
                    txtNombre.Text = paciente.Nom_pacie;
                    txtEdad.Text = paciente.Edad.ToString();
                    txtNombreDueño.Text = paciente.Nom_dueñ;
                    txtDireccion.Text = paciente.Direccion;
                }
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var paciente = await App.SQLiteDB.GetPacientesByIdAsync(Convert.ToInt32(txtIdPacientes.Text));
            if (paciente !=null)
            {
                await App.SQLiteDB.DeletePacienteAsync(paciente);
                await DisplayAlert("Paciente", "Paciente Eliminado de manera exitosa", "Aceptar");
                LimpiarControles();
                LlenarDatos();
                txtIdPacientes.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                btnRegistrar.IsVisible = true;
            }
        }
        public void LimpiarControles()
        {
            txtIdPacientes.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtNombreDueño.Text = "";
            txtDireccion.Text = "";
        }
    }
}
