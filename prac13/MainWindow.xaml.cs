using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace prac13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string vitalik = "";
        bool isPlaying = false;
        bool isShufled = false;
        bool isRepeated = false;
        bool isLast = false;
        bool isSongChanged = false;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            Volume.Maximum = 1;
            Volume.Value = 1;
            Thread thread = new Thread(_ =>
            {
                while (true)
                {

                    Dispatcher.Invoke(() => Timeline.Value = Media.Position.Ticks);
                    Thread.Sleep(1000);
                }
            });
            thread.Start();


        }

        private void Play_pause_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bi3 = new();
            bi3.BeginInit();

            if (isPlaying == false)
            {
                Media.Pause();
                bi3.UriSource = new Uri("../../../13021.png", UriKind.Relative);
            }
            else
            {
                Media.Play();
                bi3.UriSource = new Uri("../../../free-icon-pause-button-3249396.png", UriKind.Relative);
            }

            bi3.EndInit();
            isPlaying = !isPlaying;
            play_pause_image.ImageSource = bi3;
        }

        private void Open_folder_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog Song_picker = new() { IsFolderPicker = true };
            if (Song_picker.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(Song_picker.FileName);
                vitalik = Song_picker.FileName;
                foreach (string filename in files)
                {
                    Regex regex = new Regex(@"mp3", RegexOptions.Compiled | RegexOptions.RightToLeft);
                    if (regex.IsMatch(filename))
                    {
                        var file = new FileInfo(filename);
                        all_songs.Items.Add(file.Name);
                    }
                }
            }
            Media.Source = new Uri(Song_picker.FileName);
        }

        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            Timeline.Maximum = Media.NaturalDuration.TimeSpan.Ticks;
            DurationOfSong.Content = Media.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Volume = Volume.Value;
        }

        private void Timeline_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Position = new TimeSpan(Convert.ToInt64(Timeline.Value));
            if (Timeline.Value == Timeline.Maximum || ((isShufled == true || isRepeated == true) && isSongChanged == true))
            {
                if (isShufled == true || isRepeated == true) 
                {
                    if (isRepeated == true)
                    {
                        Media.Position = new TimeSpan(Convert.ToInt16(0));
                        isSongChanged = false;
                    }
                    else
                    {
                        Random rand = new Random();
                        int randindex = rand.Next(0, all_songs.Items.Count - 1);
                        _ = randindex == all_songs.SelectedIndex ? randindex = rand.Next(0, all_songs.Items.Count - 1) : all_songs.SelectedIndex = randindex;
                        isSongChanged = false;

                    }
                }
                else
                {
                    if (all_songs.SelectedIndex == all_songs.Items.Count - 1)
                        isLast = true;
                    all_songs.SelectedIndex += 1;
                    if (isLast == true)
                    {
                        all_songs.SelectedIndex = 0;
                        isLast = false;
                    }
                    isSongChanged = true;
                }
            }
            CurrentTimer.Content = Media.Position.ToString(@"hh\:mm\:ss");

        }

        private void all_songs_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            Media.Source = new Uri(vitalik+"\\"+all_songs.SelectedItem.ToString());
        }
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (all_songs.SelectedIndex == 0)
                all_songs.SelectedIndex = 0;
            else
                all_songs.SelectedIndex = all_songs.Items.Count - 1;
            isSongChanged = true;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (all_songs.SelectedIndex == all_songs.Items.Count - 1)
                isLast = true;
            all_songs.SelectedIndex += 1;
            if (isLast == true)
            {
                all_songs.SelectedIndex = 0;
                isLast = false;
            }
            isSongChanged = true;
        }

        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            isShufled = !isShufled;
        }

        private void Repeat_Click(object sender, RoutedEventArgs e)
        {
            isRepeated = !isRepeated;
        }

    }
}
