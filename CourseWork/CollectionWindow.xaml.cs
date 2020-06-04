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

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for CollectionWindow.xaml
    /// </summary>
    public partial class CollectionWindow : Window
    {
        List<CollectionInfo> collinfo;
        public CollectionWindow()
        {
            InitializeComponent();
            ReadCollections();
        }
        public void ReadCollections()
        {
            collinfo= new List<CollectionInfo>();
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
            
        protected virtual void Button_Click(object sender, RoutedEventArgs e)
        {
            // string temp = CollectionBox.Items.CurrentItem.ToString();
            string temp = CollectionBox.Text;
             foreach(var x in collinfo)
             {
                 if (temp.CompareTo(x.GetName())==0)
                 {
                     ((MainWindow)Application.Current.MainWindow).SetCurrentCollection(x);
                     break;
                 }
             }
            this.Close();
        }
    }
}
