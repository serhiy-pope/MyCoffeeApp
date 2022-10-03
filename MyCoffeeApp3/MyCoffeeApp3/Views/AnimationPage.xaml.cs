using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoffeeApp3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimationPage : ContentPage
    {
        ImageCacheViewModel vm;

        readonly Animation rotation;
        public AnimationPage()
        {
            InitializeComponent();

            rotation = new Animation(v => LabelLoad.Rotation = v,
                0, 360, Easing.Linear);
            vm = (ImageCacheViewModel)BindingContext;

            vm.PropertyChanged += Vm_PropertyChanged;
        }

        private async void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(vm.IsBusy))
            {
                if(vm.IsBusy)
                {
                    //animate
                    rotation.Commit(this, "rotate", 16, 1000, Easing.Linear,
                        (v, c) => LabelLoad.Rotation = 0,
                        () => true);

                    await LabelLoad.ScaleTo(2.0, 1000, Easing.BounceIn);
                    await LabelLoad.FadeTo(0, 1000, Easing.Linear);
                    await LabelLoad.FadeTo(1, 1000, Easing.Linear);
                    await LabelLoad.ScaleTo(1.0, 1000, Easing.BounceOut);
                    
                    
                }
                else
                {
                    //stop
                    this.AbortAnimation("rotate");
                }
            }
        }
    }
}