using System;
using AppCRUD.Modelos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
            
        }

        private async void btnAcerca_Clicked(object sender, EventArgs e)
        {
            App.MAsterDet.IsPresented = false;
            await App.MAsterDet.Detail.Navigation.PushAsync(new AcercaDe());
        }

        private async void btnTerminos_Clicked(object sender, EventArgs e)
        {
            App.MAsterDet.IsPresented = false;
            await App.MAsterDet.Detail.Navigation.PushAsync(new TerminosCondiciones());
        }
    }

}