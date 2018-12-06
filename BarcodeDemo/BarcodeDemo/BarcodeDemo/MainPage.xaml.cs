using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarcodeDemo
{
	public partial class MainPage : ContentPage
	{
	    ZXingScannerPage scanPage;
        public MainPage()
		{
			InitializeComponent();
		}

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	        
	            scanPage = new ZXingScannerPage();
	            scanPage.OnScanResult += (result) => {
	                scanPage.IsScanning = false;

	                Device.BeginInvokeOnMainThread(() => {
	                    Navigation.PopModalAsync();
	                    DisplayAlert("Scanned Barcode", result.Text, "OK");
	                });
	            };

	            await Navigation.PushModalAsync(scanPage);
	        
        }
	}
}
