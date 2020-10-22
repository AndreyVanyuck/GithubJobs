using App2.Models;
using App2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsDetailPageViewModel itemsDetailPageViewModel;
        public ItemsPage()
        {
            InitializeComponent();
            itemsDetailPageViewModel = new ItemsDetailPageViewModel();
            this.BindingContext = itemsDetailPageViewModel;
            Subcribe();
        }
        public ItemsPage(string url)
        {
            InitializeComponent();
            itemsDetailPageViewModel = new ItemsDetailPageViewModel(url);
            this.BindingContext = itemsDetailPageViewModel;
            Subcribe();  
        }

        private void Subcribe()
        {
            MessagingCenter.Subscribe<Page, string>(this, "ButtonSearchIsClicked", (sender, arg) =>
            {
                itemsDetailPageViewModel = new ItemsDetailPageViewModel(arg);
                ItemsListView.ItemsSource = null;
                ItemsListView.ItemsSource = itemsDetailPageViewModel.Jobs;
            });
            if(itemsDetailPageViewModel.Jobs.Count < 50)
            {
            //    Button123.Text = "fff";
            }
        }
        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as JobOffer; 
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemsDetailPageViewModel(item)));
            ItemsListView.SelectedItem = null;
        }
        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("","is clicked","cancel");
            var jobOffer = (sender as Image).BindingContext as JobOffer;

            
        }
    }
}