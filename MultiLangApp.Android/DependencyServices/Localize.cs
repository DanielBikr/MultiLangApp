using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using MultiLangApp.Helpers;
using MultiLangApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(MultiLangApp.Droid.DependencyServices.Localize))]
namespace MultiLangApp.Droid.DependencyServices
{
    public class Localize : ILocalize
    {
        public Task SetLocale(CultureInfo ci)
        {
            return Task.Run(() =>
            {
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            });
        }
        public CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentUICulture;
        }
        string AndroidToDotnetLanguage(string androidLanguage)
        {
            var netLanguage = androidLanguage;
            //certain languages need to be converted to CultureInfo equivalent
            switch (androidLanguage)
            {
                case "en-US":  // "Indonesian (Indonesia)" has different code in  .NET
                    netLanguage = "en-US"; // correct code for .NET
                    break;
                case "nl-NL":  // "Schwiizertüütsch (Swiss German)" not supported .NET culture
                    netLanguage = "nl-NL"; // closest supported
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }
            return netLanguage;
        }
        string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            var netLanguage = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);
            switch (platCulture.LanguageCode)
            {
                default:
                    netLanguage = "en-US"; // equivalent to German (Switzerland) for this app
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }
            return netLanguage;
        }
    }
}