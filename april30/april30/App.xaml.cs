using April30;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace april30
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        // Ensure correct namespace and using directives for StudentDatabase
        static StudentDatabase database;

        // Use a more descriptive name for the database property
        public static StudentDatabase Database
        {
            get
            {
                if (database == null)
                {
                    // Use the correct name for the database file
                    database = new StudentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "students.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
