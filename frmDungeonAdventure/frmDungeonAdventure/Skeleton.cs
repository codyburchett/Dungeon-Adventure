using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace frmDungeonAdventure
{
    class Skeleton
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image skeletonImage;//variable for the skeleton's image

        public Rectangle skeletonRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)
        public Skeleton(int spacing)
        {
            x = 10;
            y = spacing;
            width = 36;
            height = 42;
            skeletonImage = Image.FromFile("Skeleton.png");
            skeletonRec = new Rectangle(x, y, width, height);
        }
        // Methods for the skeleton class
        public void drawSkeleton(Graphics g)
        {
            skeletonRec = new Rectangle(x, y, width, height);
            g.DrawImage(skeletonImage, skeletonRec);
        }
        public void moveSkeleton()
        {

            skeletonRec.Location = new Point(x, y);
            if (skeletonRec.Location.X > 500)
            {
                score += 1;// add 1 to score when skeleton reaches end of panel
                x = 0;
                skeletonRec.Location = new Point(x, y);
            }

        }



    }
}
