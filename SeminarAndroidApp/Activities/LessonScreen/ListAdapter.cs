using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.MS.Square.Android.Expandabletextview;
using Android.Views.Animations;
using Square.Picasso;

namespace SeminarAndroidApp.Activities.LessonScreen
{
    class ListAdapter : BaseAdapter<UIMsg>
    {
        AppCompatActivity mContext;
        List<UIMsg> mList;
        public ListAdapter(AppCompatActivity i_context, List<UIMsg> i_list)
        {
            mContext = i_context;
            mList = i_list;
        }
        public override UIMsg this[int position] => mList[position];

        public override int Count => mList.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View listItemView = null;
            switch (mList[position].Side)
            {
                case UIMsg.eSide.OtherUsers:
                    listItemView = mContext.LayoutInflater.Inflate(Resource.Layout.LeftExpMsg, null);
                    ImageView joinQtnBtn = listItemView.FindViewById<ImageView>(Resource.Id.imgBtnJoinQuestion);
                    joinQtnBtn.Click += (sender, args) =>
                    {
                        joinQtnBtn.StartAnimation(AnimationUtils.LoadAnimation(this.mContext, Resource.Animation.likeAnimation));
                        joinQtnBtn.Enabled = false;
                        joinQtnBtn.SetImageResource(Resource.Drawable.ic_bigHeart);
                    };
                    break;
                case UIMsg.eSide.CurrentUser:
                    listItemView = mContext.LayoutInflater.Inflate(Resource.Layout.RightExpMsg, null);
                    break;
            }
            
            ExpandableTextView mExpTextView = listItemView.FindViewById<ExpandableTextView>(Resource.Id.expand_text_view);
            mExpTextView.Text = mList[position].Content;
            ImageView thumbScreenshot = listItemView.FindViewById<ImageView>(Resource.Id.imgThumbScreenshot);
            if (mList[position].AttachmentImgURL == null)
            {
                thumbScreenshot.Visibility = ViewStates.Gone;
            }
            else
            {
                thumbScreenshot.Click += (sender, args) =>
                {
                    FragmentTransaction transaction = mContext.FragmentManager.BeginTransaction();
                    ScreenshotFullSizeDialog dialog = new ScreenshotFullSizeDialog(mList[position].AttachmentImgURL);
                    dialog.Show(transaction, "Screenshot FullSize");
                };
            }

            return listItemView;
        }

        public void AddItem(UIMsg i_Msg)
        {
            mList.Add(i_Msg);
        }
    }
}