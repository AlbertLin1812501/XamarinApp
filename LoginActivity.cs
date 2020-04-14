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

namespace XamarinApp
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginPage);

            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += BtnLogin_Click;
            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += btnRegister_Click;
            EditText EdUserName;
            EditText EdPassword;


            EdUserName = FindViewById<EditText>(Resource.Id.EdUserName);
            EdPassword = FindViewById<EditText>(Resource.Id.EdPassword);
        }
            private void BtnLogin_Click(object sender, EventArgs e)
            {
                EditText Username = FindViewById<EditText>(Resource.Id.EdUserName);
                EditText Password = FindViewById<EditText>(Resource.Id.EdPassword);
            //preset password is for test
                string User = "Y";
                string Pw = "123";

                if (Username.Text == User && Password.Text == Pw)
                {

                    Intent MenuAct = new Intent(this, typeof(MainMenuActivity));
                    StartActivity(MenuAct);
                }
            }



            public void btnRegister_Click(Object sender, EventArgs e)
            {
                Intent RegisterAct = new Intent(this, typeof(RegisterActivity));
                StartActivity(RegisterAct);
            }
        
    }
}