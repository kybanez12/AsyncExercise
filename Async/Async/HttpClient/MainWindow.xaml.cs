using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WPFHttpClient
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

        private void getJSONstring_Click(object sender, RoutedEventArgs e)
        {
            DownloadString(JSONstring);
        }

        public static async void DownloadString(TextBox box)
        {
            string JSON = "https://jsonplaceholder.typicode.com/posts/1/comments";

            using (var client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(JSON))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                box.Text = result;
                
            }
  
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
