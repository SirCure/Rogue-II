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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Use Cantina Band 1 and 2 for menu,Main Title coruscant for scrolling text,duel of fates for boss level and 
        enum GameState { StartScreen, Menu, GameOn, BossLevel, GameOver };
        GameState gamestate;
        Random r = new Random();
        Point ackbarPos = new Point(355, 400);
        Point TextPos = new Point(0, 529);
        Rectangle ackbar;
        MediaPlayer music = new MediaPlayer();
        DispatcherTimer timer = new DispatcherTimer();
        Label scrollingText = new Label();
        int delay = 0;
        bool hasrun = false;
        bool Bosshasrun = false;
        bool Menuhasrun = false;
        Player player;
        double width = 90;
        double height = 129;
        double textheight = 400;
        double textwidth = 800;
        int otherCounter = 0;
        public MainWindow()
        {
            gamestate = GameState.StartScreen;
            InitializeComponent();
            player = new Player(canvas, this);
            player.rectangle.Visibility = Visibility.Hidden;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100 / 60);
            timer.Tick += tick;
            timer.Start();
            ackbar = new Rectangle();
            ackbar.Height = height;
            ackbar.Width = width;
            ackbar.Fill = new ImageBrush(new BitmapImage(new Uri("E:/Untitledbutackbarbutwhite.png")));
            scrollingText.Height = 400;
            scrollingText.Width = 800;
            scrollingText.HorizontalContentAlignment = HorizontalAlignment.Center;
            scrollingText.VerticalContentAlignment = VerticalAlignment.Top;
            scrollingText.Content = "Rogue II";
            scrollingText.FontSize = 42;
            scrollingText.FontFamily = new FontFamily("Times New Roman");
            scrollingText.Foreground = Brushes.Yellow;
            scrollingText.Background = Brushes.Black;
            Canvas.SetLeft(scrollingText, TextPos.X);
            Canvas.SetTop(scrollingText, TextPos.Y);
            canvas.Children.Add(scrollingText);
            canvas.Children.Add(ackbar);
            Canvas.SetLeft(ackbar, ackbarPos.X);
            Canvas.SetTop(ackbar, ackbarPos.Y);
            music.Open(new Uri("E:/13BinarySunsetAlternate/01 Star Wars Main Title And Ambush On Coruscant.mp3"));
            music.Play();
        }
        private void tick(object sender, EventArgs e)
        {
            if (gamestate == GameState.StartScreen)
            {
                delay++;
                if (delay >= 6)
                {
                    delay = 0;
                    TextPos.Y -= 3;
                    ackbarPos.Y -= 3;
                    otherCounter++;
                    //canvas.Children.RemoveAt(0);
                    if (height > 0 && width > 0 && otherCounter == 6)
                    {
                        //textwidth -= 10;
                        //textheight -= 1;
                        height -= 1.5*129 / 90;
                        width -= 1.5;
                        otherCounter = 0;
                        scrollingText.FontSize -=0.5;
                        TextPos.Y -= 2;
                        ackbarPos.X += 0.75;
                    }
                    scrollingText.Width = textwidth;
                    scrollingText.Height = textheight;
                    ackbar.Width = width;
                    ackbar.Height = height;
                    //canvas.Children.Add(ackbar);
                    Canvas.SetLeft(scrollingText, TextPos.X);
                    Canvas.SetTop(scrollingText, TextPos.Y);
                    Canvas.SetTop(ackbar, ackbarPos.Y);
                    Canvas.SetLeft(ackbar, ackbarPos.X);
                    if (TextPos.Y < -100 || Keyboard.IsKeyDown(Key.Escape))
                    {
                        music.Stop();
                        gamestate = GameState.Menu;
                        scrollingText.Visibility = Visibility.Hidden;
                        ackbar.Visibility = Visibility.Hidden;
                    }
                }
            }
            else if (gamestate == GameState.Menu)
            {
                if (Menuhasrun == false)
                {
                    music.Open(new Uri("E:/13BinarySunsetAlternate/12 Cantina Band #2.mp3"));
                    music.Play();
                    music.MediaEnded += MenunextSong;
                    Menuhasrun = true;
                }
                if (Keyboard.IsKeyDown(Key.Enter))
                {
                    music.Stop();
                    gamestate = GameState.GameOn;
                }
            }
            else if (gamestate == GameState.GameOn)
            {
                if (hasrun == false)
                {
                    music.Open(new Uri("E:/13BinarySunsetAlternate/10 Mos Eisley Spaceport.mp3"));
                    music.Play();
                    player.rectangle.Visibility = Visibility.Visible;
                    hasrun = true;
                }
                player.move();
            }
            else if (gamestate == GameState.BossLevel)
            {
                if (Bosshasrun == false)
                {
                    music.Open(new Uri("E:/13BinarySunsetAlternate/02 Duel Of The Fates.mp3"));
                    music.Play();
                    //player.rectangle.Visibility = Visibility.Visible;
                    Bosshasrun = true;
                }
                player.move();
            }

        }
        private void MenunextSong(object sender, EventArgs e)
        {
            music.Stop();
            int random = r.Next(0, 2);
            if(random == 0)
            {
                music.Open(new Uri("E:/13BinarySunsetAlternate/11 Cantina Band.mp3"));
                
            }
            if(random == 1)
            {
                music.Open(new Uri("E:/13BinarySunsetAlternate/12 Cantina Band #2.mp3"));
            }
            music.Play();

        }
    }
}
