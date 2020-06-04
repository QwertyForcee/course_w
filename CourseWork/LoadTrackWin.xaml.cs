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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for LoadTrackWin.xaml
    /// </summary>
    public partial class LoadTrackWin : Window
    {
        List<CollectionInfo> collinfo;
        Track track;
        public LoadTrackWin(string title,string artist,string path)
        {
            track = new Track(title, artist, path);
            InitializeComponent();
            ReadCollections();
        }
        public void ReadCollections()
        {
            collinfo = new List<CollectionInfo>();
            using (StreamReader reader = new StreamReader("collections.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] temp = reader.ReadLine().Split(' ');
                    collinfo.Add(new CollectionInfo(temp[0], temp[1]));
                }
            }
            for (int i = 0; i < collinfo.Count; i++)
            {
                CollectionBox.Items.Add(collinfo[i].GetName());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TracksCollection collection;
            string temp = CollectionBox.Text;
            foreach (var x in collinfo)
            {
                if (temp.CompareTo(x.GetName()) == 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    collection = new TracksCollection(x.GetName());
                    collection.LoadFromFile(x.GetPath(), formatter);
                    collection.AddTrack(track);
                    collection.LoadToFile(x.GetPath(),formatter);
                    break;
                }
            }
            this.Close();
           
        }
    }
}
