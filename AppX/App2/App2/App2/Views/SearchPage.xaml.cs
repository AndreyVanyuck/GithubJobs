using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string url = "https://jobs.github.com/positions.json?utf8=✓&description=" + EntryJobDescription.Text + "&location=" + EntryLocation.Text;
            if(CheckBox.IsChecked == true)
            {
                url = url + "&full_time=on";
            }

            // url = "https://jobs.github.com/positions.json?page=6";
            MessagingCenter.Send<Page, string>(this, "ButtonSearchIsClicked", url);
            await Navigation.PopModalAsync(true);
        }
    }
}