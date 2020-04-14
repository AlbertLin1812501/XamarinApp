using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace XamarinApp
{
    [Activity(Label = "ItemViewActivity")]
    public class ItemViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SingleItem);
            Button Share = FindViewById<Button>(Resource.Id.ShareSMS);
            Share.Click += OnSmSShare_Click;
            Button Map = FindViewById<Button>(Resource.Id.Location);
            Map.Click += OnLocation_Click;

        }
        public async Task ShareText(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Share Text"
            });
        }
        private async void OnSmSShare_Click(object sender, EventArgs e)
        {
            String messageText = "Check this item out" ;
            String recipient = "02102339008";
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                builder.SetMessage("SMS is not supported on this phone ").SetTitle("Feature Not Supported");
                Android.App.AlertDialog dialog = builder.Create();

            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }

            
        }
        private void OnLocation_Click(object sender, EventArgs e)
        {
            Intent Location = new Intent(this, typeof(MainActivity));
            StartActivity(Location);
        }
    }
}