using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinApp;
using Android.Support.V7.App;


namespace XamarinApp
{
    [Activity(Label = "RegisterPage")]
    public class RegisterPage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RegisterPage);
            Button Back = FindViewById<Button>(Resource.Id.BackBtn);


            Back.Click += OnBack_Click;
        }
        private void OnBack_Click(object sender, EventArgs e)
        {

            Intent Main = new Intent(this, typeof(LoginActivity));
            StartActivity(Main);



        }
    }
}