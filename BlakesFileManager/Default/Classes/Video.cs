using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default
{
    //Video "is a" relationship with FileObj
    class Video : FileObj
    {
        //Fields
        public int _length;
        public int _frameWidth;
        public int _frameHeight;
        public int _bitRate;
        public int _fps;

        //Default Constructor
        public Video()
        {
            _length = 0;
            _frameWidth = 0;
            _frameHeight = 0;
            _bitRate = 0;
            _fps = 0;
        }

        //Length Property
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        //FrameWidth Property
        public int FrameWidth
        {
            get { return _frameWidth; }
            set { _frameWidth = value; ; }
        }

        //Frame Height Property
        public int FrameHeight
        {
            get { return _frameHeight; }
            set { _frameHeight = value; }
        }


        //BitRate Property
        public int BitRate
        {
            get { return _bitRate; }
            set { _bitRate = value; }
        }

        //FPS Property
        public int FramesPerSecond
        {
            get { return _fps; }
            set { _fps = value; }
        }
    }
}
