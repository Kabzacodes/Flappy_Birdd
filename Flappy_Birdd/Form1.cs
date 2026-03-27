using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Birdd
{
    public partial class Form1 : Form
    {
        //variables being used in the game
        int pipeSpeed = 6;
        int gravity = 13;        
        int score = 0;
        bool gameOver = false;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;               //the bird will fall down or go up by gravity
            pipeBottom.Left -= pipeSpeed;           //the bottom pipe will move to the left
            pipeTop.Left -= pipeSpeed;              //the top pipe will move to the left
            scoreText.Text = score.ToString();      //the score will be shown on the screen and it has been converted to string

            if (pipeBottom.Left < -150)                 //when the bottom pipe goes out of the screen, it will come back to the right side of the screen
            {
                pipeBottom.Left = 800;
                score++;                               //score will increase by 1 when the pipe goes out of the screen, indicating that flappybird has passed a pipe
            }
            if (pipeTop.Left < -170)                   //when the bottom pipe comes back to the right side of the screen, the top pipe will also come back to the right side of the screen
            {
                pipeTop.Left = 950;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || 
                flappyBird.Bounds.IntersectsWith(skyLimit.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds )
                ) 
                
            {
               endGame();                                     //when the bird hits the pipe, the ground or goes out of the screen, the game will end
            }

            if(score > 10)              //when the score is higher than 10, the speed of the pipe will increase to 8,thus making the game more difficult
            {
                pipeSpeed = 8;
            }

            if(score > 20)              //when the score is higher than 20, the speed of the pipe will increase to 10, thus making the game more difficult
            {
                pipeSpeed = 10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 13;           //when Space is released, the bird will fall down
            }

            if (e.KeyCode == Keys.Enter && gameOver)
            {
                 restartGame();            //when Enter is pressed and the game is over, the game will restart
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Space)
            { 
                gravity = -9 ;           //when Space is pressed, the bird will go up
            }

        }

        private void endGame()
        {
            gameTimer.Stop();         //the game will stop when the bird hits the pipe, the ground or goes out of the screen
            scoreText.Text = "Score: "+score +" GameOver! Press Enter to retry";
           gameOver = true;          //the gameOver variable will be true when the game ends
        }

        private void restartGame()
        {
            flappyBird.Location = new Point(100, 150);   //the bird will come back to the original position
            gameTimer.Start();        //the game will start when Enter is pressed
            pipeBottom.Left = 800;    //the bottom pipe will come back to the right side of the screen
            pipeTop.Left = 950;       //the top pipe will come back to the right side of the screen
            score = 0;               //the score will be reset to 0
            gameOver = false;        //the gameOver variable will be false when the game restarts
        }
    }
}
