using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Rogue_II
{
    class Map
    {
        //Class variables.
        Canvas canvas;
        Window window = new Window();
        List<Rectangle> rectangle = new List<Rectangle>();
        int mapNum;
        enum maplist {Hoth}
        string line;
        string tile;
        public int xPos;
        public int yPos = 0;

        public Map(Canvas C)
        {
            canvas = C;
            //Sets size of rectangles.
            //rectangle.Width = 10;
            //rectangle.Height = 10;
            //rectangle.StrokeThickness = 1;
        }

        //A method to generate a given map from the read file.
        public void generateMap(int mapLevel)
        {
            mapNum = mapLevel;
            mapNum = 0;
            if (mapNum == 0)
            {
                StreamReader streamReader = new System.IO.StreamReader("hoth_map.txt");
                while (!streamReader.EndOfStream)
                {
                    xPos = -10;
                    yPos += 10;
                    line = streamReader.ReadLine();
                    for (int i = 0; i < line.Length; i++)
                    {
                        tile = line[i].ToString();
                        xPos += 10;
                        rectangle.Add(new Rectangle());
                        rectangle[rectangle.Count - 1].Width = 10;
                        rectangle[rectangle.Count - 1].Height = 10;
                        rectangle[rectangle.Count - 1].StrokeThickness = 1;
                        Canvas.SetLeft(rectangle[rectangle.Count - 1], xPos);
                        Canvas.SetTop(rectangle[rectangle.Count - 1], yPos);
                        if (tile == ".")
                        {
                            
                            rectangle[rectangle.Count - 1].Fill = Brushes.Salmon;
                            
                        }

                        if (tile == "|")
                        {
                            rectangle[rectangle.Count - 1].Fill = Brushes.Gray;
                        }
                        canvas.Children.Add(rectangle[rectangle.Count - 1]);
                    }
                }
            }

            if (mapNum == 1)
            {

            }

            if (mapNum == 2)
            {

            }

            if (mapNum == 3)
            {

            }

            if (mapNum == 4)
            {

            }
        }
    }
}
