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

namespace SeminarAndroidApp.Activities.LoginScreen
{
    [Activity(Label = "LoginActivity", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar", WindowSoftInputMode = Android.Views.SoftInput.StateHidden)]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.loginScreen);
            EditText txtEmail = FindViewById<EditText>(Resource.Id.txtLoginEmail);
            Button loginBtn = FindViewById<Button>(Resource.Id.btnLogin);
            loginBtn.Click += (sender, e) =>
            {
                if (txtEmail.Text.Equals(""))
                    FindViewById<TextView>(Resource.Id.lblLoginValidation).Visibility = ViewStates.Visible;
                else
                    login(txtEmail.Text);        
            };
        }
        private void login(string i_email)
        {
            Intent intent = new Intent(this, typeof(LessonScreen.LessonActivity));
            this.StartActivity(intent);
        }
    }
}