using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCRUD.Data;
using System.IO;

namespace AppCRUD
{
    
    public partial class App : Application
    {
        public static MasterDetailPage MAsterDet { get; set; }
        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Veterinaria.db3"));
                }    
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
