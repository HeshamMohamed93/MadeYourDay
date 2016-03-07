using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

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
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        FileOpenPicker img = new FileOpenPicker();

        string ImagePath;

        /***********************/
        public void PickAnImage()
        {

            CoreApplicationView view = CoreApplication.GetCurrentView();

            ImagePath = string.Empty;
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".mp3");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.PickSingleFileAndContinue();
            view.Activated += viewActivated;

        }

        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;

            if (args != null)
            {
                if (args.Files.Count == 0) return;
                IRandomAccessStream fileStream = await args.Files[0].OpenAsync(FileAccessMode.Read);
                media.SetSource(fileStream, args.Files[0].Path);
                media.Play();
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void choosefile(object sender, RoutedEventArgs e)
        {
            PickAnImage();
            // SetLocalMedia();
        }

        bool state;

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

        private void PlayMedia(object sender, RoutedEventArgs e)
        {
            state = true;
            media.Play();
        }

        private void StopMedia(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }

        private void PDFREAD(object sender, RoutedEventArgs e)
        {
            PickAnImage();
            // CoreApplicationView view = CoreApplication.GetCurrentView();
            // SampleDataGroup group = (SampleDataGroup)e.ClickedItem;
            /*  StorageFile file = null;
           
                  FileOpenPicker filePicker = new FileOpenPicker();
                  filePicker.FileTypeFilter.Add(".pdf");
                  filePicker.ViewMode = PickerViewMode.Thumbnail;
                  filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                //  filePicker.SettingsIdentifier = "picker1";
                 // filePicker.CommitButtonText = "Open Pdf File";
                   filePicker.PickSingleFileAndContinue();
                 // file = await filePicker.PickSingleFileAsync();
                  //  PdfReader pdfReader = new PdfReader(ppath);
                 // Windows.System.Launcher.LaunchFileAsync(file);
                   StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
                   StorageFile pdffile = await local.GetFileAsync("your-file.pdf");*/

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(offlinepage));
        }

    }
}
