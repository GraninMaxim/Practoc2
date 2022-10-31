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
using Libmas;
using Lib_6;
using Microsoft.Win32;

namespace WPFApp2_9_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] arr = null;
        public MainWindow()
        {
            InitializeComponent();
            ArrLenght.Focus();
        }

        private void SaveFileBut_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.Filter = "Текстовые файлы | *.txt";
            sfg.FilterIndex = 1;
            if (arr == null)
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
            else if(sfg.ShowDialog() == true)
            {
                LibraryMas.SaveArray(arr, sfg.FileName);
            }
        }

        private void UploadFileBut_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog pfg = new OpenFileDialog();
            pfg.Filter = "Текстовые файлы | *.txt";
            pfg.FilterIndex = 1;
            if (pfg.ShowDialog() == true)
            {
                arr = LibraryMas.UploadArray(pfg.FileName, arr);
                ArrNums.ItemsSource = VisualArray.ToDataTable(LibraryMas.UploadArray(pfg.FileName, arr)).DefaultView;
            }
        }

        private void CloseProgBut_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowTaskBut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: \nВвести n целых чисел.\nНайти сумму чисел <15. \nРезультат вывести на экран.", "Вариант 6", MessageBoxButton.OK, MessageBoxImage.Information);
        
        }

        private void ClearArrBut_Click(object sender, RoutedEventArgs e)
        {
            arr = LibraryMas.ClearArray(arr);
            ArrNums.ItemsSource = null;
            ArrLenght.Clear();
            ArrLenght.Focus();
            maxRandNum.Clear();
            resPow.Clear();
        }

        private void ArrLenght_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ArrLenght.Text == "")
            {
                resPow.Clear();
            }
            if (int.TryParse(ArrLenght.Text, out int len))
            {
                arr = new int[len];
                if (maxRandNum.Text != "")
                {
                    int.TryParse(maxRandNum.Text, out int maxRand);
                    ArrNums.ItemsSource = VisualArray.ToDataTable(LibraryMas.FillArray(arr, maxRand)).DefaultView;
                }
            }
        }

        private void resButton_Click(object sender, RoutedEventArgs e)
        {
            if (arr == null)
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
            else
            {
                resPow.Text = $"{LibTask.SumOfElem(arr)}";
            }
        }
    }
}
