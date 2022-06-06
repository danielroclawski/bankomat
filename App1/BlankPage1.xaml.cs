using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            kwota.Text = "";
            ilosc500.Text = String.Empty;
            ilosc200.Text = String.Empty;
            ilosc100.Text = String.Empty;
            ilosc50.Text = String.Empty;
            pass.Password = "";
        }
        int reszta = 0, reszta1 = 0, reszta2 = 0, reszta3 = 0, iloscPieniedzy;

        private async void zaloguj_Click(object sender, RoutedEventArgs e)
        {
            if(pass.Password == "admin")
            {
                kwadrat.Visibility = Visibility.Collapsed; 
            }
            else
            {
                string message3 = "Złe hasło!";
                MessageDialog messageDialog = new MessageDialog(message3);
                await messageDialog.ShowAsync();
                
            }
        }

        private async void Wyplac_Click(object sender, RoutedEventArgs e)
        {
            iloscPieniedzy = Convert.ToInt32(kwota.Text);
            reszta = 0; reszta1 = 0; reszta2 = 0; reszta3 = 0;

            if (iloscPieniedzy >= 50 && iloscPieniedzy %50 == 0)
            {
                
                while (iloscPieniedzy != 0)
                {
                   
                    if (iloscPieniedzy >= 500 && piecset.Value >= 1)
                    {
                        iloscPieniedzy -= 500;
                        reszta++;
                        piecset.Value --;
                    }
                    else if ((iloscPieniedzy <= 500 && iloscPieniedzy >= 200 && dwiescie.Value >= 1)
                        || (iloscPieniedzy % 200 == 0 && dwiescie.Value == 0 && sto.Value >= 1)
                        || (iloscPieniedzy % 200 == 50 && piecdziesiat.Value == 0 && sto.Value > 0))
                    {
                        iloscPieniedzy -= 200;
                        reszta1++;
                        dwiescie.Value--;
                    }
                    else if((iloscPieniedzy <=200 && iloscPieniedzy>=100 &&sto.Value>=1)
                        ||(iloscPieniedzy %100 == 0 && dwiescie.Value == 0 && sto.Value >= 1 ) 
                        || (iloscPieniedzy % 100 ==50 && piecdziesiat.Value == 0 && sto.Value> 0))
                    {
                        iloscPieniedzy -= 100;
                        reszta2++;
                        sto.Value --;
                    }
                    else if ((iloscPieniedzy <= 100 && iloscPieniedzy >= 50 && piecdziesiat.Value >= 1) 
                        || (iloscPieniedzy % 50 == 0 && dwiescie.Value == 0 && sto.Value == 0 && piecdziesiat.Value >= 1) 
                        || iloscPieniedzy % 50 == 0 && piecdziesiat.Value >= 1)
                    {
                        iloscPieniedzy -= 50;
                        reszta3++;
                        piecdziesiat.Value--;
                    }
                    else if ((dwiescie.Value == 0 && sto.Value == 0 && piecdziesiat.Value == 0)
                        || (dwiescie.Value > 0 && sto.Value > 0 && piecdziesiat.Value == 0)
                        || (dwiescie.Value > 0 && sto.Value == 0 && piecdziesiat.Value == 0 && iloscPieniedzy % 100 == 0)
                        || (dwiescie.Value * 200 + sto.Value * 100 + piecdziesiat.Value * 50 < iloscPieniedzy)
                        || (dwiescie.Value > 0 && piecdziesiat.Value > 0 && sto.Value > 100 && iloscPieniedzy % 50 == 0))
                    {
                        string message2 = "Za mało banknotów w bankomacie!";
                        MessageDialog messageDialog = new MessageDialog(message2);
                        await messageDialog.ShowAsync();
                        break;


                    }
                }
            }
            else
            {
                string message3 = "Źle wpisano kwotę!";
                MessageDialog messageDialog = new MessageDialog(message3);
                await messageDialog.ShowAsync();
            }
            ilosc500.Text = Convert.ToString(reszta);
            ilosc200.Text = Convert.ToString(reszta1);
            ilosc100.Text = Convert.ToString(reszta2);
            ilosc50.Text = Convert.ToString(reszta3);
        }
    }
}
