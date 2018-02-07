using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace MultiLangApp.Interfaces
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        Task SetLocale(CultureInfo ci);
    }
}
