using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class music : Page
    {
        
        public music()
        {
            this.InitializeComponent();
           
            
        }
        bool state; 


        private void PlayMedia(object sender, RoutedEventArgs e)
        {
          
            state = true;
            media.Play();
        }

        private void PauseMedia(object sender, RoutedEventArgs e)
        {
            if (state == true)
            {
                media.Pause();
                state = false;

            }

            else
            {
                media.Play();
                state = true;

            }
        }

        FileOpenPicker openPicker = new FileOpenPicker();
        
        async public void SetLocalMedia()
        {


            openPicker.FileTypeFilter.Add(".m4p");
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".amr");
            openPicker.FileTypeFilter.Add(".wma");

            StorageFile file = null;


            var stream = (dynamic)null;
            file = await openPicker.PickSingleFileAsync();

          

            if (null != file)
            {
                stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                media.SetSource(stream, file.Path);

            }
        }

        private void choosefile(object sender, RoutedEventArgs e)
        {
            
                SetLocalMedia();
           
             
           

        }

        private void StopMedia(object sender, RoutedEventArgs e)
        {
            media.Stop();
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(offlinepage));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
