using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CourseWork
{
    [Serializable]
    class TracksCollection
    {
        public TracksCollection(string name)
        {
            this.name = name;
            tracks = new List<Track>();
        }
        private string name;
        private List<Track> tracks;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public void AddTrack(Track track)
        {
            tracks.Add(track);
        }
        public void DeleteTrack(int index)
        {
            if(index>0)tracks.RemoveAt(index);
        }
        public string GetTrackPath(int index)
        {
            return tracks[index].Path;
        }
        public Track GetTrack(int index)
        {
            return this.tracks[index];
        }
        public int GetTracksCount()
        {
            return this.tracks.Count;
        }
        public void LoadToFile(string path, BinaryFormatter formatter)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this.tracks);
            }
        }
        public void LoadFromFile(string path, BinaryFormatter formatter)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    this.tracks = (List<Track>)formatter.Deserialize(fs);
                }
                else
                {
                    this.tracks = new List<Track>();
                }
            }
        }
    }
}
