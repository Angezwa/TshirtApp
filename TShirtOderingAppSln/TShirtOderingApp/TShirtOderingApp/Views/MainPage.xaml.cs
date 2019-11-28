using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtOderingApp.Views;
using Xamarin.Essentials;
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

            var location = tees.Address;
            var myadd = "bellville cape town";
            var locate = await Geocoding.GetLocationsAsync(myadd);
            var finalLocate = locate?.FirstOrDefault();


            var addPos = string.Empty;

            if (finalLocate != null)
            {
                addPos = $"Latitude: {finalLocate.Latitude}, Longitude: {finalLocate.Longitude}";
            }


            tees.AddressPosition = addPos;

            await App.Database.SaveItemAsync(tees);
            await Navigation.PushAsync(new TeeListPage());
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
