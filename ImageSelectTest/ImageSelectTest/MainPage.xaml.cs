using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace ImageSelectTest
{
    public partial class MainPage : ContentPage
    {
        public IEnumerable<Photo> Photos { get; set; }
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public string photoPath { get; set; }
        
        public MainPage()
        {
            InitializeComponent();
            Photos = App.Database.GetItems();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateList();
        }

        void UpdateList()
        {
            Photos = App.Database.GetItems();
            lvPhotos.ItemsSource = Photos;
        }


        private async void lvPhotosItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var photo = lvPhotos.SelectedItem as Photo;
            await Navigation.PushAsync(new PagePhoto(photo));
        }

        private async void btnGalleryClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                photoPath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void btnCameraClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                photoPath = photo.FullPath;
                //img.Source = ImageSource.FromFile(photo.FullPath);
                UpdateList();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private void btnAddClicked(object sender, EventArgs e)
        {
            Photo photo = new Photo
            {
                Id = Photos.Count() + 1,
                Name = entryName.Text,
                Path = photoPath
            };

            App.Database.SaveItem(photo);
            UpdateList();
        }
    }
}
