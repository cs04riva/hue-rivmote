using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
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
using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace hue_rivmote
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void LightOffClick(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();

            Uri requestUri = new Uri("http://192.168.1.164/api/RXsOaJ-zfHPTSZiZcdXjzsImuWrP1EIKgmtnzn97/lights/3/state");

            HttpStringContent lightCommand = new HttpStringContent(
                "{\"on\":false}",
                Windows.Storage.Streams.UnicodeEncoding.Utf8,
                "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(requestUri, lightCommand);

            this.CreateOkDialog("Off Click: " + response.Content.ToString());
        }

        private async void LightOnClick(object sender, RoutedEventArgs e)
        {

            HttpClient httpClient = new HttpClient();

            Uri requestUri = new Uri("http://192.168.1.164/api/RXsOaJ-zfHPTSZiZcdXjzsImuWrP1EIKgmtnzn97/lights/3/state");

            HttpStringContent lightCommand = new HttpStringContent(
                "{\"on\":true}",
                Windows.Storage.Streams.UnicodeEncoding.Utf8,
                "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(requestUri, lightCommand);
            this.CreateOkDialog("On Click: " + response.Content.ToString());
        }

        private async void CreateOkDialog(string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Hue - RivMote",
                Content = message,
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }
    }
}
