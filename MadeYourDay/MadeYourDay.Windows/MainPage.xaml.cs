using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MadeYourDay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            LIveTiles();
        }


        private void LIveTiles()
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue(true);
            updater.Clear();
            var tile = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150PeekImage06);
           
            var ImageAttributes = tile.GetElementsByTagName("image");
            tile.GetElementsByTagName("text")[0].InnerText = "check for new features";
            ((XmlElement)ImageAttributes[0]).SetAttribute("src", "ms-appx:///Assets/Logo.png");
            ((XmlElement)ImageAttributes[1]).SetAttribute("src", "ms-appx:///Assets/project.jpg");
            var tilenotification = new TileNotification(tile);
            tilenotification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(1);
            updater.Update(new TileNotification(tile));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(offlinepage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(share));
        }
    }
}
