using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CreateColWin.xaml
    /// </summary>
    public partial class CreateColWin : Window
    {
        public CreateColWin()
        {
            InitializeComponent();
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PathBlock.Text = NameBox.Text+".dat";
        }

        private void CreateBut_Click(object sender, RoutedEventArgs e)
        {
            if(NameBox.Text!="" && !NameBox.Text.Contains('.'))
            {
                string name = NameBox.Text;
                string path = PathBlock.Text;
                using (StreamWriter writer = new StreamWriter("collections.txt", true, System.Text.Encoding.Default))
                {
                    writer.WriteLine($"{name} {path}");
                }
                this.Close();
            }
        }
    }
}
