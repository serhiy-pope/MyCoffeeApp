using MyCoffeeApp3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InternetCoffeePage : ContentPage
    {
        public InternetCoffeePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (InternetCoffeeViewModel)BindingContext;
            if (vm.Coffee.Count == 0)
                await vm.RefreshCommand.ExecuteAsync();
        }
    }
}