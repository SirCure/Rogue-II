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
        enum maplist { Hoth }
        string line;
        string tile;
        public int xPos;
        public int yPos = 0;
        public string[,] grid = new string[12, 9];
        int lineNumber = -1;

        public Map(Canvas C)
        {
            canvas = C;
        }

        //A method to generate a given map from the read file.
        public void generateMap(int mapLevel)
        {
            mapNum = mapLevel;
            mapNum = 0;

            //Generates a grid from the text file that can be read by other classes and used to generate the map.
            StreamReader streamReader = new System.IO.StreamReader("map" + mapNum + ".txt");
            while (!streamReader.EndOfStream)
            {
                lineNumber++;
                line = streamReader.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    tile = line[i].ToString();
                    grid[i, lineNumber] = tile;
                }
            }

            //Takes the values from the grid array and creates rectangles (which represent the map) on the screen.
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    xPos = (x * 30);
                    yPos = (y * 30);
                    rectangle.Add(new Rectangle());
                    rectangle[rectangle.Count - 1].Width = 30;
                    rectangle[rectangle.Count - 1].Height = 30;
                    rectangle[rectangle.Count - 1].StrokeThickness = 1;
                    Canvas.SetLeft(rectangle[rectangle.Count - 1], xPos);
                    Canvas.SetTop(rectangle[rectangle.Count - 1], yPos);
                    if (grid[x, y] == ".")
                    {
                        rectangle[rectangle.Count - 1].Fill = Brushes.Salmon;
                    }

                    if (grid[x, y] == "|")
                    {
                        rectangle[rectangle.Count - 1].Fill = Brushes.Gray;
                    }
                    canvas.Children.Add(rectangle[rectangle.Count - 1]);
                }
            }
        }
    }
}
