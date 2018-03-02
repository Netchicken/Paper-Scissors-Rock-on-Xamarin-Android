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

namespace XamPaperScissorsRock
{
    [Activity(Label = "Paper Scissors Rock")]

    //https://developer.xamarin.com/guides/android/user_interface/form_elements/radiobutton/ Radiobutton code

    public class GameActivity : Activity
    {
        private TextView txtMessage;
        private ImageView GamePic;
        private string[] Guess = { "", "Paper", "Scissors", "Rock" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //load the game screen
            SetContentView(Resource.Layout.Game);

            txtMessage = FindViewById<TextView>(Resource.Id.tvName);
            txtMessage.Text = "Choose an option " + Intent.GetStringExtra("Name");
            GamePic = FindViewById<ImageView>(Resource.Id.imageAnswer);

            RadioButton RPaper = FindViewById<RadioButton>(Resource.Id.radio_paper);
            RadioButton RScissors = FindViewById<RadioButton>(Resource.Id.radio_scissors);
            RadioButton RRock = FindViewById<RadioButton>(Resource.Id.radio_rock);

            RPaper.Click += RadioButtonClick;
            RScissors.Click += RadioButtonClick;
            RRock.Click += RadioButtonClick;

        }


        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            string comp = ComputerChoice();
            string Hum = rb.Text;
            Toast.MakeText(this, "You " + Hum + " Comp = " + comp, ToastLength.Long).Show();

            if (Hum == "Paper" && comp == "Rock"
                || Hum == "Scissors" && comp == "Paper"
                || Hum == "Rock" && comp == "Scissors")

            {
                GamePic.SetImageResource(Resource.Drawable.win);
            }
            else
            {
                GamePic.SetImageResource(Resource.Drawable.lose);

            }



        }

        public string ComputerChoice()
        {
            //create a new instance of the Random Class
            var CompGuess = new Random();
            //This code generates a random integer between 1 and 4, but 4 is not inclusive, meaning the only possibilities are 1, 2 and 3
            //1 represents paper, 2 represents scissors, 3 represents rock 

            //Send the number back to the program
            return Guess[CompGuess.Next(1, 4)];
        }

    }
}