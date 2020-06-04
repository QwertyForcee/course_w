using System;
using System.IO;
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
using Microsoft.Win32;
using System.Windows.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        BinaryFormatter formatter = new BinaryFormatter();
        TracksCollection currentCollection;
        string currentPath;
        int CurTrackIndex;
        public MainWindow()
        {

            InitializeComponent();                  
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;   
            media.Volume = 0.05;
            VolumeSlider.Value = media.Volume;       
        }
        private void ChooseCollection()
        {
            CollectionWindow cwindow = new CollectionWindow();
            cwindow.Owner = this;
            cwindow.Show();
        }
        private void TrackListRefresh()
        {
            TrackList.Items.Clear();
            for(int i = 0; i < currentCollection.GetTracksCount(); i++)
            {
                TrackList.Items.Add(currentCollection.GetTrack(i));
            }
        }
        public void SetCurrentCollection(CollectionInfo info)
        {
            CurTrackIndex = 0;
            currentCollection = new TracksCollection(info.GetName());
            currentCollection.LoadFromFile(info.GetPath(), formatter);
            currentPath = currentCollection.GetTrackPath(0);
            media.Source = new Uri($"{currentPath}",UriKind.RelativeOrAbsolute);
            TitleBlock.Text = currentCollection.GetTrack(CurTrackIndex).ToString();
            TrackListRefresh();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (media.NaturalDuration.HasTimeSpan)
            {
                TimeLabel.Content = String.Format("{0}/{1}", media.Position.ToString(@"mm\:ss"), media.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
        }   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentCollection != null)
            {
                media.Volume = 0.05;
                timer.Start();
                media.Play();
            }
        }

        private void LoadItem_Click(object sender, RoutedEventArgs e)
        {         
            OpenFileDialog dialog = new OpenFileDialog() { Filter = "All files(*.*)|*.*" };
            if (dialog.ShowDialog()==true)
            {
                FileInfo fileInfo = new FileInfo(dialog.FileName);
                CreateTrackWin trackWin = new CreateTrackWin($"{fileInfo.DirectoryName}/{fileInfo.Name}");
                trackWin.Show();
            }        
        }
        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = VolumeSlider.Value;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void StopBut_Click(object sender, RoutedEventArgs e)
        {
           if(media.CanPause) media.Pause();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void About_Click_1(object sender, RoutedEventArgs e)
        {         
            MessageBox.Show("Its an audio player. Hope you enjoy this!");
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                media.Position += TimeSpan.FromSeconds((double)10);
            }
        }

        private void ChooseColl_Click(object sender, RoutedEventArgs e)
        {
            ChooseCollection();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentCollection!=null){
                CurTrackIndex++;
                if (CurTrackIndex >= currentCollection.GetTracksCount()) CurTrackIndex = 0;
                media.Source = new Uri($"{currentCollection.GetTrackPath(CurTrackIndex)}", UriKind.RelativeOrAbsolute);
                TitleBlock.Text = currentCollection.GetTrack(CurTrackIndex).ToString();
                media.Play();
            }
        }
        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            CurTrackIndex++;
            if (CurTrackIndex >= currentCollection.GetTracksCount()) CurTrackIndex = 0;
            media.Source = new Uri($"{currentCollection.GetTrackPath(CurTrackIndex)}", UriKind.RelativeOrAbsolute);
            TitleBlock.Text = currentCollection.GetTrack(CurTrackIndex).ToString(); 
            media.Play();
        }

        private void PrevTrackB_Click(object sender, RoutedEventArgs e)
        {
            CurTrackIndex--;
            if (CurTrackIndex < 0) CurTrackIndex = currentCollection.GetTracksCount() - 1;
            media.Source = new Uri($"{currentCollection.GetTrackPath(CurTrackIndex)}", UriKind.RelativeOrAbsolute);
            TitleBlock.Text = currentCollection.GetTrack(CurTrackIndex).ToString(); 
            media.Play();   
        }

        private void CreateCollectionBut_Click(object sender, RoutedEventArgs e)
        {
            CreateColWin colWin = new CreateColWin();
            colWin.Owner = this;
            colWin.Show();
        }
    }
}
