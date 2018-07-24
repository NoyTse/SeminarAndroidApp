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

namespace SeminarAndroidApp.Activities.LessonScreen
{
    [Activity(Label = "LessonActivity", Theme = "@style/Theme.AppCompat.Light.NoActionBar", WindowSoftInputMode = Android.Views.SoftInput.StateHidden)]
    public class LessonActivity : AppCompatActivity
    {
        private string txt1 = "Old education him departure any arranging one prevailed. Their end whole might began her. Behaved the comfort another fifteen eat. Partiality had his themselves ask pianoforte increasing discovered. So mr delay at since place whole above miles. He to observe conduct at detract because. Way ham unwilling not breakfast furniture explained perpetual. Or mr surrounded conviction so astonished literature. Songs to an blush woman be sorry young. We certain as removal attempt.";
        private string txt2 = "Promotion an ourselves up otherwise my. High what each snug rich far yet easy. In companions inhabiting mr principles at insensible do. Heard their sex hoped enjoy vexed child for. Prosperous so occasional assistance it discovered especially no. Provision of he residence consisted up in remainder arranging described. Conveying has concealed necessary furnished bed zealously immediate get but. Terminated as middletons or by instrument. Bred do four so your felt with. No shameless principle dependent household do. ";
        private string txt3 = "Sentiments two occasional affronting solicitude travelling and one contrasted. Fortune day out married parties. Happiness remainder joy but earnestly for off. Took sold add play may none him few. If as increasing contrasted entreaties be. Now summer who day looked our behind moment coming. Pain son rose more park way that. An stairs as be lovers uneasy. ";
        private string txt4 = "When be draw drew ye. Defective in do recommend suffering. House it seven in spoil tiled court. Sister others marked fat missed did out use. Alteration possession dispatched collecting instrument travelling he or on. Snug give made at spot or late that mr. ";
        private string txt5 = "When be draw drew ye. ";
        private string pic1URL = "http://bdfjade.com/data/out/18/5270890-picture-of-cartoon.png";
        private string pic2URL = "https://78.media.tumblr.com/avatar_475efc096228_128.pnj";

        List<UIMsg> mMsgList;
        ListView mListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LessonScreen);

            mListView = FindViewById<ListView>(Resource.Id.listView);
            mMsgList = new List<UIMsg>();
            mMsgList.Add(new UIMsg() { Content = txt1, Side = UIMsg.eSide.CurrentUser });
            mMsgList.Add(new UIMsg() { Content = txt2, Side = UIMsg.eSide.OtherUsers });
            mMsgList.Add(new UIMsg() { Content = txt3, Side = UIMsg.eSide.CurrentUser });
            mMsgList.Add(new UIMsg() { Content = txt5, Side = UIMsg.eSide.CurrentUser, AttachmentImgURL = pic1URL });
            mMsgList.Add(new UIMsg() { Content = txt5, Side = UIMsg.eSide.OtherUsers });
            mMsgList.Add(new UIMsg() { Content = txt1, Side = UIMsg.eSide.OtherUsers, AttachmentImgURL = pic2URL});
            mMsgList.Add(new UIMsg() { Content = txt5, Side = UIMsg.eSide.CurrentUser });
            mMsgList.Add(new UIMsg() { Content = txt5, Side = UIMsg.eSide.OtherUsers, AttachmentImgURL = pic1URL });

            mListView.Adapter = new ListAdapter(this, mMsgList);

            ImageView sendBtn = FindViewById<ImageView>(Resource.Id.btnSend);
            EditText txtQuestionField = FindViewById<EditText>(Resource.Id.txtInputMsg);
            sendBtn.Click += (sender, e) =>
            {
                if (txtQuestionField.Text.Equals("")) return;
                addCurrentUserMsg(txtQuestionField.Text);
            };
        }

        private void addCurrentUserMsg(string txt)
        {
            mMsgList.Add(new UIMsg() { Content = txt, Side = UIMsg.eSide.CurrentUser });
            mListView.Adapter = new ListAdapter(this, mMsgList);
        }
    }
}