using MultiLangApp.Interfaces;
using MultiLangApp.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultiLangApp.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private string age = AppResources.Label_Age;
        public string Age
        {
            get => age;
            set
            {
                age = value;
            }
        }


        private string address = AppResources.Label_Address;
        public string Address
        {
            get => address;
            set
            {
                address = value;
            }
        }

        private bool isDefaultLang = true;
        private bool isLangNL = true;
        public bool IsLangNL
        {
            get => isLangNL;
            set
            {
                isLangNL = value;
                if (!isDefaultLang)
                    ToggleLocale();
                else
                    isDefaultLang = false;
            }
        }

        private CultureInfo CurrentCulture { get; set; }
        private CultureInfo Dutch = new CultureInfo("nl-NL");
        private CultureInfo English = new CultureInfo("en-US");
        public void ToggleLocale()
        {
            CurrentCulture = (CurrentCulture.Name == English.Name) ? Dutch : English;

            AppResources.Culture = CurrentCulture;

            Address = AppResources.Label_Address;
            OnPropertyChanged(nameof(Address));
            Age = AppResources.Label_Age;
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(isLangNL));
        }

        public MainPageViewModel()
        {
            CurrentCulture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }
    }
}
