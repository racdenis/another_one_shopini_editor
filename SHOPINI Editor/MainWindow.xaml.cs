using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace SHOPINI_Editor
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public static readonly RoutedCommand SaveShopCommand = new RoutedCommand();

        void SaveShopCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void SaveShopCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveShopAction();
        }

        string[] shopini_classnames = new string[] { };
        int[] shopini_levels = new int[] { };
        float[] shopini_prices = new float[] { };

        bool iteminfo_found = false;

        public string formatstring = "{3}. Item: {0,-80} Level: {1,-15} Price: {2,-15}";

        public string shopini_string = "";

        public string shopini_filepath = "";

        string classname_actual = "";
        string realname_actual = "";

        bool classname_fireblank = false;
        bool realname_fireblank = false;

        string parsing_text = "";
        int dict_count = 0;
        public static Dictionary<int, string> item_dictionary = new Dictionary<int, string>();
        public static Dictionary<int, string> item_classnames = new Dictionary<int, string>();

        string[] iteminfo_classname_array = new string[] { };
        string[] iteminfo_realname_array = new string[] { };

        Encoding win1251 = Encoding.GetEncoding("windows-1251");
        //FileSystemWatcher gospodin_parser = new FileSystemWatcher();

        string changesnotsaved = "";


        private void FileWasChanged()
        {
            AppMainWindow.Title = Properties.Resources.main_form + " " + changesnotsaved + " " + shopini_filepath;
        }
        private void LoadShopiniFile(string path)
        {
            //gospodin_parser.Path = "ITEMINFO";
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(path, win1251))
                {
                    // Read the stream as a string, and write the string to the console.
                    //Console.WriteLine(sr.ReadToEnd());
                    //ListBoxMain1.Items.Add(sr.ReadToEnd());
                    shopini_string = (sr.ReadToEnd());
                    //Console.WriteLine(parsing_text);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("SHOPINI error!");
                Console.WriteLine(e.Message);
            }
        }
        private void ParseIteminfoFile()
        {
            //gospodin_parser.Path = "ITEMINFO";
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("ITEMINFO", win1251))
                {
                    // Read the stream as a string, and write the string to the console.
                    //Console.WriteLine(sr.ReadToEnd());
                    //ListBoxMain1.Items.Add(sr.ReadToEnd());
                    parsing_text = (sr.ReadToEnd());
                    //Console.WriteLine(parsing_text);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("ITEMINFO error!");
                Console.WriteLine(e.Message);
            }
        }
        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            InitializeComponent();

            ParseIteminfoFile();

            if (parsing_text.Length > 0)
            {

                Boolean parsing_in_process = true;
                int tempindex1 = 0;
                int tempindex2 = 0;
                string tempclassname = "";
                string temprealname = "";

                while (parsing_in_process)
                {
                    tempindex1 = parsing_text.IndexOf("\"") + 1;
                    tempindex2 = parsing_text.IndexOf("\"", tempindex1);
                    tempclassname = parsing_text.Substring(tempindex1, tempindex2 - tempindex1);
                    tempindex1 = parsing_text.IndexOf("\"", tempindex2 + 1) + 1;
                    tempindex2 = parsing_text.IndexOf("\"", tempindex1);
                    temprealname = parsing_text.Substring(tempindex1, tempindex2 - tempindex1);
                    item_dictionary[dict_count] = temprealname;
                    item_classnames[dict_count] = tempclassname;
                    iteminfo_classname_array = iteminfo_classname_array.Append(tempclassname).ToArray();
                    iteminfo_realname_array = iteminfo_realname_array.Append(temprealname).ToArray();
                    dict_count++;
                    //ClassnameComboBox.Items.Add(tempclassname);
                    //RealNameComboBox.Items.Add(temprealname);
                    //ListBoxMain1.Items.Add(tempclassname);
                    //ListBoxMain1.Items.Add(temprealname);
                    //Console.WriteLine(tempclassname);
                    tempindex1 = parsing_text.IndexOf("\nITEM", tempindex2);
                    if (tempindex1 < 0)
                    {
                        parsing_in_process = false;
                    }
                    else
                    {
                        parsing_text = parsing_text.Substring(tempindex1);
                    };
                };

                //ClassnameComboBox.ItemsSource = iteminfo_classname_array.ToList();
                //RealNameComboBox.ItemsSource = iteminfo_realname_array.ToList();
                ITEMINFO_label.Content = Properties.Resources.iteminfo_ok;
                iteminfo_found = true;

            }
        }
        private void ChangeCulture(string cultureKey)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureKey);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                // That culture probably doesn't exist
            }
        }
        public static List<T> GetVisualChildCollection<T>(object parent) where T : Visual
        {
            List<T> visualCollection = new List<T>();
            GetVisualChildCollection(parent as DependencyObject, visualCollection);
            return visualCollection;
        }
        private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : Visual
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ChangeCulture("en-US");
            WPFPidorasEnabiySukaBlyadRefreshLocalizationYouStupidDegeneratePieceOfControlSeekerShitWhyCantYouIterateControlsYouFreakGoFuckYourself();
        }

        /*private void IterateControlsLang()
        {
            foreach (Control form_control in MainWindow.GetVisualChildCollection)
            {

            }
        }*/
        private void WPFPidorasEnabiySukaBlyadRefreshLocalizationYouStupidDegeneratePieceOfControlSeekerShitWhyCantYouIterateControlsYouFreakGoFuckYourself()
        {
            //user: please, refresh controls' textes by reloading their resources! i want to make my application availible to people of other cultures!
            //WPF: what did you say? uh-huh? i prefer to suck cocks! go bother someone another!

            //so we just brute-force it

            AppMainWindow.Title = Properties.Resources.main_form + " " + changesnotsaved + " " + shopini_filepath;

            if (iteminfo_found)
            {
                ITEMINFO_label.Content = Properties.Resources.iteminfo_ok;
            }
            else
            {
                ITEMINFO_label.Content = Properties.Resources.iteminfo_not_ok;
            }

            Label_rusname.Content = Properties.Resources.shopname_text_ru;
            Label_engname.Content = Properties.Resources.shopname_text_en;
            Label_engname.ToolTip = Properties.Resources.eng_version_mark;
            Label_typetext.Content = Properties.Resources.type_text;
            Label_pricecoeff.Content = Properties.Resources.pricecoeff_text;

            Label_itemtext.Content = Properties.Resources.item_text;
            Label_leveltext.Content = Properties.Resources.level_text;
            Label_pricetext.Content = Properties.Resources.price_text;

            Predmetlabel.Content = Properties.Resources.item_text;
            Levellabel.Content = Properties.Resources.level_text;
            Pricelabel.Content = Properties.Resources.price_text;

            ButtonApplyChange.Content = Properties.Resources.apply_change;
            ButtonAddLine.Content = Properties.Resources.add_new;

            MenuItem_file.Header = Properties.Resources.file;
            MenuItem_createshop.Header = Properties.Resources.create_shop;
            MenuItem_openshop.Header = Properties.Resources.open_shop;
            MenuItem_saveshop.Header = Properties.Resources.save_shop;
            MenuItem_saveshopas.Header = Properties.Resources.save_shop_as;

            MenuItemHelp.Header = Properties.Resources.help_menuitem;

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ChangeCulture("ru-RU");
            WPFPidorasEnabiySukaBlyadRefreshLocalizationYouStupidDegeneratePieceOfControlSeekerShitWhyCantYouIterateControlsYouFreakGoFuckYourself();

        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ClearShopiniData()
        {
            Array.Resize(ref shopini_classnames,0);
            Array.Resize(ref shopini_levels, 0);
            Array.Resize(ref shopini_prices, 0);

            TextBoxShopnameRus.Text = "Тест";
            TextBoxShopnameEng.Text = "Test";
            TextBoxPriceCoeff.Text = "0";
            TypeComboBox.SelectedIndex = 0;
            ListBoxMain1.Items.Clear();
            shopini_filepath = "";

            changesnotsaved = "";
            FileWasChanged();

        }

        private MessageBoxResult YesNoCancelBox(string sMessageBoxText, string sCaption)
        {
            MessageBoxButton btnMessageBox = MessageBoxButton.OKCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult returnmessage = System.Windows.MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return returnmessage;
        }
        private void CreateShop(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rsltMessageBox = YesNoCancelBox(Properties.Resources.clear_all_data, Properties.Resources.main_form);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.OK:
                    ClearShopiniData();
                    break;
                case MessageBoxResult.No:
                    /* ... */
                    break;
                case MessageBoxResult.Cancel:
                    /* ... */
                    break;
            }
        }

        private void ParseEngVersion(string filepath)
        {
            //gospodin_parser.Path = "ITEMINFO";
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(filepath, win1251))
                {
                    // Read the stream as a string, and write the string to the console.
                    //Console.WriteLine(sr.ReadToEnd());
                    //ListBoxMain1.Items.Add(sr.ReadToEnd());
                    string shopinieng_string = (sr.ReadToEnd());
                    //Console.WriteLine(parsing_text);

                    int tempindex1 = 0;
                    int tempindex2 = 0;

                    tempindex1 = shopinieng_string.IndexOf("\"") + 1;
                    tempindex2 = shopinieng_string.IndexOf("\"", tempindex1);
                    TextBoxShopnameEng.Text = shopinieng_string.Substring(tempindex1, tempindex2 - tempindex1);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("SHOPINI error!");
                Console.WriteLine(e.Message);
            }
        }
        private void ParseOpenedShopini()
        {
            Boolean parsing_in_process = true;
            int tempindex1 = 0;
            int tempindex2 = 0;
            string tempclassname = "";
            int templevel = 1;
            float tempprice = 0;

            char[] numberchars = new char[] {'0','1','2','3','4','5','6','7','8','9'};
            
            tempindex1 = shopini_string.IndexOf("\"") + 1;
            tempindex2 = shopini_string.IndexOf("\"", tempindex1);
            TextBoxShopnameRus.Text = shopini_string.Substring(tempindex1, tempindex2 - tempindex1);
            //TextBoxShopnameEng.Text = shopini_string.Substring(tempindex1, tempindex2 - tempindex1);
            tempindex1 = shopini_string.IndexOf("\nType", tempindex2+1)+1;
            tempindex1 = shopini_string.IndexOfAny(numberchars, tempindex1);
            int shoptype = 0;
            Int32.TryParse(shopini_string.Substring(tempindex1, 1), out shoptype);
            TypeComboBox.SelectedIndex = shoptype;
            if (shoptype!=1)
            {
                tempindex1 = shopini_string.IndexOf("\nPriceCoeff", tempindex2 + 1) + 1;
                tempindex1 = shopini_string.IndexOfAny(numberchars, tempindex1);
                tempindex2 = shopini_string.IndexOf("\n", tempindex1);
                TextBoxPriceCoeff.Text = shopini_string.Substring(tempindex1, tempindex2 - tempindex1);
            }
            else
            {
                TextBoxPriceCoeff.Text = "0";
            };

            tempindex1 = shopini_string.IndexOf("\nItem");

            if (tempindex1 < 0)
            {
                return;
            }

            shopini_string = shopini_string.Substring(tempindex1);


            while (parsing_in_process)
            {
                tempindex1 = shopini_string.IndexOf("\"") + 1;
                tempindex2 = shopini_string.IndexOf("\"", tempindex1);
                tempclassname = shopini_string.Substring(tempindex1, tempindex2 - tempindex1);

                shopini_classnames = shopini_classnames.Append(tempclassname).ToArray(); //classname

                if (shoptype!=1)
                {
                    tempindex1 = shopini_string.IndexOfAny(numberchars, tempindex2);
                    tempindex2 = shopini_string.IndexOf("Price", tempindex1);
                    Int32.TryParse(shopini_string.Substring(tempindex1, tempindex2 - tempindex1), out templevel); //level

                    tempindex1 = shopini_string.IndexOfAny(numberchars, tempindex2);
                    tempindex2 = shopini_string.IndexOf("\n", tempindex1);
                    float.TryParse(shopini_string.Substring(tempindex1, tempindex2 - tempindex1), out tempprice); //price

                }
                else
                {

                }

                shopini_levels = shopini_levels.Append(templevel).ToArray();
                shopini_prices = shopini_prices.Append(tempprice).ToArray();

                ListBoxMain1.Items.Add(String.Format(formatstring, tempclassname, templevel, tempprice, shopini_classnames.Count() - 1));

                tempindex1 = shopini_string.IndexOf("\nItem", tempindex2);
                if (tempindex1 < 0)
                {
                    parsing_in_process = false;
                }
                else
                {
                    shopini_string = shopini_string.Substring(tempindex1);
                };
            };

            AppMainWindow.Title = Properties.Resources.main_form + " " + changesnotsaved + " " + shopini_filepath;
        }
        private void OpenShopAction()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".ini";
            dlg.Filter = "ini files (*.ini)|*.ini|All files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                //if (shopini_filepath!=filename)
                //if (true)
                //{
                    //ClearShopiniData();
                //};
                ClearShopiniData();

                shopini_filepath = filename;
                LoadShopiniFile(shopini_filepath);
                ParseOpenedShopini();

                string name = Path.GetFileName(filename);
                string directory = System.IO.Directory.GetParent(filename).FullName + "/SHOPINI_ENG/";

                if (File.Exists(directory+name))
                {
                    Label_engname.IsChecked = true;
                    ParseEngVersion(directory+name);
                }

                changesnotsaved = "";
                FileWasChanged();


            }

        }
        private void OpenShop(object sender, RoutedEventArgs e)
        {
            if (shopini_classnames.Length > 0)
            {
                MessageBoxResult rsltMessageBox = YesNoCancelBox(Properties.Resources.clear_all_data, Properties.Resources.main_form);
                switch (rsltMessageBox)
                {
                    case MessageBoxResult.OK:
                        OpenShopAction();
                        break;
                    case MessageBoxResult.No:
                        /* ... */
                        break;
                    case MessageBoxResult.Cancel:
                        /* ... */
                        break;
                }
            }
            else
            {
                OpenShopAction();
            }

        }

        private void ShopiniWriteFile(string filepath, bool english)
        {
            string shopnamewrite = TextBoxShopnameRus.Text;

            if (english)
            {
                shopnamewrite = TextBoxShopnameEng.Text;
            }

            try
            {
                File.WriteAllText(filepath, "");
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(filepath, true, win1251);
                //Write a line of text
                //sw.WriteLine("Hello World!!");
                //Write a second line of text
                //sw.WriteLine("From the StreamWriter class");
                //Close the file


                sw.WriteLine("Name  \"" + shopnamewrite + "\"");

                sw.WriteLine("Type  " + TypeComboBox.SelectedIndex);

                string write_format = "Item  \"{0}\"";

                if (TypeComboBox.SelectedIndex != 1)
                {
                    sw.WriteLine("PriceCoeff  " + TextBoxPriceCoeff.Text + "\n");
                    write_format = "Item  \"{0}\"  Level  {1}  Price  {2}";
                }
                else
                {
                    sw.WriteLine("");
                }

                int i = 0;

                foreach (string item in shopini_classnames)
                {
                    sw.WriteLine(String.Format(write_format, item, shopini_levels[i], shopini_prices[i]));
                    i++;
                }

                sw.WriteLine("END");

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void SaveFileInPath(string filename)
        {
            shopini_filepath = filename;
            ShopiniWriteFile(filename, false);
            if ((bool)Label_engname.IsChecked)
            {
                //filename = System.IO.Directory.GetName

                string name = Path.GetFileName(filename);
                string directory = System.IO.Directory.GetParent(filename).FullName + "/SHOPINI_ENG/";

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                ShopiniWriteFile(directory + name, true);
            }
            changesnotsaved = "";
            FileWasChanged();
        }


        private void SaveShopAction()
        {
            if (shopini_filepath == "")
            {
                SaveShopAsOpenDialog();
            }
            else
            {
                SaveFileInPath(shopini_filepath);
            }
        }
        private void SaveShop(object sender, RoutedEventArgs e)
        {
            SaveShopAction();
        }

        private void SaveShopAsOpenDialog()
        {

            // Create OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".ini";
            dlg.Filter = "ini files (*.ini)|*.ini|All files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                bool commence = true;
                /*if (File.Exists(filename))
                {
                    MessageBoxResult rsltMessageBox = YesNoCancelBox(Properties.Resources.replace_file_ask, Properties.Resources.main_form);
                    switch (rsltMessageBox)
                    {
                        case MessageBoxResult.OK:
                            commence = true;
                            break;
                    }
                }
                else
                {
                    commence = true;
                }*/

                if (commence)
                {
                    SaveFileInPath(filename);
                    /*ShopiniWriteFile(filename, false);
                    if ((bool)Label_engname.IsChecked)
                    {

                        string name = Path.GetFileName(filename);
                        string directory = System.IO.Directory.GetParent(filename).FullName + "/SHOPINI_ENG/";

                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        ShopiniWriteFile(directory + name, true);
                    }*/
                }
            }
        }
        private void SaveShopAs(object sender, RoutedEventArgs e)
        {
            SaveShopAsOpenDialog();
        }
        private void listBox_ScrollChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void AppMainWindow_Closed(object sender, EventArgs e)
        {
            SHOPINI_Editor.App.Current.Shutdown();
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            EnterPressedAddOrChange(true); //добавляем в любом случае
        }

        private void RealNameComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                int index = Array.IndexOf(iteminfo_realname_array, e.AddedItems[0]);
                if (index > -1)
                {
                    ClassnameComboBox.Text = iteminfo_classname_array[index];
                }
            }

        }

        private void ClassnameComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                int index = Array.IndexOf(iteminfo_classname_array, e.AddedItems[0]);
                if (index > -1)
                {
                    RealNameComboBox.Text = iteminfo_realname_array[index];
                }
            }

        }

        private void ListBoxMain1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void EnterPressedAddOrChange(bool add)
        {
            string classname = ClassnameComboBox.Text;
            int level = 1;
            float price = 0;
            Int32.TryParse(LevelTextBox.Text, out level);
            float.TryParse(PriceTextBox.Text, out price);
            if (add)
            {
                if (!((ClassnameComboBox.Text == "...") || (LevelTextBox.Text == "...") || (PriceTextBox.Text == "...")))
                {

                    if ((shopini_classnames.Contains(classname)) && (TypeComboBox.SelectedIndex != 1))
                    {
                        MessageBoxResult rsltMessageBox = YesNoCancelBox(Properties.Resources.replace_string_or_not, Properties.Resources.main_form);
                        switch (rsltMessageBox)
                        {
                            case MessageBoxResult.OK:
                                int index = Array.IndexOf(shopini_classnames, classname);
                                ListBoxMain1.Items[index] = (String.Format(formatstring, ClassnameComboBox.Text, LevelTextBox.Text, PriceTextBox.Text, index));
                                shopini_classnames[index] = classname;
                                shopini_levels[index] = level;
                                shopini_prices[index] = price;
                                ListBoxKeepSelection(index);
                                changesnotsaved = "*";
                                FileWasChanged();
                                break;
                            case MessageBoxResult.No:
                                /* ... */
                                break;
                            case MessageBoxResult.Cancel:
                                /* ... */
                                break;
                        }
                    }
                    else
                    {
                        shopini_classnames = shopini_classnames.Append(classname).ToArray();
                        ListBoxMain1.Items.Add(String.Format(formatstring, ClassnameComboBox.Text, LevelTextBox.Text, PriceTextBox.Text, shopini_classnames.Count() - 1));
                        shopini_levels = shopini_levels.Append(level).ToArray();
                        shopini_prices = shopini_prices.Append(price).ToArray();
                        changesnotsaved = "*";
                        FileWasChanged();
                    }
                }
            }
            else
            {
                bool force_classname = true;
                bool force_level = true;
                bool force_price = true;

                if (ClassnameComboBox.Text == "...")
                {
                    force_classname = false;
                }
                if (LevelTextBox.Text == "...")
                {
                    force_level = false;
                }
                if (PriceTextBox.Text == "...")
                {
                    force_price = false;
                }

                int[] selected_indexes = new int[] { };

                foreach (string item in ListBoxMain1.SelectedItems)
                {
                    selected_indexes = selected_indexes.Append(ListBoxMain1.Items.IndexOf(item)).ToArray();
                }

                foreach (int item_index in selected_indexes)
                {
                    if (force_classname)
                    {
                        shopini_classnames[item_index] = classname;
                    }
                    if (force_level)
                    {
                        shopini_levels[item_index] = level;
                    }
                    if (force_price)
                    {
                        shopini_prices[item_index] = price;
                    }
                    ListBoxMain1.Items[item_index] = (String.Format(formatstring, shopini_classnames[item_index], shopini_levels[item_index], shopini_prices[item_index], item_index));
                }

                changesnotsaved = "*";
                FileWasChanged();
                /*
                foreach (int lbindex in ListBoxMain1.Items)
                {
                    ListBoxMain1.Items[lbindex] = (String.Format(formatstring, shopini_classnames[lbindex], shopini_levels[lbindex], shopini_prices[lbindex], lbindex));
                }
                */

            }
        }
        private void ClassnameComboBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
            {
                /*Console.WriteLine("searching");
                string[] found = new string[] { };

                int found_index = -1;

                found = iteminfo_classname_array.Where(p => ClassnameComboBox.Text.ToLower().Contains(p.ToLower())).ToArray();


                if (found.Count() == 1)
                {
                    found_index = Array.IndexOf(iteminfo_classname_array, found[0]);
                    ClassnameComboBox.SelectedIndex = found_index;
                    ClassnameComboBox.Text = found[0];
                }*/

                //ITEMINFO_label.Content = ClassnameComboBox.Text;

                return;
            }
            // your event handler here
            e.Handled = true;
            EnterPressedAddOrChange(true);
        }

        private void RealNameComboBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
            {

                /*Console.WriteLine("searching");
                string[] found = new string[] { };

                int found_index = -1;

                found = iteminfo_realname_array.Where(p => RealNameComboBox.Text.ToLower().Contains(p.ToLower())).ToArray();


                if (found.Count() == 1)
                {
                    found_index = Array.IndexOf(iteminfo_realname_array, found[0]);
                    RealNameComboBox.SelectedIndex = found_index;
                    RealNameComboBox.Text = found[0];

                }*/

                return;
            }
            // your event handler here
            e.Handled = true;
            EnterPressedAddOrChange(true);
        }

        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            // your event handler here
            e.Handled = true;
            EnterPressedAddOrChange(true);

        }

        private void TextBox_KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            // your event handler here
            e.Handled = true;
            EnterPressedAddOrChange(true);

        }

        private void TypeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ListBoxMain1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if ((ListBoxMain1.SelectedIndex>-1) && (shopini_classnames.Length-1>= ListBoxMain1.SelectedIndex))
            {
                ButtonApplyChange.IsEnabled = true;
                ClassnameComboBox.Text = shopini_classnames[ListBoxMain1.SelectedIndex];
                realname_fireblank = true;
                PriceTextBox.Text = shopini_prices[ListBoxMain1.SelectedIndex].ToString();
                LevelTextBox.Text = shopini_levels[ListBoxMain1.SelectedIndex].ToString();
            }
            else
            {
                ButtonApplyChange.IsEnabled = false;
            }

            if (ListBoxMain1.SelectedItems.Count > 1)
            {
                int[] selected_indexes = new int[] { };

                foreach (string item in ListBoxMain1.SelectedItems)
                {
                    selected_indexes = selected_indexes.Append(ListBoxMain1.Items.IndexOf(item)).ToArray();
                }

                bool identical_items = true;
                bool identical_levels = true;
                bool identical_prices = true;

                foreach (int index in selected_indexes)
                {
                    if (index < shopini_classnames.Count())
                    {
                        if (shopini_classnames[selected_indexes[0]] != shopini_classnames[index]) //TODO if null
                        {
                            identical_items = false;
                        }
                        if (shopini_levels[selected_indexes[0]] != shopini_levels[index])
                        {
                            identical_levels = false;
                        }
                        if (shopini_prices[selected_indexes[0]] != shopini_prices[index])
                        {
                            identical_prices = false;
                        }
                    }
                }

                if (!identical_items)
                {
                    classname_fireblank = true;
                    realname_fireblank = true;
                    ClassnameComboBox.Text = "...";
                    RealNameComboBox.Text = "...";
                }

                if (!identical_levels)
                {
                    LevelTextBox.Text = "...";
                }

                if (!identical_prices)
                {
                    PriceTextBox.Text = "...";
                }

                classname_fireblank = false;
                realname_fireblank = false;

                /*
                bool identical_items = true;
                foreach (string item in ListBoxMain1.SelectedItems)
                {
                    if (item != ListBoxMain1.SelectedItems[0])
                    {
                        identical_items = false;
                    }
                }

                if (!identical_items)
                {
                    ClassnameComboBox.Text = "...";
                    RealNameComboBox.Text = "...";
                }*/


            }
            //foreach (var item in shopini_classnames)
            //{
                //Console.WriteLine(item);
            //}
        }

        private void ButtonApplyChange_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxMain1.SelectedIndex >= 0)
            {
                EnterPressedAddOrChange(false);
            }
        }

        private void ListBoxKeepSelection(int index)
        {
            if ((index+1)<=(ListBoxMain1.Items.Count))
            {
                ListBoxMain1.SelectedIndex = index;
            }

        }
        private void DeleteSelectedShopiniItemMultiple()
        {
            if (true)
            {
                int[] selected_indexes = new int[] { };
                string[] objects_to_remove = new string[] { };

                foreach (string item in ListBoxMain1.SelectedItems)
                {
                    selected_indexes = selected_indexes.Append(ListBoxMain1.Items.IndexOf(item)).ToArray();
                    objects_to_remove = objects_to_remove.Append(item).ToArray();
                }

                shopini_classnames = shopini_classnames.Where((val, idx) => (!(selected_indexes.Contains(idx)))).ToArray();
                shopini_levels = shopini_levels.Where((val, idx) => (!(selected_indexes.Contains(idx)))).ToArray();
                shopini_prices = shopini_prices.Where((val, idx) => (!(selected_indexes.Contains(idx)))).ToArray();

                foreach (string item in objects_to_remove)
                {
                    ListBoxMain1.Items.Remove(item);
                }

                for (int i = 0; i < (ListBoxMain1.Items.Count); i++)
                {
                    ListBoxMain1.Items[i] = String.Format(formatstring, shopini_classnames[i], shopini_levels[i], shopini_prices[i], i);
                }

                changesnotsaved = "*";
                FileWasChanged();


            }

        }
        private void DeleteSelectedShopiniItemOne()
        {
            int index = ListBoxMain1.SelectedIndex;
            shopini_classnames = shopini_classnames.Where((val, idx) => idx != index).ToArray();
            shopini_levels = shopini_levels.Where((val, idx) => idx != index).ToArray();
            shopini_prices = shopini_prices.Where((val, idx) => idx != index).ToArray();
            ListBoxMain1.Items.RemoveAt(index);

            for (int i = 0; i < (ListBoxMain1.Items.Count); i++)
            {
                ListBoxMain1.Items[i] = (String.Format(formatstring, shopini_classnames[i], shopini_levels[i], shopini_prices[i], i));
            }

            ListBoxKeepSelection(index);

            changesnotsaved = "*";
            FileWasChanged();

        }

        private void ListBoxMain1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            /*List<int> list = new List<int>();
            foreach (var item in listBox1.SelectedItems)
            {
                list.Add(listBox1.Items.IndexOf(item));// Add selected indexes to the List<int>
            }*/


            if ((ListBoxMain1.SelectedIndex>-1))
            {
                if (e.Key != System.Windows.Input.Key.Delete) return;
                // your event handler here
                e.Handled = true;
                if (ListBoxMain1.SelectedItems.Count == 1)
                {
                    DeleteSelectedShopiniItemOne();
                }
                else
                {
                    DeleteSelectedShopiniItemMultiple();
                }
            }
        }


        private void RealNameComboBox_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            //RealNameComboBox.IsDropDownOpen = true;
            //RealNameComboBox.ItemsSource = iteminfo_realname_array.Where(p => p.Contains(e.Text)).ToList();
        }

        private void ClassnameComboBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            //ClassnameComboBox.IsDropDownOpen = true;
            //ClassnameComboBox.ItemsSource = iteminfo_classname_array.Where(p => p.Contains(ClassnameComboBox.Text)).ToList();
        }

        private void ClassnameComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ClassnameComboBox.IsDropDownOpen = true;
        }

        private void StealthClassnameComboBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!(ClassnameComboBox.Text == classname_actual) && !classname_fireblank)
            {
                if (ClassnameComboBox.IsDropDownOpen == false && ClassnameComboBox.IsFocused)
                {
                    ClassnameComboBox.IsDropDownOpen = true;
                }

                if (ClassnameComboBox.Text.Length >= 2)
                {
                    ClassnameComboBox.ItemsSource = iteminfo_classname_array.Where(p => p.ToLower().Contains(StealthClassnameComboBox.Text.ToLower())).ToList();
                }
                else
                {
                    ClassnameComboBox.ItemsSource = null;
                }

                classname_actual = StealthClassnameComboBox.Text;

                //if (ClassnameComboBox.IsFocused)
                if (true)
                {

                    int index = Array.IndexOf(iteminfo_classname_array, ClassnameComboBox.Text);
                    if (index > -1)
                    {
                        RealNameComboBox.Text = iteminfo_realname_array[index];
                    }
                    else
                    {
                        realname_fireblank = true;
                        RealNameComboBox.Text = "";
                        StealthRealnameComboBox.Text = "";
                    }
                }

                realname_fireblank = false;
            }

            /*if (classname_fireblank)
            {
                classname_fireblank = false;
            }*/

            /*ITEMINFO_label.Content = ClassnameComboBox.Text;

            Console.WriteLine("searching");
            string[] found = new string[] { };

            int found_index = -1;

            found = iteminfo_classname_array.Where(p => ClassnameComboBox.Text.ToLower().Contains(p.ToLower())).ToArray();


            if (found.Count() == 1)
            {
                found_index = Array.IndexOf(iteminfo_classname_array, found[0]);
                ClassnameComboBox.SelectedIndex = found_index;
                ClassnameComboBox.Text = found[0];

            }*/
        }

        private void StealthRealnameComboBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

            if (!(RealNameComboBox.Text == realname_actual) && !realname_fireblank)
            {

                if (RealNameComboBox.IsDropDownOpen == false && RealNameComboBox.IsFocused)
                {
                    RealNameComboBox.IsDropDownOpen = true;
                }

                if (RealNameComboBox.Text.Length >= 3)
                {
                    RealNameComboBox.ItemsSource = iteminfo_realname_array.Where(p => p.ToLower().Contains(StealthRealnameComboBox.Text.ToLower())).ToList();
                }
                else
                {
                    RealNameComboBox.ItemsSource = null;
                }

                realname_actual = StealthRealnameComboBox.Text;

                //if (RealNameComboBox.IsFocused)
                if (true)
                {
                    //ListBoxMain1.Items.Add("nigga");
                    int index = Array.IndexOf(iteminfo_realname_array, RealNameComboBox.Text);
                    if (index > -1)
                    {
                        ClassnameComboBox.Text = iteminfo_classname_array[index];
                    }
                    else
                    {
                        classname_fireblank = true;
                        ClassnameComboBox.Text = "";
                        StealthClassnameComboBox.Text = "";
                    }
                }

                classname_fireblank = false;
            }

            /*if (realname_fireblank)
            {
                realname_fireblank = false;
            }*/
        }

        private void RealNameComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            RealNameComboBox.IsDropDownOpen = true;
        }

        private void Label_engname_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxShopnameEng.IsEnabled = true;
        }

        private void Label_engname_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBoxShopnameEng.IsEnabled = false;
        }

        private void MenuItemHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btnMessageBox = MessageBoxButton.OK;
            MessageBoxImage icnMessageBox = MessageBoxImage.Information;

            string helptextformat = "{0}\n\n{1}\n\n{2}\n\n{3}\n\n{4}\n\n{5}";
            string helptext = String.Format(helptextformat, Properties.Resources.help_text_1, Properties.Resources.help_text_2, Properties.Resources.help_text_3, Properties.Resources.help_text_5, Properties.Resources.help_text_6, Properties.Resources.help_text_7);

            MessageBoxResult returnmessage = System.Windows.MessageBox.Show(helptext, Properties.Resources.main_form, btnMessageBox, icnMessageBox);
        }
    }
}
