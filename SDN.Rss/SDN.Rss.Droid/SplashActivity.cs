using Android.App;
using Android.OS;

namespace SDN.Rss.Droid
{
    [Activity(Label = "SDN.Rss", Icon = "@drawable/ic_launcher", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            StartActivity(typeof (MainActivity));
        }
    }
}