using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeImageUploaderPage : ContentPage
    {
        HttpClient httpClient = new HttpClient();
        public CoffeeImageUploaderPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var file = await MediaPicker.PickPhotoAsync();

            if (file == null)
                return;

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(await file.OpenReadAsync()), "file", file.FileName);

            var response = await httpClient.PostAsync("http://192.168.0.45:7193/UploadFile", content);

            StatusLabel.Text = response.StatusCode.ToString();
        }
    }
}