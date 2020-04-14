using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
namespace XamarinApp
{
    [Activity(Label = "ItemViewActivity")]
    public class ItemViewActivity : Activity
    {
        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "name";
        internal static readonly string COUNT_KEY = "count";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SingleItem);
            Button Share = FindViewById<Button>(Resource.Id.ShareSMS);
            Share.Click += OnSmSShare_Click;
            CreateNotificationChannel();

        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var name = Resources.GetString(Resource.String.channel_name);
            var description = GetString(Resource.String.channel_description);
            var channel = new NotificationChannel(CHANNEL_ID, name, NotificationImportance.Default)
            {
                Description = description
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
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
                Android.App.AlertDialog.Builder builders = new Android.App.AlertDialog.Builder(this);
                builders.SetMessage("SMS is not supported on this phone ").SetTitle("Feature Not Supported");
                Android.App.AlertDialog dialog = builders.Create();

            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, CHANNEL_ID)
          .SetAutoCancel(false)
          .SetSmallIcon(Resource.Drawable.abc_ic_star_black_36dp)
          .SetContentTitle("XamarinApp")
          .SetContentText("You have shared a product");

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NOTIFICATION_ID, builder.Build());
        }
    }
}