using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TShirtOderingApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var tees = new Tees();
            BindingContext = tees;
        }

        private async void Button_Save(object sender, EventArgs e)
        {
            var tees = (Tees)BindingContext;
            await App.Database.SaveItemAsync(tees);
            await Navigation.PopAsync();
        }

        private async void Button_Delete(object sender, EventArgs e)
        {
            var tees = (Tees)BindingContext;
            await App.Database.DeleteItemAsync(tees);
            await Navigation.PopAsync();
        }

        private async void Button_Cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
