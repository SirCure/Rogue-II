using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rogue_II
{
    class Enemy
    {
        
        Canvas canvas;
        Window window;
        //the point where the enemy is located
        Point enemyPos = new Point(x:1, y:1);
        //the enemyRectangle is where the sprite will be, and there will be collision with it
        public Rectangle enemyRectangle = new Rectangle();
        //these ints are for enemy stats
        int hp;
        int maxHP;
        int strength;
        int armour;
        //higher level, more exp for player
        int level;
        int enemyType;
        bool alive = true;
        public Enemy (Canvas c, Window w)
        {
            canvas = c;
            window = w;
            enemyRectangle = new Rectangle();
            enemyRectangle.Height = 100;
            enemyRectangle.Width = 100;
           
            canvas.Children.Add(enemyRectangle);
        }
        public void stormtrooper(Canvas canvas, Window window)
        {
            enemyRectangle.Fill = new ImageBrush(new BitmapImage(new Uri("StormtrooperForward.png")));
            hp = 10;
            maxHP = 20;
            strength = 0;
            armour = 0;
            level = 2;
            if(hp == 0)
            {
                alive = false;
            }
            if(alive == false)
            {
                enemyRectangle.Visibility = Visibility.Hidden;
            }
        }

        public void enemyMove()
        {

        }
        
    }
}
