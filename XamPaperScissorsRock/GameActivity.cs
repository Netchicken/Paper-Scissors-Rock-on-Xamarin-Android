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
using Environment = System.Environment;

namespace XamPaperScissorsRock
{
    [Activity(Label = "Paper Scissors Rock")]

    //https://developer.xamarin.com/guides/android/user_interface/form_elements/radiobutton/ Radiobutton code

    public class GameActivity : Activity
    {
        private ImageView GamePic;
        private string Name, Hum;
        private TextView txtMainMessage;
        private Button btnPlay;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //load the game screen
            SetContentView(Resource.Layout.Game);

            //Pass the name across to the game
            Name = Intent.GetStringExtra("Name");


            TextView txtMessage = FindViewById<TextView>(Resource.Id.tvName);
            txtMainMessage = FindViewById<TextView>(Resource.Id.tvMessage);
            txtMessage.Text = "Choose an option " + Name;
            txtMainMessage.Text = "Be prepared to be beaten!";
            GamePic = FindViewById<ImageView>(Resource.Id.imageAnswer);

            //Radiobutton binding
            RadioButton RPaper = FindViewById<RadioButton>(Resource.Id.radio_paper);
            RadioButton RScissors = FindViewById<RadioButton>(Resource.Id.radio_scissors);
            RadioButton RRock = FindViewById<RadioButton>(Resource.Id.radio_rock);

            //radiobuttons going to same click event
            RPaper.Click += RadioButtonClick;
            RScissors.Click += RadioButtonClick;
            RRock.Click += RadioButtonClick;


            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnPlay.Click += btnPlay_Click;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string Comp = ComputerChoice();

            // Toast.MakeText(this, Name + " " + Hum + " vrs Comp = " + comp, ToastLength.Long).Show();
            txtMainMessage.Text = Name + " " + Hum + Environment.NewLine + " vrs Comp = " + Comp;

            //WIN
            if (Hum == "Paper" && Comp == "Rock"
                || Hum == "Scissors" && Comp == "Paper"
                || Hum == "Rock" && Comp == "Scissors")

            {
                GamePic.SetImageResource(Resource.Drawable.win);
                //   Toast.MakeText(this, "Well you won that!", ToastLength.Long).Show();
                txtMainMessage.Text = "Well you won that!" + Environment.NewLine + Hum + " beats " + Comp;
            }

            //DRAW
            else if (Hum == Comp)
            {
                GamePic.SetImageResource(Resource.Drawable.ww2);
                //   Toast.MakeText(this, "Draw", ToastLength.Long).Show();

                txtMainMessage.Text = "It was a draw!" + Environment.NewLine + Hum + " and " + Comp; ;
            }
            //LOSE
            else
            {
                GamePic.SetImageResource(Resource.Drawable.lose);
                //   Toast.MakeText(this, "Suck on that " + Name, ToastLength.Short).Show();
                txtMainMessage.Text = "Well you Lost that!" + Environment.NewLine + Comp + " beats " + Hum; ;
            }
        }

        //this method runs the entire game
        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Hum = rb.Text;
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