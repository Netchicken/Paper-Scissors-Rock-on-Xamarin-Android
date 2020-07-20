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

            Init();
        }

        private void Init()
        {
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

        //this method runs the entire game
        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Hum = rb.Text;
            txtMainMessage.Text = Name + " you chose " + Hum;
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {

            string Comp = GamePlay.ComputerChoice();
            string Result = GamePlay.Play(Hum, Comp);

            switch (Result)
            {
                case "Win":
                    txtMainMessage.Text = "Well you won that!" + Environment.NewLine + Hum + " beats " + Comp;
                    GamePic.SetImageResource(Resource.Drawable.win);
                    break;
                case "Lose":
                    txtMainMessage.Text = "Well you Lost that!" + Environment.NewLine + Comp + " beats " + Hum;
                    GamePic.SetImageResource(Resource.Drawable.lose);
                    break;

                case "Draw":
                    txtMainMessage.Text = "It was a draw!" + Environment.NewLine + Hum + " and " + Comp;
                    GamePic.SetImageResource(Resource.Drawable.ww2);
                    break;
            }
        }

    }
}