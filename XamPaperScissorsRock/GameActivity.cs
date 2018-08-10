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
        private ImageView GamePic;
        private string Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //load the game screen
            SetContentView(Resource.Layout.Game);

            Name = Intent.GetStringExtra("Name");


            TextView txtMessage = FindViewById<TextView>(Resource.Id.tvName);
            txtMessage.Text = "Choose an option " + Name;
            GamePic = FindViewById<ImageView>(Resource.Id.imageAnswer);

            //Radiobutton binding
            RadioButton RPaper = FindViewById<RadioButton>(Resource.Id.radio_paper);
            RadioButton RScissors = FindViewById<RadioButton>(Resource.Id.radio_scissors);
            RadioButton RRock = FindViewById<RadioButton>(Resource.Id.radio_rock);

            //radiobuttons going to same click event
            RPaper.Click += RadioButtonClick;
            RScissors.Click += RadioButtonClick;
            RRock.Click += RadioButtonClick;

        }

        //this method runs the entire game
        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            string comp = ComputerChoice();
            string Hum = rb.Text;
            //   Toast.MakeText(this, Name + " " + Hum + " vrs Comp = " + comp, ToastLength.Long).Show();

            if (Hum == "Paper" && comp == "Rock"
                || Hum == "Scissors" && comp == "Paper"
                || Hum == "Rock" && comp == "Scissors")

            {
                GamePic.SetImageResource(Resource.Drawable.win);
                Toast.MakeText(this, "Won!", ToastLength.Long).Show();
            }
            else if (Hum == comp)

            {

                //  GamePic.SetImageResource(Resource.Drawable.ww2);
                Toast.MakeText(this, "Draw", ToastLength.Long).Show();
            }

            else
            {
                //  GamePic.SetImageResource(Resource.Drawable.lose);
                Toast.MakeText(this, "Suck on that " + Name, ToastLength.Long).Show();

            }
        }

        public string ComputerChoice()
        {
            //create a new instance of the Random Class
            var CompGuess = new Random();
            //This code generates a random integer between 1 and 4, but 4 is not inclusive, meaning the only possibilities are 1, 2 and 3
            //1 represents paper, 2 represents scissors, 3 represents rock 
            string[] Guess = { "", "Paper", "Scissors", "Rock" };
            return Guess[CompGuess.Next(1, 4)];
        }

    }
}