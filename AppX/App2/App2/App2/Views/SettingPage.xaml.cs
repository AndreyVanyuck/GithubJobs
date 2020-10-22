using App2.Models;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public ObservableCollection<Language> Languages { get; }
        public SettingPage()
        {
            InitializeComponent();
            Languages = new ObservableCollection<Language>()
            {
                new Language { DisplayName =  "English", ShortName = "en" },
                new Language { DisplayName =  "Русский - Russian", ShortName = "ru" }
            };
            BindingContext = this;

            PickerLanguages.SelectedIndexChanged += PickerLanguages_SelectedIndexChanged;
        }
        private void PickerLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var language = Languages[PickerLanguages.SelectedIndex];

            try
            {
                var culture = new CultureInfo(language.ShortName);
                Resource.Culture = culture;
                CrossMultilingual.Current.CurrentCultureInfo = culture;
            }
            catch (Exception)
            {
            }

            object shortName = language.ShortName;
            if (App.Current.Properties.TryGetValue("language", out shortName))
            {
                App.Current.Properties["language"] = language.ShortName;
            }

            LabelLanguage.Text = Resource.Language;
            MessagingCenter.Send<Page>(this, "LocalicationWasChanged");

        }

    }
}