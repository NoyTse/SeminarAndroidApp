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
using Square.Picasso;

namespace SeminarAndroidApp.Activities.LessonScreen
{
    class ScreenshotFullSizeDialog : DialogFragment
    {
        string mImgURL;
        public ScreenshotFullSizeDialog(string i_imgURL)
        {
            mImgURL = i_imgURL;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            View view = inflater.Inflate(Resource.Layout.ScreenshotDialog,container,false);
            ImageView screenshotImgUI = view.FindViewById<ImageView>(Resource.Id.imgScreenShotOriginal);
            Picasso.With(this.Context).Load(mImgURL).Into(screenshotImgUI);
            ImageView btnClose = view.FindViewById<ImageView>(Resource.Id.btnCloseScreenshotDialog);
            btnClose.Click += (sender, args) => { this.Dismiss(); };
            return view;
        }
    }
}