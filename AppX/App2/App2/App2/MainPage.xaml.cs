using App2.MenuItems;
using App2.Views;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Subcribe();
        }

        protected override void OnAppearing()
        {
            object shortName = "";
            if (App.Current.Properties.TryGetValue("language", out shortName))
            {
                try
                {
                    var culture = new CultureInfo((string)shortName);
                    Resource.Culture = culture;
                    CrossMultilingual.Current.CurrentCultureInfo = culture;
                }
                catch (Exception)
                {
                }

                MessagingCenter.Send<Page>(this, "LocalicationWasChanged");
            }
            base.OnAppearing();
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        { 
            await Navigation.PushModalAsync(new SearchPage());
            IsPresented = false;
        }
        private void Subcribe()
        {
            MessagingCenter.Subscribe<Page>(this, "ClickedHome", (sender) =>
            {
                IsPresented = false;
            });
        }
    }
}
