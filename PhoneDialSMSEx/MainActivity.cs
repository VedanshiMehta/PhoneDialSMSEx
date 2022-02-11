using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace PhoneDialSMSEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button myPhD;
        private Button mySMS;
        private Button ttS;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            myPhD = FindViewById<Button>(Resource.Id.button1);
            mySMS = FindViewById<Button>(Resource.Id.button2);
            ttS = FindViewById<Button>(Resource.Id.button3);

            myPhD.Click += MyPhD_Click;
            mySMS.Click += MySMS_Click;
            ttS.Click += TtS_Click;

        }

        private void TtS_Click(object sender, System.EventArgs e)
        {
            Intent k = new Intent(Application.Context, typeof(TextToSpeechDemo));
            StartActivity(k);
        }

        private void MySMS_Click(object sender, System.EventArgs e)
        {
            Intent j = new Intent(Application.Context, typeof(SMSDemo));
            StartActivity(j);
        }

        private void MyPhD_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(Application.Context, typeof(PhoneDialerDemo));
            StartActivity(i);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}