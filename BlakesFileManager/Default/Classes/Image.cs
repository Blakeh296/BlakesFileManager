using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default.Classes
{
    //Image "is a" relationship with FileObj
    class Image : FileObj
    {
        //Field
        private int _width;
        private int _height;
        private int _horizontalResolution;
        private int _verticalResolution;

        //Default Constructor
        public Image()
        {
            _width = 0;
            _height = 0;
            _horizontalResolution = 0;
            _verticalResolution = 0;
        }

        //Width Property
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        //Height Property
        public int Language
        {
            get { return _height; }
            set { _height = value; }
        }

        //HorizontalResolution Property
        public int HorizontalResolution
        {
            get { return _horizontalResolution; }
            set { _horizontalResolution = value; }
        }

        //VerticalResolution Property
        public int VerticalResolution
        {
            get { return _verticalResolution; }
            set { _verticalResolution = value; }
        }

        /*   Raster Image Files
       .BMP Bitmap Image File
       .DDS    DirectDraw Surface
       .GIF Graphical Interchange Format File
       .JPG JPEG Image
       .PNG Portable Network Graphic
       .PSD Adobe Photoshop Document
       .PSPIMAGE PaintShop Pro Image
       .TGA Targa Graphic
       .THM Thumbnail Image File
       .TIF Tagged Image File
       .TIFF Tagged Image File Format
       .YUV YUV Encoded Image File */
    }
}
