/*
 * Author:      Dante Jones
 * CLID:        daj3817
 * Class:       CMPS 358
 * Assignment:  Project 3
 * Due Date:    11:55pm / 30 March 2017
 * Description: I am using a windows form in this project to create a whack a mole game.
 * I cerifty that this program was done by myself.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;         //using Threads
using System.Windows.Forms;
using System.Diagnostics;       //using Stopwatch

namespace p3_daj3817
{
    public partial class Form1 : Form
    {
        int num;  //number used to select pictureBox
        Stopwatch sw;   //Stopwatch used to tick timer
        System.Windows.Forms.Timer time;  //Initialize timer
        int score;  //Initialize score

        public Form1()
        {
            InitializeComponent();
        }
        //Initialize delegate 
        private delegate void startProcess();

        private void button1_Click(object sender, EventArgs e)
        {
            //change button text
            button1.Text = "Start Over";
            //score = 0 on start
            score = 0;
            //initializing timer and stopwatch
            time = new System.Windows.Forms.Timer();
            sw = new Stopwatch();
            //timer interval set to 1000 
            time.Interval = 1000;
            //timer tick eventhandler use to display stopwatch time
            time.Tick += new EventHandler(timer1_Tick);

            //start time and stopwatch
            time.Start();
            sw.Start();

            //each pictureBox is invoking a delegate which calls a function that creates a thread
            pictureBox1.Invoke(new startProcess(startThread));
            pictureBox2.Invoke(new startProcess(startThread));
            pictureBox3.Invoke(new startProcess(startThread));
            pictureBox4.Invoke(new startProcess(startThread));
            pictureBox5.Invoke(new startProcess(startThread));
            pictureBox6.Invoke(new startProcess(startThread));

            //if player win or lose the pictureBox set back to the start image
            if (score >= 30 || sw.Elapsed.Seconds >= 50)
            {
                pictureBox1.Image = Properties.Resources.in_hole;
                pictureBox2.Image = Properties.Resources.in_hole;
                pictureBox3.Image = Properties.Resources.in_hole;
                pictureBox4.Image = Properties.Resources.in_hole;
                pictureBox5.Image = Properties.Resources.in_hole;
                pictureBox6.Image = Properties.Resources.in_hole;
            }
        }

        //function called by the thread
        private void startGame()
        {
            //while score is not winning
            while (score < 30)
            {
                //start a random number that is use to select a picture to be highlighted
                Random rand = new Random();
                num = rand.Next(1, 10); //random number between 1 through 10
                if (num == 1)//highlight pictureBox1 and change image
                {
                    pictureBox1.Image = Properties.Resources.out_hole; //image change
                    pictureBox1.BackColor = Color.Red; //highlight is red
                    Thread.Sleep(3000); //sleep thread 3 seconds
                    pictureBox1.BackColor = Color.White; //change color back to normal
                    pictureBox1.Image = Properties.Resources.in_hole;   //change image back to normal
                }
                else if (num == 2)//highlight pictureBox2 and change image
                {
                    pictureBox2.Image = Properties.Resources.out_hole;//image change
                    pictureBox2.BackColor = Color.Red;//highlight is red
                    Thread.Sleep(3000);//sleep thread 3 seconds
                    pictureBox2.BackColor = Color.White;//change color back to normal
                    pictureBox2.Image = Properties.Resources.in_hole;//change image back to normal
                }
                else if (num == 3)//highlight pictureBox3 and change image
                {
                    pictureBox3.Image = Properties.Resources.out_hole;//image change
                    pictureBox3.BackColor = Color.Red;//highlight is red
                    Thread.Sleep(3000);//sleep thread 3 seconds
                    pictureBox3.BackColor = Color.White;//change color back to normal
                    pictureBox3.Image = Properties.Resources.in_hole;//change image back to normal
                }
                else if (num == 4)//highlight pictureBox4 and change image
                {
                    pictureBox4.Image = Properties.Resources.out_hole;//image change
                    pictureBox4.BackColor = Color.Red;//highlight is red
                    Thread.Sleep(3000);//sleep thread 3 seconds
                    pictureBox4.BackColor = Color.White;//change color back to normal
                    pictureBox4.Image = Properties.Resources.in_hole;//change image back to normal
                }
                else if (num == 5)//highlight pictureBox5 and change image
                {
                    pictureBox5.Image = Properties.Resources.out_hole;//image change
                    pictureBox5.BackColor = Color.Red;//highlight is red
                    Thread.Sleep(3000);//sleep thread 3 seconds
                    pictureBox5.BackColor = Color.White;//change color back to normal
                    pictureBox5.Image = Properties.Resources.in_hole;//change image back to normal
                }
                else//highlight pictureBox6 and change image
                {
                    pictureBox6.Image = Properties.Resources.out_hole;//image change
                    pictureBox6.BackColor = Color.Red;//highlight is red
                    Thread.Sleep(3000);//sleep thread 3 seconds
                    pictureBox6.BackColor = Color.White;//change color back to normal
                    pictureBox6.Image = Properties.Resources.in_hole;//change image back to normal
                }
            }
            //trying to end thread not sure if this it the right method to use
            Thread.EndThreadAffinity();
        }

        //create thread and thread goes to startGame
        private void startThread()
        {
            //create thread t that goes to startGame
            Thread t = new Thread(startGame);
            //start thread
            t.Start();
        }

        //timer tick event handler use to display stopwatch time
        private void timer1_Tick(object sender, EventArgs e)
        {
            //winning label displaying directions
            winLabel.Text = "Make it to 30 points before time reach 50sec";
            //timer label text equal to stopwatch in seconds
            timerLabel.Text = sw.Elapsed.Seconds.ToString();
            //score label text equal to score value 
            scoreLabel.Text = score.ToString();
            //if win
            if (score >= 30)
            {
                //timer label text is reset and win label text equals you win
                timerLabel.Text = "0";
                winLabel.Text = "You Win";
            }
            //if lose
            else if (sw.Elapsed.Seconds > 50)
            {
                //timer label text is reset and win label text equals you lose
                timerLabel.Text = "0";
                winLabel.Text = "You Lose";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if highlighted red on click 
            if (pictureBox1.BackColor == Color.Red)
            {
                //add 1 to score
                score += 1;
                //display score text
                scoreLabel.Text = score.ToString();
                //reset highlight back to normal
                pictureBox1.BackColor = Color.White;
                //reset picture back to normal
                pictureBox1.Image = Properties.Resources.in_hole;
            }
            //if click when not highlighted
            else { score -= 1; }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //if highlighted red on click
            if (pictureBox2.BackColor == Color.Red)
            {
                //add 1 to score
                score += 1;
                scoreLabel.Text = score.ToString();//display score text
                pictureBox2.BackColor = Color.White;//reset highlight back to normal
                pictureBox2.Image = Properties.Resources.in_hole;//reset picture back to normal
            }
            //if click when not highlighted
            else { score -= 1; }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //if highlighted red on click
            if (pictureBox3.BackColor == Color.Red)
            {
                //add 1 to score
                score += 1;
                scoreLabel.Text = score.ToString();//display score text
                pictureBox3.BackColor = Color.White;//reset highlight back to normal
                pictureBox3.Image = Properties.Resources.in_hole;//reset picture back to normal
            }
            //if click when not highlighted
            else { score -= 1; }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //if highlighted red on click
            if (pictureBox4.BackColor == Color.Red)
            {
                //add 1 to score
                score += 1;
                scoreLabel.Text = score.ToString();//display score text
                pictureBox4.BackColor = Color.White;//reset highlight back to normal
                pictureBox4.Image = Properties.Resources.in_hole;//reset picture back to normal
            }
            //if click when not highlighted
            else { score -= 1; }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //if highlighted red on click
            if (pictureBox5.BackColor == Color.Red)
            {
                //add 1 to score
                score += 1;
                scoreLabel.Text = score.ToString();//display score text
                pictureBox5.BackColor = Color.White;//reset highlight back to normal
                pictureBox5.Image = Properties.Resources.in_hole;//reset picture back to normal
            }
            //if click when not highlighted
            else { score -= 1; }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //if highlighted red on click
            if (pictureBox6.BackColor == Color.Red)
            {
                //add 1 to score
                score += 1;
                scoreLabel.Text = score.ToString();//display score text
                pictureBox6.BackColor = Color.White;//reset highlight back to normal
                pictureBox6.Image = Properties.Resources.in_hole;//reset picture back to normal
            }
            //if click when not highlighted
            else { score -= 1; }
        }

    }
}
