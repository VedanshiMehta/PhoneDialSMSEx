using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using Xamarin.Essentials;

namespace PhoneDialSMSEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class PhoneDialerDemo : Activity
    {
        private EditText myedT;
        private Button myB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           
            SetContentView(Resource.Layout.phonedialerDemo);
            myB = FindViewById<Button>(Resource.Id.buttonPD);
            myedT = FindViewById<EditText>(Resource.Id.editTextPD);

            myB.Click += MyB_Click;

        }

        private void MyB_Click(object sender, EventArgs e)
        {
            //GotoDailer();
            GotoPhoneDail();
        }

        private void GotoPhoneDail()
        {
            string number = myedT.Text;
            Android.Net.Uri u = Android.Net.Uri.Parse("tel: " + myedT.Text.ToString());
            Intent i = new Intent(Intent.ActionDial, u);
            try
            {
                StartActivity(i);
            }
            catch (SecurityException s)
            {
                // show() method display the toast with 
                // exception message.
                Toast.MakeText(this, "An error occurred", ToastLength.Short)
                     .Show();
            }

        }

        /*private void GotoDailer()
        {
            string number = myedT.Text;
            PhoneDialer.Open(number);
        }*/

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}