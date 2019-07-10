using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace XamPaperScissorsRock
{
    [Activity(Label = "Paper Scissors Rock", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //create your local variables
        private Button btnNext;
        private TextView txtName;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Init();
        }

        private void Init()
        {
            //bind the local variable to the layout controls
            txtName = FindViewById<TextView>(Resource.Id.etEnterName);
            btnNext = FindViewById<Button>(Resource.Id.btnNext);
            //create a button click
            btnNext.Click += onNext_Click;
        }

        private void onNext_Click(object sender, EventArgs e)
        {
            //Someone forgot to add a name so you have to catch it
            if (Convert.ToBoolean(txtName.Text == string.Empty))
            {
                Toast.MakeText(this, "Add a name first", ToastLength.Long).Show();
                return;
            }

            //toast check to see its working
            Toast.MakeText(this, "Your name is " + txtName.Text, ToastLength.Long).Show();
            //create an intent - which is what you intend to do
            var gameActivity = new Intent(this, typeof(GameActivity));
            //when the intent run pass across some extra data
            gameActivity.PutExtra("Name", txtName.Text);
            //run the intent and start the other screen passing over the data
            StartActivity(gameActivity);
        }
    }
}

