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
    enum GameState { StartScreen, GameOn, BossLevel, GameOver };
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameState gamestate;
        
        
        
        //All for the Intro - Ignore
        Random r = new Random();
        Point ackbarPos = new Point(355, 800);
        Point TextPos = new Point(0, 929);
        Rectangle ackbar;
        MediaPlayer music = new MediaPlayer();
        DispatcherTimer timer = new DispatcherTimer();
        Label scrollingText = new Label();
        int delay = 0;
        double width = 90;
        double height = 129;
        double textheight = 400;
        double textwidth = 800;
        int otherCounter = 0;
        bool IntroHasRun = false;
        //Intro Variables Over


        public MainWindow()
        {
            InitializeComponent();
            if(IntroHasRun == false)
            {
                PlayIntro();
            }
        }
        //Initializes and Runs the Intro- Ends with the song or the escape key
        private void PlayIntro()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100 / 60);
            timer.Tick += tick;
            timer.Start();
            if (IntroHasRun == false)
            {
                IntroHasRun = true;
                music.MediaEnded += IntroOver;
                ackbar = new Rectangle();
                ackbar.Height = height;
                ackbar.Width = width;
                ackbar.Fill = new ImageBrush(new BitmapImage(new Uri("E:/Untitledbutackbarbutwhite.png")));
                scrollingText.Height = 400;
                scrollingText.Width = 800;
                scrollingText.HorizontalContentAlignment = HorizontalAlignment.Center;
                scrollingText.VerticalContentAlignment = VerticalAlignment.Top;
                scrollingText.Content = "Rogue II" + "\r\n" + "A Game";
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
        }
        //Runs intro at 60fps
        private void tick(object sender, EventArgs e)
        {
                delay++;
                if (delay >= 3)
                {
                    delay = 0;
                    TextPos.Y -= 3;
                    ackbarPos.Y -= 3;
                    otherCounter++;
                    if (height > 3 && width > 3 && otherCounter == 6)
                    {
                        height -= 0.5 * 129 / 90;
                        width -= 0.5;
                        otherCounter = 0;
                        if (scrollingText.FontSize >= 0.25)
                        {
                            scrollingText.FontSize -= 0.25;
                        }
                        TextPos.Y -= 1;
                        ackbarPos.X += 0.25;
                    }
                    scrollingText.Width = textwidth;
                    scrollingText.Height = textheight;
                    ackbar.Width = width;
                    ackbar.Height = height;
                    Canvas.SetLeft(scrollingText, TextPos.X);
                    Canvas.SetTop(scrollingText, TextPos.Y);
                    Canvas.SetTop(ackbar, ackbarPos.Y);
                    Canvas.SetLeft(ackbar, ackbarPos.X);
                    if (Keyboard.IsKeyDown(Key.Escape))
                    {
                        music.Stop();
                        gamestate = GameState.GameOn;
                        scrollingText.Visibility = Visibility.Hidden;
                        ackbar.Visibility = Visibility.Hidden;
                    }
                }
            
        }
        //Is Called when song ends
        private void IntroOver(object sender, EventArgs e)
        {
            music.Stop();
            gamestate = GameState.GameOn;
            scrollingText.Visibility = Visibility.Hidden;
            ackbar.Visibility = Visibility.Hidden;
        }
    }
}
