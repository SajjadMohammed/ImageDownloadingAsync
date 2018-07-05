using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

using V7ToolBar = Android.Support.V7.Widget.Toolbar;

namespace LoadingImage
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        V7ToolBar mainToolBar;
        ProgressBar myProgressBar;
        ImageView myImage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            mainToolBar = FindViewById<V7ToolBar>(Resource.Id.toolbar);
            SetSupportActionBar(mainToolBar);
            //
            myProgressBar = FindViewById<ProgressBar>(Resource.Id.myProgressBar);
            myImage = FindViewById<ImageView>(Resource.Id.myImage);

            //
            var url = "https://avatars2.githubusercontent.com/u/30750038?s=460&v=4";
            DownloadAsync downloadAsync = new DownloadAsync(this, myImage, myProgressBar);
            downloadAsync.DownloadImageAsync(url);
        }
    }
}