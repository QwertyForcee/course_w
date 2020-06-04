using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    [Serializable]
    class Track
    {
        public Track()
        {

        }
        public Track(string title, string artist, string path)
        {
            this.title = title;
            this.artist = artist;
            this.path = path;
        }
        private string title;
        private string artist;
        private string path;
        public string Title
        {
            get     
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
            }
        }
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
        public override string ToString()
        {
            return $"{this.title}-{this.artist}";
        }

    }
}
