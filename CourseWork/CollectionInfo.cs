using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class CollectionInfo
    {
        public CollectionInfo(string name,string path)
        {
            this.name = name;
            this.path = path;
        }
        private string path;
        private string name;
        public string GetName()
        {
            return name;
        }
        public string GetPath()
        {
            return path;
        }
    }
}
