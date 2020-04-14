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
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace XamarinApp
{
    [Activity(Label = "RegisterPage")]
    public class RegisterPage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;


           

            SetContentView(Resource.Layout.RegisterPage);
            Button Back = FindViewById<Button>(Resource.Id.BackBtn);
            Button Register = FindViewById<Button>(Resource.Id.RegisterBtn);

            Back.Click += OnBack_Click;
            Register.Click += OnRegister_Click;
        }

        private void OnRegister_Click(object sender, EventArgs e)
        {
            var request = HttpWebRequest.Create(string.Format(@"https://10.0.2.2:5001/api/Users"));
            request.ContentType = "application/json";
            request.Method = "POST";
            EditText EditUserName = FindViewById<EditText>(Resource.Id.UserNameRegi);
            EditText EditPassWord = FindViewById<EditText>(Resource.Id.UserNameRegi);
            EditText EditFirstName = FindViewById<EditText>(Resource.Id.UserNameRegi);
            EditText EditLastName = FindViewById<EditText>(Resource.Id.UserNameRegi);
            EditText Editaddress = FindViewById<EditText>(Resource.Id.UserNameRegi);
            EditText EditCountry = FindViewById<EditText>(Resource.Id.UserNameRegi);
            EditText EditContact = FindViewById<EditText>(Resource.Id.UserNameRegi);
            Users newUser = new Users();
            newUser.Country = EditCountry.Text;
            newUser.Username = EditUserName.Text;
            newUser.Password = EditPassWord.Text;
            newUser.FirstName = EditFirstName.Text;
            newUser.LastName = EditLastName.Text;
            newUser.Address = Editaddress.Text;
            newUser.ContactNum = EditContact.Text;

            var userJason = JsonConvert.SerializeObject(newUser);


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {

                streamWriter.Write(userJason);
            }
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {

                if (response.StatusCode != HttpStatusCode.Created)
                {
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                    Toast.MakeText(this, "Failed to create user. Please retry!", ToastLength.Long);
                }
                else
                {
                    Toast.MakeText(this, "User created successfully", ToastLength.Long);

                    Intent loginActivityIntent = new Intent(this, typeof(LoginActivity));
                    StartActivity(loginActivityIntent);
                }
            }

        }
        private void OnBack_Click(object sender, EventArgs e)
        {

            Intent Main = new Intent(this, typeof(LoginActivity));
            StartActivity(Main);



        }
    }
}