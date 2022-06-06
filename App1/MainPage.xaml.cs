using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace App1
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            pass.Password = "";
            pass.MaxLength = 4;
        }

        private async void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (pass.Password == "1234")
            {
                this.Frame.Navigate(typeof(BlankPage1));
            }
            else
            {
                string message = "Zły PIN!";
                MessageDialog msgdialog = new MessageDialog(message);
                await msgdialog.ShowAsync();
            }
            if (pass.Password.Length > 4)
            {
                btn1.IsEnabled =true;
                btn2.IsEnabled =true;
                btn3.IsEnabled =true;
                btn4.IsEnabled =true;
                btn5.IsEnabled =true;
                btn6.IsEnabled =true;
                btn7.IsEnabled =true;
                btn8.IsEnabled =true;
                btn9.IsEnabled =true;
                btn0.IsEnabled =true;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "9";
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            pass.Password += "0";
        }

       
        private void pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pass.MaxLength = 4;
            if (pass.Password.Length >= 4)
            {
                btn1.IsEnabled = false;
                btn2.IsEnabled = false;
                btn3.IsEnabled = false;
                btn4.IsEnabled = false;
                btn5.IsEnabled = false;
                btn6.IsEnabled = false;
                btn7.IsEnabled = false;
                btn8.IsEnabled = false;
                btn9.IsEnabled = false;
                btn0.IsEnabled = false;
            }

            if (pass.Password.Length < 4)
            {
                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
                btn7.IsEnabled = true;
                btn8.IsEnabled = true;
                btn9.IsEnabled = true;
                btn0.IsEnabled = true;

            }

            if (pass.Password.Length == 4)
            {
                ZATWIERDZ.IsEnabled = true;
            }
            else if (pass.Password.Length >= 1 && pass.Password.Length < 4)
            {
                ZATWIERDZ.IsEnabled = false;
            }
        }
    }
}
