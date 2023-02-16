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

namespace prac13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double even_click = 0;
        public MainWindow()
        {
            InitializeComponent();
            change_background();
        }
        private void change_background()
        {
            BitmapImage bi3 = new();
            bi3.BeginInit();
            if ((even_click % 2) == 0)
                bi3.UriSource = new Uri("13021.png", UriKind.Relative);
            else
                bi3.UriSource = new Uri("free-icon-pause-button-3249396.png", UriKind.Relative);

            bi3.EndInit();
            Play_pause_image.Source = bi3;
        }

        private void Play_pause_Click(object sender, RoutedEventArgs e)
        {

            even_click++;
            change_background();
        }

        private void Open_folder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
