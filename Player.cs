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
        public int Level;
        public int MaxStrength = 16;
        public int Strength;
        public int MaxHP = 12;
        public int HP;
        public int Armour = 4;
        public int GoldCount;
        public int XP;
        public int Collectibles;

        //Item[] Inventory = new Item[];
        int meleeSlot = 0;
        int rangedSlot = 1;
        int helmetSlot = 2;
        int chestSlot = 3;
        int pantSlot = 4;

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
            rectangle.Height = 15;
            rectangle.Width = 15;
            //rectangle.Fill = Brushes.White;
            rectangle.Fill = new ImageBrush(new BitmapImage(new Uri("E:/@.png")));
            canvas.Children.Add(rectangle);
            rectangle.Visibility = Visibility.Hidden;
        }
        public void move(Key key)
        {
                if (key == Key.Up)
                {
                    pos.Y -= 10;
                    counter++;
                }
                if (key == Key.Down)
                {
                    pos.Y += 10;
                    counter++;
                }
                if (key == Key.Left)
                {
                    pos.X -= 10;
                    counter++;
                }
                if (key == Key.Right)
                {
                    pos.X += 10;
                    counter++;
                }
                Canvas.SetLeft(rectangle, pos.X);
                Canvas.SetTop(rectangle, pos.Y);
            /*if(Keyboard.IsKeyUp(Key.A)&& Keyboard.IsKeyUp(Key.D) && Keyboard.IsKeyUp(Key.S) && Keyboard.IsKeyUp(Key.W))
            {
                counter = 0;
            }
            else
            {
                counter = 1;
            }*/
        }
        //Change parameter to Map map
        public void reveal()
        {

        }
        //Changed to Item[] itemArray
        public void itemPickUp(Point[] parray)
        {
            for(int i = 0;i<parray.Length;i++)
            {
                //Point location = itemArray[i].pos
                if(this.pos == parray[i])
                {

                }
            }
        }
        //Change to Enemy enemy
        public void melee()
        {
            
        }
        //Change to Enemy[] enemyArray, change 8 to enemyArray.Length
        public void ranged(Point[] pArray)
        {
            if(Keyboard.IsKeyDown(Key.LeftShift)&&Keyboard.IsKeyDown(Key.A))
            {
                for(int i = 0;i<pArray.Length;i++)
                {
                    Point location = pArray[i];
                    if(this.pos.X == location.X&&this.pos.Y>location.Y&&location.Y+20>=this.pos.Y)
                    {
                      //int dmg = Inventory[rangedSlot].dmg
                      //enemyArray[i].Health -=dmg;+
                    }
                }
            }
        }
        //Change to Map map
        public void mapCollide()
        {

        }

    }
}
