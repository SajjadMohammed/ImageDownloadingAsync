using Android.Graphics;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

using System.Net.Http;

namespace LoadingImage
{
    internal class DownloadAsync
    {
        ProgressBar mypProgressBar;
        ImageView myImage;
        readonly MainActivity mainActivity;

        public DownloadAsync(MainActivity mainActivity, ImageView myImage, ProgressBar mypProgressBar)
        {
            this.mainActivity = mainActivity;
            this.mypProgressBar = mypProgressBar;
            this.myImage = myImage;
        }

        public async void DownloadImageAsync(string url)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetByteArrayAsync(url);
            var bmp = await BitmapFactory.DecodeByteArrayAsync(content, 0, content.Length);
            var anim = AnimationUtils.LoadAnimation(mainActivity, Android.Resource.Animation.FadeIn);
            myImage.Animation = anim;
            myImage.SetImageBitmap(bmp);
            mypProgressBar.Visibility = ViewStates.Gone;
        }
    }
}