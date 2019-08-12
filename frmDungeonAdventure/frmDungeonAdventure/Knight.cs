using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace frmDungeonAdventure
{
    class Knight
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Image knight;//variable for the knight's image
        public Rectangle spaceRec;//variable for a rectangle to place our image in
        public int lives;

        //Create a constructor (initialises the values of the fields)
        public Knight()
        {
            x = 400;
            y = 150;
            width = 38;
            height = 44;
            knight = Image.FromFile("Knight2.png");
            spaceRec = new Rectangle(x, y, width, height);


        }

        //methods
        public void drawKnight(Graphics g)
        {

            g.DrawImage(knight, spaceRec);
        }

        public void moveKnight(string move)
        {
            if (move == "right")
            {
                if (spaceRec.Location.X > 485) // is knight within 485 of right side
                {

                    x = 485;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x += 5;
                    spaceRec.Location = new Point(x, y);
                }

            }

            if (move == "left")
            {
                if (spaceRec.Location.X < 5) // is knight within 5 of left side
                {

                    x = 5;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x -= 5;
                    spaceRec.Location = new Point(x, y);
                }

            }

            if (move == "up")
            {
                if (spaceRec.Location.Y < 5) // is knight within 5 of top
                {

                    y = 5;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    y -= 5;
                    spaceRec.Location = new Point(x, y);
                }

            }
            if (move == "down")
            {
                if (spaceRec.Location.Y > 310) // is knight within 310 of bottom
                {

                    y = 310;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    y += 5;
                    spaceRec.Location = new Point(x, y);
                }

            }


        }



    }
}
