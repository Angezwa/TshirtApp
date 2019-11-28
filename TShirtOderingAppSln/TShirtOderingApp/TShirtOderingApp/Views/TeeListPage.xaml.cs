using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeeListPage : ContentPage
    {

        public List<Tees> Tees { get; set; }


        public TeeListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Tees = await App.Database.GetItemsAsync();

            BindingContext = this;

        }

        private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
            // Navigate  MainPage
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)

            {
                await Navigation.PushAsync(new MainPage
                {
                    BindingContext = e.SelectedItem as Tees
                });
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var something = await DisplayAlert("Hellow Customer", "Are you sure you want to Delete?", "Yes", "No");

            if (something)
            {
                var MyTappedItem = e.Item as Tees;
                await App.Database.DeleteItemAsync(MyTappedItem);

                await Navigation.PushAsync(new TeeListPage());
            } 
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var databaseContent = App.Database;
            Tees = await databaseContent.GetItemsAsync();
            var MyServerOrders = Tees.Select(x => new Tees()
            {
                Name = x.Name,
                Gender = x.Gender,
                Size = x.Size,
                Date = x.Date,
                Color = x.Color,
                Address = x.Address
            });
            var json = JsonConvert.SerializeObject(MyServerOrders);
            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/tees";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                await DisplayAlert("Response", response.ReasonPhrase, "ok");

            //await Navigation.PushAsync(new SendToServer());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                await DisplayAlert("internet", "all good", "ok");
            }

            if (current != NetworkAccess.Internet)
            {
                // Connection to internet is available
                await DisplayAlert("internet", "no internet", "ok");
            }


            var location = new Xamarin.Essentials.Location(45.345535, -156.777399);
            var options = new MapLaunchOptions { Name = "Angezwa" };

            await Map.OpenAsync(location, options);

        }


     
    }
}

