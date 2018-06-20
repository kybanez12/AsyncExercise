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
using ClassLibrary1;

namespace AsyncWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public async static void FindPrime(int n, TextBox tb)
        {
            var fp = new FindPrime();
            var a = await fp.FindPrimesAsync(n);
            tb.Text = a.ToString();
        }
        private void findPrime_Click(object sender, RoutedEventArgs e)
        {
            FindPrime(int.Parse(input.Text), result);
            
        }

        private void distract_Click(object sender, RoutedEventArgs e)
        {
            if (theGrid.Background == null)
            {
                theGrid.Background = new SolidColorBrush(Colors.Aqua);
            }
            else
            {
                theGrid.Background = null;
            }
        }
    }
}
