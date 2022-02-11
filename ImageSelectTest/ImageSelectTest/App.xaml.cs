using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace ImageSelectTest
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "photos.db";
        public static PhotoRepository database;
        public static PhotoRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new PhotoRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
