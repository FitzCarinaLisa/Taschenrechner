using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Taschenrechner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string zwischenRechner = "";
        decimal[] arrayVonAllenZahlen  = new decimal [3] ;
        string[] vorzeichen = new string [1];
        //string vorzeichen = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btn_sieben(object sender, RoutedEventArgs e)
        {
            zwischenRechner +=  "7";
            ausgabe();
        }

        private void btn_acht(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "8";
            ausgabe();
        }

        private void btn_neun(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "9";
            ausgabe();
        }

        private void btn_mal(object sender, RoutedEventArgs e)
        {
            vorzeichenInArray("X");
            ausgabe();
        }

        private void btn_vier(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "4";
            ausgabe();
            txt_ergebnis.Text = zwischenRechner;
        }

        private void btn_fuenf(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "5";
            ausgabe();
        }

        private void btn_sechs(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "6";
            ausgabe();
        }

        private void btn_minus(object sender, RoutedEventArgs e)
        {
            vorzeichenInArray("-");
            ausgabe();
        }

        private void btn_eins(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "1";
            ausgabe();
           
        }

        private void btn_zwei(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "2";
            ausgabe();
        }

        private void btn_drei(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "3";
            ausgabe();
        }

        private void btn_plus(object sender, RoutedEventArgs e)
        {
            vorzeichenInArray("+");
            ausgabe();
        }

        private void btn_null(object sender, RoutedEventArgs e)
        {
            zwischenRechner += "0";
            ausgabe();
        }

        private void btn_punkt(object sender, RoutedEventArgs e)
        {
           zwischenRechner += ",";
            ausgabe();
        }

        //punkt vor strich option 
        // interne Klassenberechnung { public int rechnerfunktion(string rechnungsstring) { DataTable dt = new DataTable(); int ergebniss = (int)dt.Compute(rechnungsstring, ""); Rückgabeergebnisse; }}
        
        private void btn_ergebnis(object sender, RoutedEventArgs e)
        {
           decimal ergebnis = 0;
            zahlenInArray();
            for (int i = 1; i < arrayVonAllenZahlen.Length; i=i+2)
            {
                for(int j = 0; j< vorzeichen.Length; j++)
                {
                    if(vorzeichen[j] == "+")
                    {
                       ergebnis = ergebnis + arrayVonAllenZahlen[i - 1] + arrayVonAllenZahlen[i];
                    }
                    else if (vorzeichen[j] == "-")
                    {
                        ergebnis = ergebnis + arrayVonAllenZahlen[i - 1] - arrayVonAllenZahlen[i];
                    }
                    else if (vorzeichen[j] == "X")
                    {
                        ergebnis = ergebnis + arrayVonAllenZahlen[i - 1] * arrayVonAllenZahlen[i];
                    }
                    arrayVonAllenZahlen[i - 1] = 0;
                    arrayVonAllenZahlen[i] = 0;
                }
            }
            txt_ergebnis.Text = "Das ergebnis = " + ergebnis;
            zwischenRechner = "";
            ergebnis = 0;
        }
        private void btn_loeschen(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<arrayVonAllenZahlen.Length; i++) {
                for (int j = 0; j < vorzeichen.Length; j++)
                {
                    arrayVonAllenZahlen[i] = 0;
                    vorzeichen[j] = "";
                }
            }
            txt_ergebnis.Text = "";
            zwischenRechner = "";
        }
        private void vorzeichenInArray(string zeichen)
        {
            for (int j = 0; j < vorzeichen.Length; j++)
            {
                if (vorzeichen[j] != "" )
                {
                    vorzeichen[j] = zeichen;
                }
                else
                {
                    vorzeichen[j] = zeichen;
                }
            }
            zahlenInArray();
        }
        private void zahlenInArray()
        {
            for (int i = 0; i < arrayVonAllenZahlen.Length; i++)
            {
                if (arrayVonAllenZahlen[i] == 0)
                {
                    arrayVonAllenZahlen[i] = Convert.ToDecimal(zwischenRechner);
                    zwischenRechner = "";
                    break;
                }
            }
        }
        private void ausgabe()
        {
            txt_ergebnis.Text = "";
            for (int i = 0; i < arrayVonAllenZahlen.Length; i++)
            {
                if (arrayVonAllenZahlen[0] == 0)
                {
                    txt_ergebnis.Text = txt_ergebnis.Text + zwischenRechner;
                    break;
                }
                else
                {
                    for (int j = 0; j < vorzeichen.Length; j++)
                    {
                        if (arrayVonAllenZahlen[i] != 0)
                        {
                            if(zwischenRechner== "")
                            {
                                txt_ergebnis.Text = txt_ergebnis.Text + arrayVonAllenZahlen[i] + vorzeichen[j] ;
                            }
                            else
                            {
                                txt_ergebnis.Text = txt_ergebnis.Text + arrayVonAllenZahlen[i] + vorzeichen[j] +zwischenRechner;
                            }
                          
                        }
                      
                    }
                }
            }
        }
    }
}
