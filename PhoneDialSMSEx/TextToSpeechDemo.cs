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
using System.Threading;
using Xamarin.Essentials;

namespace PhoneDialSMSEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class TextToSpeechDemo : Activity
    {
        private Button mStarted;
       // private Button mStop;
        private Button myLocale;
        private EditText edTS;
        private EditText edTS1;
        //CancellationTokenSource cts;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.texttospeechDemo);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            mStarted = FindViewById<Button>(Resource.Id.buttonTS1);
           // mStop = FindViewById<Button>(Resource.Id.buttonTS2);
            myLocale = FindViewById<Button>(Resource.Id.buttonTS3);
            edTS = FindViewById<EditText>(Resource.Id.editTextTS);
            edTS1 = FindViewById<EditText>(Resource.Id.editTextTS1);

            mStarted.Click += MStarted_Click;
       
            myLocale.Click += MyLocale_Click; ;


        }

        private void MyLocale_Click(object sender, EventArgs e)
        {
            SpeakLocal();
        }

        private async void SpeakLocal()
        {
            
            string otherlang = edTS1.Text;
            
            var locales = await TextToSpeech.GetLocalesAsync();
            
            
            var locale = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Volume = 0.75f,
                Pitch = 1.0f,
                Locale = locale,
            };


            await TextToSpeech.SpeakAsync(otherlang, settings);
        }


       
        private void MStarted_Click(object sender, EventArgs e)
        {
            GetTextToSpeech();


        }

        private async void GetTextToSpeech()
        {
            string speech = edTS.Text;
            await TextToSpeech.SpeakAsync(speech);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}