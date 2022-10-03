using MyCoffeeApp3.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyCoffeeApp3.Cells
{
    public class CoffeeDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Normal { get; set; }
        public DataTemplate Special { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var coffee = (Coffee)item;

            return coffee.Roaster == "Yes Plz" ? Normal : Normal;
        }
    }
}
