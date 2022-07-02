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
            //setting the dirctions
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";

            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            //end of setting the directions

            //make sure that all the body parts are moving accordingly
            for (int i = Snake.Count -1 ; i >= 0 ; i--)
            {

                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":

                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }


                    //make the snake appear on the ofther side


                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }

                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }

                    //eating the food 
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }


                    //if the snake eats a part of its own body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }







                }
                else
                {
                    ///one body part will follow the other
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;

                }


            }

            picCanvas.Invalidate();



        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor;

            for (int i = 0; i < Snake.Count; i++)
                //loop for snake, head and body
            {
                if  (i == 0 )
                    //this will be the head of the snake
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor= Brushes.DarkCyan;
                }


                canvas.FillEllipse
                    (snakeColor, new Rectangle                    
                        (
                        Snake[i].X*Settings.Width,
                        Snake[i].Y*Settings.Height,
                        Settings.Width,Settings.Height));
            }
            //this will be the food
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * Settings.Width,
            food.Y * Settings.Height,
            Settings.Width, Settings.Height
            ));



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
            score += 1;

            txtHighScore.Text = "Score: " + score;




            //add a bodypart to the circle
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y,
            };
            Snake.Add(body);
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };//randomly generate a number between 2 and the max width

        }

        private void GameOver()
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;



            if (score > highScore)
            {

                highScore = score;

                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }






    }
}
