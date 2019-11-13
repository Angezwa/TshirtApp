using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeeListPage : ContentPage
    {
        public List<Tees> TeesOrders { get; set; }

        public TeeListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            TeesOrders = await App.Database.GetItemsAsync();

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
    }
}