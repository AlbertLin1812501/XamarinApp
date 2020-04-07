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
    [Activity(Label = "RegActivity")]
    public class RegActivity : Activity
    {
        Button btn_reg;
        Button btn_return;
        EditText txt_username;
        EditText txt_pwd;
        EditText txt_pwd2;
        RadioButton rad_xbm, rad_xbw, rad_xbmw;
        string xb;
        string whe;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Reguster);
            
            btn_reg = FindViewById<Button>(Resource.Id.button3);
            btn_return = FindViewById<Button>(Resource.Id.button2);
            txt_username = FindViewById<EditText>(Resource.Id.editText1);
            txt_pwd = FindViewById<EditText>(Resource.Id.editText2); 
            btn_reg.Click += Btn_reg_Click;
            btn_return.Click += Btn_return_Click;
        }
        private void Btn_return_Click(object sender, EventArgs e)
        {
            this.Finish();

        }
        private void Btn_reg_Click(object sender, EventArgs e)
        {
            xb = rad_xbm.Checked ? "Male" : (rad_xbw.Checked ? "Female" : "Neutral");
            string returnmessage = "";
            returnmessage += txt_username.Text + "\n";
            returnmessage += txt_pwd.Text + "\n";
            returnmessage += xb + "\n";
            returnmessage += whe;
            Toast.MakeText(this, "This is a popup！  \nPassword \n" + returnmessage, ToastLength.Long).Show();

        }
    }
}