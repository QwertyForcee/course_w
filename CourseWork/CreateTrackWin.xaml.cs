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
using System.Windows.Shapes;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for CreateTrackWin.xaml
    /// </summary>
    public partial class CreateTrackWin : Window
    {
        string path;
        public CreateTrackWin(string path)
        {
            this.path = path;
            InitializeComponent();
            PathBlock.Text = path;
        }

        private void DoneBut_Click(object sender, RoutedEventArgs e)
        {
            if (TitleBox.Text!="" && ArtistBox.Text!="")
            {
                LoadTrackWin trackWin = new LoadTrackWin(TitleBox.Text, ArtistBox.Text, this.path);
                trackWin.Show();
                this.Close();
            }
        }
    }
}
