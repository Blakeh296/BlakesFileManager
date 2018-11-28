using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace Default.Classes
{
    //ZIPArchive "is a" relationship with FileObj
    class ZIPArchive : FileObj
    {
        private ZipFile _zip;

        public ZIPArchive()
        {
            _zip = new ZipFile();
        }

        public ZIPArchive(string FilePath) :base(FilePath)
        {
            _zip = new ZipFile(FilePath);
        }

        public int InternalFileCount
        {
            get { return (FileExists) ? _zip.Count() : 0; }
        }
    }
}
