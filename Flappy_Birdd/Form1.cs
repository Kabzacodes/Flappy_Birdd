using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Birdd
{
    public partial class Form1 : Form
    {
        //variables being used in the game
        int pipeSpeed = 8;
        int gravity = 10;        
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void pipeBottom_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;          //the bird will fall down or go up by gravity
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 10;           //when Space is released, the bird will fall down
            }   
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Space)
            { 
                gravity = -10;           //when Space is prerssed, the bird will go up
            }

        }
    }
}
