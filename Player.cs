using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Rogue_II
{
    class Player
    {
        //Stats
        int Level;
        int MaxStrength = 16;
        int Strength;
        int MaxHP = 12;
        int HP;
        int Armour = 4;
        int GoldCount;
        int XP;
        int Collectibles;
        //Item[] Inventory = new Item[];
        bool hasForce = false;
        bool Alive = true;
        //ImageBrush PixelArt = new ImageBrush(new BitmapImage(new Uri()));
        Canvas canvas;
        Window window;
        int counter = 0;
        public Point pos;
        public Rectangle rectangle;
        public Player(Canvas c, Window w)
        {
            //Initialize stats
            Strength = MaxStrength;
            HP = MaxHP;
            GoldCount = 0;
            XP = 0;
            Level = 1;
            canvas = c;
            window = w;
            rectangle = new Rectangle();
            rectangle.Height = 10;
            rectangle.Width = 10;
            rectangle.Fill = Brushes.White;
            canvas.Children.Add(rectangle);
        }
        public void move()
        {
            if (Keyboard.IsKeyUp(Key.Left) && Keyboard.IsKeyUp(Key.Right) && Keyboard.IsKeyUp(Key.Up) && Keyboard.IsKeyUp(Key.Down))
            {
                counter = 0;
            }
            if (counter == 0)
            {
                if (Keyboard.IsKeyDown(Key.Up))
                {
                    pos.Y -= 10;
                    counter++;
                }
                if (Keyboard.IsKeyDown(Key.Down))
                {
                    pos.Y += 10;
                    counter++;
                }
                if (Keyboard.IsKeyDown(Key.Left))
                {
                    pos.X -= 10;
                    counter++;
                }
                if (Keyboard.IsKeyDown(Key.Right))
                {
                    pos.X += 10;
                    counter++;
                }
                Canvas.SetLeft(rectangle, pos.X);
                Canvas.SetTop(rectangle, pos.Y);
            }
        }
        //Change parameter to Map map
        public void reveal()
        {

        }
        public void itemPickUp(Point[] parray)
        {

        }
        //Change to Enemy enemy
        public void melee()
        {
            
        }
        public void ranged()
        {
            if(Keyboard.IsKeyDown(Key.LeftShift)&&Keyboard.IsKeyDown(Key.A))
            {

            }
        }
        //Change to Map map
        public void mapCollide()
        {

        }

    }
}
