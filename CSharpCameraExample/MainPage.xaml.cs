using System;
using Windows.Media.Capture;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CSharpCameraExample
{
    public sealed partial class MainPage : Page
    {
		private MediaCapture mediaCapture;
		public MainPage()
        {
            this.InitializeComponent();
        }
		private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
			mediaCapture = new MediaCapture();
			await mediaCapture.InitializeAsync();

			await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
			{
				PreviewCaptureElement.Source = mediaCapture;

				await mediaCapture.StartPreviewAsync();
			});
		}
		private async void StopButton_Click(object sender, RoutedEventArgs e)
		{
			if (mediaCapture != null)
			{
				await mediaCapture.StopPreviewAsync();
				mediaCapture.Dispose();
				mediaCapture = null;
			}
		}
	}
}
