using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageSelectTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePhoto : ContentPage
    {
        public Photo photo { get; set; }
        public PagePhoto(Photo newPhoto)
        {
            InitializeComponent();
            photo = newPhoto;
            this.BindingContext = this;
        }
    }
}