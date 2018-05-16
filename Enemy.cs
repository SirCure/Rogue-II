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
        Player player;
        Canvas canvas;
        Map map;
        int levelProgress = 1;
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
        ImageBrush stormtSprite = new ImageBrush(new BitmapImage(new Uri("H:/My Documents/ICS3U/Unit 4/Rogue II/Rogue II/StormtrooperForward.png")));
        //higher level, more exp for player
        int level;
        int enemyType;
        bool alive = true;
        
        Random random = new Random();
        public Enemy (Canvas c, Window w)
        {
            canvas = c;
            window = w;
            //System.IO.StreamReader streamReader = new System.IO.StreamReader("map" + levelProgress + ".txt");
            enemyRectangle = new Rectangle();
            enemyRectangle.Height = 100;
            enemyRectangle.Width = 100;  
            if (levelProgress == 1)
            {   //stormtrooper hoth
                enemyRectangle.Fill = new ImageBrush(new BitmapImage(new Uri("StormtrooperForward.png", UriKind.Relative)));
                Canvas.SetLeft(enemyRectangle, 100);
                hp = 10;
                maxHP = 10;
                strength = 12;
                armour = 3;
                int level = 1;
                canvas.Children.Add(this.enemyRectangle);
                
            }

            
        }
        
        public void enemyMove()
        {
            
        }
        
        public void death()
        {
            canvas.Children.Remove(enemyRectangle);
        }
    }
}
