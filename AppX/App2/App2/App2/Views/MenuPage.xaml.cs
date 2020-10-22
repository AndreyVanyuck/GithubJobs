using App2.MenuItems;
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
    public partial class MenuPage : ContentPage
    {
        public List<MasterDetailPageItem> menuList { get; set; }
        public MenuPage()
        {
            InitializeComponent();

            menuList = new List<MasterDetailPageItem>();

            menuList.Add(new MasterDetailPageItem() { Title = Resource.LabelHome, Icon = "home.png", Id = MenuItemType.Home});
            menuList.Add(new MasterDetailPageItem() { Title = Resource.LabelSettings, Icon = "settings.png", Id = MenuItemType.Setting });
            menuList.Add(new MasterDetailPageItem() { Title = Resource.LabelSaved, Icon = "saved.png", Id = MenuItemType.Saved });
            navigationDrawerList.ItemsSource = menuList;
            Subcribe();
        }


        private void Subcribe()
        {
            MessagingCenter.Subscribe<Page>(this, "LocalicationWasChanged", (sender) =>
            {
                menuList[0].Title = Resource.LabelHome;
                menuList[1].Title = Resource.LabelSettings;
                menuList[2].Title = Resource.LabelSaved;
                navigationDrawerList.ItemsSource = null;
                navigationDrawerList.ItemsSource = menuList;
            });
        }
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var id = (int)((MasterDetailPageItem)e.SelectedItem).Id;
            switch (id)
            {
                case (int)MenuItemType.Home:
                    // navigationDrawerList.SelectedItem = null;
                    MessagingCenter.Send<Page>(this, "ClickedHome");
                    break;
                case (int)MenuItemType.Setting:
                    await Navigation.PushModalAsync(new SettingPage(), true);
                    break;
                case (int)MenuItemType.Saved:
                    await Navigation.PushModalAsync(new SavedPage(), true);
                    break;
            }
            
        }
    }
}