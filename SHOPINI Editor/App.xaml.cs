using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SHOPINI_Editor
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Key _SaveShopHotkey = System.Windows.Input.Key.S;  //Default Hotkey
        public Key SaveShopHotkey
        {
            get { return _SaveShopHotkey; }
            set { _SaveShopHotkey = value; }
        }
    }
}
