using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_The_Game
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();

        private Circle food = new Circle();



        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;





        public Form1()
        {
            InitializeComponent();


            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }

            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {

        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {

        }

        private void RestartGame()
        {
            //put in all the default values that we want the game to start with


            // we want to have a bit of padding for the snake so that it will not appear too close to the border
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;


            Snake.Clear();
            // if theres any existing child inside the list, it will clear all of it


            startButton.Enabled = false;
            snapButton.Enabled = false;
            //if the buttons are enabled, we wont be able to use the keys on the keyboard

            score = 0;
            txtScore.Text = "Score: " + score;

            //create the bodypart for the snake
            Circle head = new Circle { X = 10, Y = 5 };

            Snake.Add(head);//adding the head part to the list

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }
            food = new Circle { X = rand.Next(2,maxWidth), Y = rand.Next(2,maxHeight)};//randomly generate a number between 2 and the max width

           gameTimer.Start();
        }

        private void EatFood()
        {


        }

        private void GameOver()
        {

        }






    }
}
