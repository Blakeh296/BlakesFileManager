using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Classes
{
    // Audio class "is a" relationship with FileObj
    class Audio : FileObj
    {
        /*.AIF , .IFF , .M3U , .M4A , .MID , .MP3 , .MPA , .WAV , .WMA */

        //Field
        private string _artist;
        private string _album;
        private int _year;
        private int _length;
        private int _bitRate;

        //Default Constructor
        public Audio()
        {
            _artist = "";
            _album = "";
            _year = 0;
            _length = 0;
            _bitRate = 0;
        }

        //Artist Property
        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }

        //Album Property
        public string Album
        {
            get { return _album; }
            set { _album = value; }
        }

        //Year Property
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        //Length Property
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        //BitRate Property
        public int BitRate
        {
            get { return _bitRate; }
            set { _bitRate = value; }
        }
    }
}
