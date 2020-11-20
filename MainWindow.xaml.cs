using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace TaskFactory
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

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Get URL provided
            string url = txtUrl.Text;
            //Create Http request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //Submit request and await response.
            HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse,
                request.EndGetResponse, request) as HttpWebResponse;
            //Display the status code of the response
            lblResult.Content = String.Format("The URL returned the following status code {0}", response.StatusCode);
        }

        private async void btnThrowError_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
                try
                {
                    //Get URL provided
                    string url = txtUrl.Text;
                    //Create Http request
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    //Submit request and await response.
                    HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse,
                        request.EndGetResponse, request) as HttpWebResponse;
                    //Display the status code of the response
                }
                catch (WebException ex)
                {
                    lblResult.Content = ex.Message;
                }
        }
    }
}
