using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace SDN.Rss.Droid
{
    [Activity(Label = "SDN.Rss", Icon = "@drawable/ic_launcher", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(Color.FromHex("#98BE0D").ToAndroid());
            }

            LoadApplication(new App());
        }
    }
}