using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TShirtOderingApp.Views
{
    class MainPageCS : ContentPage
    {
        public MainPageCS()
        {
            Title = "T-Shirt Ordering";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var tees = (Tees)BindingContext;
                await App.Database.SaveItemAsync(tees);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var tees = (Tees)BindingContext;
                await App.Database.DeleteItemAsync(tees);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "Done" },
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton,
                }
            };
        }
    }
}
