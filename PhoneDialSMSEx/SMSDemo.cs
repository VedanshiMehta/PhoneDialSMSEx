using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace PhoneDialSMSEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class SMSDemo : Activity
    {
        private EditText mtextTo;
        private EditText mtexthere;
        private Button myButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.smsDemo);

            mtextTo = FindViewById<EditText>(Resource.Id.editTextS1);
            mtexthere = FindViewById<EditText>(Resource.Id.editTextS2);
            myButton = FindViewById<Button>(Resource.Id.buttonS);

            myButton.Click += MyButton_Click;
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            GottoSMS();
        }

        private async void GottoSMS()
        {
            string messagetext = mtexthere.Text;
            string recipent = mtextTo.Text;
            SmsMessage message = new SmsMessage(messagetext, new[] { recipent });
            await Sms.ComposeAsync(message);
        }
    }
}