using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace prac13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isPlaying = false;
        int current_sec_of_song = 0;
        public MainWindow()
        {
            InitializeComponent();
            Volume.Maximum = 1;

        }

        private void Play_pause_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi3 = new();
            bi3.BeginInit();
            Thread thread = new Thread(_ =>
            {
                while (true)
                {

                Dispatcher.Invoke(() => Timeline.Value += 1);
                Thread.Sleep(100);
                }
            });
            if (isPlaying == false)
            {
                Media.Stop();
                bi3.UriSource = new Uri("C:\\Users\\klink\\source\\repos\\prac13\\prac13\\13021.png", UriKind.Absolute);
            }
            else
            {
                Media.Play();
                bi3.UriSource = new Uri("C:\\Users\\klink\\source\\repos\\prac13\\prac13\\free-icon-pause-button-3249396.png", UriKind.Absolute);
                thread.Start();
            }

            bi3.EndInit();
            isPlaying = !isPlaying;
            play_pause_image.ImageSource = bi3;
        }

        private void Open_folder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Song_picker = new();
            if (Song_picker.ShowDialog() == true)
                foreach (string filename in Song_picker.FileNames)
                {
                    all_songs.Items.Add(filename);
                }
            Media.Source = new Uri(Song_picker.FileName);
        }

        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            Timeline.Maximum = (Media.NaturalDuration.TimeSpan.Ticks);
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Volume = Volume.Value;
        }

        private void Timeline_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Stop();
            Media.Position = new TimeSpan(Convert.ToInt64(Timeline.Value));
            Media.Play();
        }
    }
}
