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

namespace SeminarAndroidApp.Activities.LessonScreen
{
    class UIMsg
    {
        public enum eSide { OtherUsers, CurrentUser};
        public String Content { get; set; }
        public String AttachmentImgURL { get; set; }
        public eSide Side { get; set; }
    }
}