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
    static class GamePlay
    {
        public static string ComputerChoice()
        {
            //create a new instance of the Random Class
            var CompGuess = new Random();
            //This code generates a random integer between 1 and 4, but 4 is not inclusive, meaning the only possibilities are 1, 2 and 3
            //1 represents paper, 2 represents scissors, 3 represents rock 
            string[] Guess = { "", "Paper", "Scissors", "Rock" };
            return Guess[CompGuess.Next(1, 4)];
        }

        public static string Play(string Hum, string Comp)
        {

            //WIN
            if (Hum == "Paper" && Comp == "Rock"
                || Hum == "Scissors" && Comp == "Paper"
                || Hum == "Rock" && Comp == "Scissors")

            {
                return "Win";
            }

            //DRAW
            else if (Hum == Comp)
            {
                return "Draw";
            }
            //LOSE
            else
            {
                return "Lose";
            }
        }

    }
}