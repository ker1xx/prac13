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

namespace prac13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int even_click = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void change_background()
        {
            BitmapImage bi3 = new();
            if (even_click / 2 == 0)
                bi3.UriSource = new Uri("play.png", UriKind.Relative);
            else
                bi3.UriSource = new Uri("pause.png", UriKind.Relative);
            play_pause_image.ImageSource = bi3;
        }

        private void Play_pause_Click(object sender, RoutedEventArgs e)
        {

            even_click++;
        }

        private void Play_pause_MouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}
