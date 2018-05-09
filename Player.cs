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

namespace Rogue_Two_
{
    class Player
    {
        Canvas canvas;
        Window window;
        int counter = 0;
        public Point pos;
        public Rectangle rectangle;
        public Player(Canvas c,Window w)
        {
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
            if(Keyboard.IsKeyUp(Key.Left)&& Keyboard.IsKeyUp(Key.Right) && Keyboard.IsKeyUp(Key.Up) && Keyboard.IsKeyUp(Key.Down))
            {
                counter = 0;
            }
            if (counter == 0)
            {
                if(Keyboard.IsKeyDown(Key.Up))
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

    }
}
