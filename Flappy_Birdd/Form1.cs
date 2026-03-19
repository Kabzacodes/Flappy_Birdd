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
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 13;           //when Space is released, the bird will fall down
            }   
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Space)
            { 
                gravity = -9 ;           //when Space is prerssed, the bird will go up
            }

        }

        private void endGame()
        {
            gameTimer.Stop();         //the game will stop when the bird hits the pipe, the ground or goes out of the screen
            // text"     Game Over!  " + score;     //when the game is over, "Game Over!" will be shown on the screen
        }
    }
}
