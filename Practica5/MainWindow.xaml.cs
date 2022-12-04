using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace Practica5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public struct Data
    {
        public string Day;
        public string Month;
        public string Year;
        public string SignSlavic; 
        public string SignJapan; 

        public string concat()
        {
            return Day + ";" + Month + ";" + Year + ";" + SignSlavic + ";" + SignJapan;
        }
    }
    public partial class MainWindow : Window
    {
        public static string startPath; 
        public static string endPath;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnSlacic(object sender, RoutedEventArgs e)
        {
            Clavic.Visibility = Visibility.Collapsed;
            Japan.Visibility = Visibility.Collapsed;
            G2.Visibility = Visibility.Collapsed;
            G1.Visibility = Visibility.Collapsed;
            textLable.Visibility = Visibility.Collapsed;
            BtnAddCSV1.Visibility =Visibility.Visible;
            BtnManually1.Visibility = Visibility.Visible;
            textLable2.Visibility = Visibility.Visible;

        }
        private void BtnJapan(object sender, RoutedEventArgs e)
        {
            Clavic.Visibility = Visibility.Collapsed;
            Japan.Visibility = Visibility.Collapsed;
            G2.Visibility = Visibility.Collapsed;
            G1.Visibility = Visibility.Collapsed;
            textLable.Visibility = Visibility.Collapsed;
            BtnAddCSV2.Visibility = Visibility.Visible;
            BtnManually2.Visibility = Visibility.Visible;
            textLable2.Visibility = Visibility.Visible;
        }

        static int Check(int day, int month)
        {
            if (((month==4) || (month==6) || (month==9) || (month==11)) && ((day<=30) && (month <= 12)))
            {
                return 1;
            }
            if ((month==2) && ((day <= 28) && (month <= 12)))
            {
                return 1;
            }
            if (((month != 4) || (month != 6) || (month != 9) || (month != 11) || (month != 2)) && ((day <= 31) && (month <= 12)))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }



        static string JapanSign(int year)
        {
            const int firstYear = 1937;
            int element = (year - firstYear) % 12;
            element++;
            while (element > 12)
            {
                element -=12;
            }
            string str = string.Empty;

            switch (element)
            {
                case 0:
                    str = "Rat";
                    break;
                case 1:
                    str = "Cow";
                    break;
                case 2:
                    str = "Tiger";
                    break;
                case 3:
                    str = "Hare";
                    break;
                case 4:
                    str = "Dragon";
                    break;
                case 5:
                    str = "Snake";
                    break;
                case 6:
                    str = "Horse";
                    break;
                case 7:
                    str = "Sheep";
                    break;
                case 8:
                    str = "Monkey";
                    break;
                case 9:
                    str = "Rooster";
                    break;
                case 10:
                    str = "Dog";
                    break;
                case 11:
                    str = "Pig";
                    break;
            }
            return str;
        }
            static string SlavicSign(int day, int month)
        {
            if (((month==12) && (day >= 24)) || ((month == 1) && (day<=30)))
            {
                return "Frost";
            }
            if (((month == 1) && (day >= 31)) || ((month == 2) && (day <= 28)))
            {
                return "Velez";
            }
            if (month == 3)
            {
                return "Makosh";
            }
            if (month == 4)
            {
                return "Alive";
            }
            if ((month == 5) && (day <= 14))
            {
                return "Yarila";
            }
            if (((month == 5) && (day >= 15)) || ((month == 6) && (day <= 2)))
            {
                return "Lelya";
            }
            if ((month == 6) && ((day >= 3)  && (day <= 12)))
            {
                return "Kostroma";
            }
            if (((month == 6) && (day >= 13 && (day != 24))) || ((month == 7) && (day <= 6)) )
            {
                return "Dodola";
            }
            if (((month == 6) && (day == 24))) 
            {
                return "Ivan Kupala";
            }
            if ((month == 7) && ((day >= 7) && (day <= 31)))
            {
                return "Lada";
            }
            if ((month == 8)  && (day <= 28))
            {
                return "Perun";
            }
            if (((month == 8) && (day >= 25)) || ((month == 9) && (day <= 13)))
            {
                return "Seva";
            }
            if ((month == 9) && (day <= 27))
            {
                return "Rozhanitsa";
            }
            if (((month == 9) && (day >= 28)) || ((month == 10) && (day <= 15)))
            {
                return "Svarozhichi";
            }
            if (((month == 10) && (day >= 16)) || ((month == 11) && (day <= 8)))
            {
                return "Moraine";
            }
            if (((month == 11) && (day >= 16))  && (day <= 28))
            {
                return "Winter";
            }
            else
            {
                return "Karachun";
            }

        }

         static void CSV_Data(List<Data> S) 
        {

            using (StreamReader sr = new StreamReader(startPath))
            {
                int i = 0;
                
                while (sr.EndOfStream != true)
                {
                    
                    string[] array = sr.ReadLine().Split(';');
                    if (i != 0) 
                    {
                        string SignSlavic;
                        string SignJapan;
                        SignSlavic = "Check if all fields are filled in";
                        SignJapan = "";
                        int rezultChek;
                        
                        if (array[0] != "" && array[1] != "" )
                        {
                            try
                            {
                                int d = Convert.ToInt32(array[0]);
                                int m = Convert.ToInt32(array[1]);
                                int y = Convert.ToInt32(array[2]);
                                if (((d > 0) && ( m > 0) && (y > 0)))
                                {
                                    rezultChek=Check(d, m);
                                    if(rezultChek == 1)
                                    {
                                        SignSlavic = SlavicSign(d, m);
                                        SignJapan = JapanSign(y);
                                    }
                                    else
                                    {
                                        SignSlavic = "Date incorrect";
                                    }
                                }
                                else
                                {
                                    SignSlavic = "Date incorrect";
                                }
                            }
                            catch
                            {
                                SignSlavic = "Date incorrect";

                            }
                        }
                        
                        S.Add(new Data()
                        {
                            Day = array[0],
                            Month = array[1],
                            Year = array[2],
                            SignSlavic = SignSlavic,
                            SignJapan = SignJapan
                        });
                    }
                    i++;
                }
            }


            // List<Data> data = new List<Data>();
            // inputData(data);
        }
        public static void Input(List<Data> S)
        {
            using (StreamWriter sw = new StreamWriter(endPath, true))
            {
                sw.WriteLine("Day;Month;Year;SignSlavic;SignJapan");
                foreach (Data U in S)
                {
                    sw.WriteLine(U.concat());
                }
            }
        }

        private void BtnAddCSV_Click(object sender, RoutedEventArgs e)
        {
            
            while (true) // открытие файла 
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.DefaultExt = ".csv";
                openFile.Filter = "File (.csv)|*.csv";
                if (openFile.ShowDialog() == true)
                {
                    startPath = openFile.FileName;
                    break;
                }
                else
                {
                    return;
                }
            }
            List<Data> data = new List<Data>();
            CSV_Data(data); // обработка файла 
            while (true)  // сохранение файла 
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.DefaultExt = ".csv";
                saveFile.Filter = "File (.csv)|*.csv";
                if (saveFile.ShowDialog() == true)
                {
                    endPath = saveFile.FileName;
                    break;
                }
                else
                {
                    return;
                }
            }
            Input(data); // вывод данных в файл 
        }

        private void BtnManually_Click(object sender, RoutedEventArgs e)
        {
            TB.Visibility = Visibility.Visible;
        }

        private void BtnManually2_Click(object sender, RoutedEventArgs e)
        {
            TB.Visibility = Visibility.Visible;
            BtnPerform.Visibility = Visibility.Visible;

        }

        private void BtnPerform_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
