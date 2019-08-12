using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace frmDungeonAdventure
{
    public partial class FrmDungeonAdventure : Form
    {
        Graphics g; //declare a graphics object called g
        // declare space for an array of 7 objects called planet 
        Skeleton[] skeleton = new Skeleton[7];
        Random xspeed = new Random();
        Knight knight = new Knight();
        bool left, right, up, down;
        int score, lives;
        string move;



        public FrmDungeonAdventure()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });


            for (int i = 0; i < 7; i++)
            {
                int y = 10 + (i * 75);
                skeleton[i] = new Skeleton(y);
            }

        }


        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Planet class's DrawSkeleton method to draw the image skeleton1 
            for (int i = 0; i < 5; i++)
            {
                //call the skeleton class's drawSkeleton method to draw the images
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = xspeed.Next(2, 10);
                skeleton[i].x += rndmspeed;

                skeleton[i].drawSkeleton(g);
                knight.drawKnight(g);
            }


        }

        private void FrmDungeonAdventure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Down) { down = true; }

        }

        private void FrmDungeonAdventure_Load(object sender, EventArgs e)
        {
            tmrKnight.Enabled = false;
            tmrSkeleton.Enabled = false;
            lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
            MessageBox.Show("Use the arrow keys to move your knight. \nDon't get hit by the evil skeletons! \nEvery skeleton that gets past scores a point. \nIf a skeleton hits a knight a life is lost! \n \nEnter your Name and click begin adventure to start your quest", "Game Instructions");
            txtName.Focus();
            
            
        }

        private void mnuStart_Click(object sender, EventArgs e)
        {
            score = 0;
            lblScore.Text = score.ToString();
            lives = int.Parse(txtLives.Text);// pass lives entered from textbox to lives variable
            tmrSkeleton.Enabled = true;
            tmrKnight.Enabled = true;

        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            tmrKnight.Enabled = false;
            tmrSkeleton.Enabled = false;

        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("epic.wav");
            player.Play();
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("funny.wav");
            player.Play();  
        }

        private void FrmDungeonAdventure_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Down) { down = false; }
            
        }

        private void tmrKnight_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                knight.moveKnight(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                knight.moveKnight(move);
            }
            if (up) // if up arrow key pressed
            {
                move = "up";
                knight.moveKnight(move);
            }
            if (down) // if down arrow key pressed
            {
                move = "down";
                knight.moveKnight(move);
            }



        }

        private void tmrSkeleton_Tick(object sender, EventArgs e)
        {
            score = 0;
            for (int i = 0; i < 7; i++)
            {
                skeleton[i].moveSkeleton();
                if (knight.spaceRec.IntersectsWith(skeleton[i].skeletonRec))
                {
                    //reset planet[i] back to top of panel
                    skeleton[i].x = 0; // set  y value of skeletontRec
                    lives -= 1;// lose a life
                    txtLives.Text = lives.ToString();// display number of lives
                    checkLives();
                }

                score += skeleton[i].score;// get score from skeleton class (in movePlanet method)
                lblScore.Text = score.ToString();// display score


            }
            pnlGame.Invalidate();//makes the paint event fire to redraw the panel

        }
        private void checkLives()
        {
            if (lives == 0)
            {
                tmrSkeleton.Enabled = false;
                tmrKnight.Enabled = false;
                MessageBox.Show("Game Over");

            }
        }


    }
}
